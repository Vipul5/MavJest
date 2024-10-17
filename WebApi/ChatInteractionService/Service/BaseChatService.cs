using Ollama;
using System.Text.Json;

namespace ChatInteractionService.Service
{
    public class BaseChatService
    {
        protected async Task<T> JsonResultUserChat<T>(Chat chat, string message)
        {
            message += "You should respond only with JSON string in the following format, no extra message / text should be provided:\n";

            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true};

            T instance = Activator.CreateInstance<T>();
            message += JsonSerializer.Serialize(instance, options);
            message += "\n";

            var response = await chat.SendAsync(message, MessageRole.User);

            response.Content.Replace("```json", string.Empty);
            response.Content.Replace("```", string.Empty);

            Console.WriteLine(response.Content);

            var result = JsonSerializer.Deserialize<T>(response.Content);
            return result;
        }

        protected async Task<string> StringResultUserChat(Chat chat, string message)
        {
            var response = await chat.SendAsync(message, MessageRole.User);

            response.Content.Replace("```json", string.Empty);
            response.Content.Replace("```", string.Empty);

            Console.WriteLine(response.Content);
            return response.Content;
        }
    }
}
