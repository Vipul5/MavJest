using OllamaSharp.Models.Chat;
using OllamaSharp;
using System.Text.Json;
using System.Text;
using System.Reflection;
using ChatInteractionService.Helper;

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
            //PropertyInfo[] properties = type.GetProperties();
            //foreach (var property in properties)
            //{
            //    string value = property.Name;
            //    var attribute = property.GetCustomAttribute(typeof(PropertyExampleAttribute)) as PropertyExampleAttribute;
            //    if(attribute != null)
            //    {
            //        value = attribute.ExampleValue;
            //    }
            //    message += "\"" + property.Name + "\":\"" + value + "\",\n";
            //}
            //message = message.Trim('\n').Trim(',');
            //message+="\n}";

            StringBuilder sb = new StringBuilder();
            await foreach (var answerToken in chat.SendAs(ChatRole.User, message))
                sb.Append(answerToken);

            sb.Replace("```json", string.Empty);
            sb.Replace("```", string.Empty);

            Console.WriteLine(sb.ToString());

            var result = JsonSerializer.Deserialize<T>(sb.ToString());
            return result;
        }

        protected async Task<string> StringResultUserChat(Chat chat, string message)
        {
            StringBuilder sb = new StringBuilder();
            await foreach (var answerToken in chat.SendAs(ChatRole.User, message))
                sb.Append(answerToken);

            sb.Replace("```json", string.Empty);
            sb.Replace("```", string.Empty);

            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }
    }
}
