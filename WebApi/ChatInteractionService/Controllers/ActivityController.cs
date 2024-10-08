using MavJest.Service;
using Microsoft.AspNetCore.Mvc;
using OllamaSharp;
using OllamaSharp.Models.Chat;
using System.Text;
using System.Text.Json;

namespace MavJest.Controllers
{
    [Route("/api/activity")]
    public class ActivityController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ActivityController(IChatService chatService) {
            _chatService = chatService;
        }

        [HttpGet("gettodaysactivity")]
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

        [HttpGet("gettodaysseatingplan")]
        public async void GetTodaysSeatingArrangement()
        {
            var ollama = await _chatService.connectToOllama();
            string fileName = "./activitydata.json";
            var messages = _chatService.convertFiletoJSON(fileName);
            var chat = new Chat(ollama, "You need to analyze following data and provide response for upcoming questions.");
            chat.SetMessages(messages.ToList());
            var message2 = @"There are only 4 students in the class, below is their daily performance of those students. Based on the below data suggest a new seating arrangement by grouping them by studentId considering there are only 4 seats for 4 students in the class.
            Response should have a table with studentId and seating position only. Use the pattern as Row1 Column1.:
            {""StudentId"":""1"", ""Seating"" : {""Row"": ""Row1"", ""Coloumn"":""Col1"" }}";

            StringBuilder sb = new StringBuilder();
            await foreach (var answerToken in chat.SendAs(ChatRole.User, message2))
                sb.Append(answerToken);

            sb.Replace("```json", string.Empty);
            sb.Replace("```", string.Empty);

            Console.WriteLine(sb.ToString());

            var result = JsonSerializer.Deserialize<dynamic>(sb.ToString());
            Console.ReadLine();
        }


        [HttpGet(Name = "getgroupsforactivity")]
        public async void GetGroupsForActivity()
        {
            var ollama = await _chatService.connectToOllama();
            string fileName = "./activitydata.json";
            var messages = _chatService.convertFiletoJSON(fileName);
            var chat = new Chat(ollama, "You need to analyze following data and provide response for upcoming questions.");
            chat.SetMessages(messages.ToList());
            var message2 = @"create two groups of students having 2 in each out of the below details given based on their performance on different activities.
             Use the pattern as Group1 StudentList.:
            {""GroupNumber"":""1"", ""Students"" : ""1,2""}";

            StringBuilder sb = new StringBuilder();
            await foreach (var answerToken in chat.SendAs(ChatRole.User, message2))
                sb.Append(answerToken);

            sb.Replace("```json", string.Empty);
            sb.Replace("```", string.Empty);

            Console.WriteLine(sb.ToString());

          //  var result = JsonSerializer.Deserialize<dynamic>(sb.ToString());
            Console.ReadLine();
        }
    }


}
