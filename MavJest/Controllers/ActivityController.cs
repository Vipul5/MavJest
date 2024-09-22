using MavJest.Service;
using Microsoft.AspNetCore.Mvc;
using OllamaSharp;
using OllamaSharp.Models.Chat;
using System.Text;
using System.Text.Json;

namespace MavJest.Controllers
{
    public class ActivityController
    {
        private readonly IChatService _chatService;

        public ActivityController(IChatService chatService) {
            _chatService = chatService;
        }

        [HttpGet(Name = "gettodaysactivity")]
        public async void GetTodaysActivity()
        {
            var ollama = await _chatService.connectToOllama();
            string fileName = "./activitydata.json";
            var messages = _chatService.convertFiletoJSON(fileName);
            var chat = new Chat(ollama, "You need to analyze following data and provide response for upcoming questions.");
            chat.SetMessages(messages.ToList());
            var message2 = @"Analyze the provided data for this question. Now you have to analyze and share with me which activity should i plan with each student in class.
            The output should only be JSON string in the following format, no extra comment should be provided:
            {""StudentId"":""1"", ActivityTitle: ""Roll the boll"", Description : ""details of the activity""}";

            StringBuilder sb = new StringBuilder();
            await foreach (var answerToken in chat.SendAs(ChatRole.User, message2))
                sb.Append(answerToken);

            sb.Replace("```json", string.Empty);
            sb.Replace("```", string.Empty);

            Console.WriteLine(sb.ToString());

            var result = JsonSerializer.Deserialize<dynamic>(sb.ToString());
            Console.ReadLine();            
        }
    }


}
