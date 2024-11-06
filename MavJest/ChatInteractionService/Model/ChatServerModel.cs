using Ollama;

namespace ChatInteractionService.Model
{
    public class ChatServerModel
    {
        public OllamaApiClient ChatApiClient { get; set; }
        public string ChatServerUri { get; set; }
        public string AIModel { get; set; }
    }
}
