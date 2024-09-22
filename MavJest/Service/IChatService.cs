using OllamaSharp;
using OllamaSharp.Models.Chat;

namespace MavJest.Service
{
    public interface IChatService
    {
        public IList<Message> createJSONData();

        public IList<Message> convertFiletoJSON(string fileName);

        public void convertSQLDatatoJSON();

        public Task<OllamaApiClient> connectToOllama();
    }
}
