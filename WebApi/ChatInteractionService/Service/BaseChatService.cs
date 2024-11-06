using ChatInteractionService.Model;
using Ollama;
using System.Runtime.Serialization;
using System.Text.Json;

namespace ChatInteractionService.Service
{
    public abstract class BaseChatService
    {
        protected readonly ChatServerModel chatServerModel;
        private Chat chat;
        protected abstract object ContextData { get; set; }

        /// <summary>
        /// Temperature of the Model.
        /// Increasing temperature make model more creative.
        /// Range 0.0 - 1.0.
        /// </summary>
        protected float Temperature { get; set; }

        /// <summary>
        /// Reduce the probability of generating nonsense.
        /// Higher value generate more diverse answer (eg. 100),
        /// while lower value be more conservative (eg. 10).
        /// </summary>
        protected int TopK { get; set; }

        /// <summary>
        /// Highter value will lead to more diverse text,
        /// while the lower value be more conservative and focused.
        /// Range 0.0 - 1.0.
        /// </summary>
        protected float TopP { get; set; }

        public BaseChatService(ChatServerModel chatServerModel)
        {
            this.chatServerModel = chatServerModel;
            this.Temperature = 0.1f;
            this.TopK = 1;
            this.TopP = 0.1f;
        }

        protected async Task<T> JsonResultUserChat<T>(string message)
        {
            this.InitializeChat();
            message += "You should respond in only JSON with the following format, no extra message / text should be provided:\n";

            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true};

            T instance = Activator.CreateInstance<T>();
            message += JsonSerializer.Serialize(instance, options);
            message += "\n";

            var response = await this.chat.SendAsync(message, MessageRole.User);

            if(response.Content.IndexOf("```json") >= 0)
            {
                int firstIndex = response.Content.IndexOf("```json") + 7;
                int lastIndex = response.Content.LastIndexOf("```");
                response.Content = response.Content.Substring(firstIndex, lastIndex - firstIndex);
            }

            Console.WriteLine(response.Content);

            return JsonSerializer.Deserialize<T>(response.Content);
        }

        protected void InitializeChat()
        {
            var systemMessage = "You need to analyze following data and provide response for upcoming questions.";
            var requestOptions = new RequestOptions() { Temperature = this.Temperature, TopK = this.TopK, TopP = this.TopP };
            this.chat = new Chat(chatServerModel.ChatApiClient, "phi3:mini", systemMessage, ResponseFormat.Json, requestOptions);

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
            var data = JsonSerializer.Serialize(this.ContextData, jsonSerializerOptions);

            chat.History.Add(new Message { Role = MessageRole.User, Content = data });
        }
    }
}
