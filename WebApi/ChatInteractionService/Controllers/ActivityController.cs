using ChatInteractionService.Model;
using MavJest.Service;
using Microsoft.AspNetCore.Mvc;
using OllamaSharp;
using OllamaSharp.Models.Chat;
using System.Text;
using System.Text.Json;

namespace MavJest.Controllers
{
    [Route("/api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IAcademicHistoryService _chatService;
        private readonly IActivityService _activityService;

        public ActivityController(IAcademicHistoryService chatService, IActivityService activityService)
        {
            _chatService = chatService;
            _activityService = activityService;
        }

        [HttpGet("gettodaysactivity")]
        public async Task<StudentActivityDetailViewModel> GetTodaysActivity(int studentId)
        {
            return await _activityService.GetActivitySuggestion(studentId);
        }

        //[HttpGet("gettodaysseatingplan")]
        //public async void GetTodaysSeatingArrangement()
        //{
        //    string fileName = "./activitydata.json";
        //    var messages = _chatService.convertFiletoJSON(fileName);
        //    var chat = new Chat(ollama, "You need to analyze following data and provide response for upcoming questions.");
        //    chat.SetMessages(messages.ToList());
        //    var message2 = @"There are only 4 students in the class, below is their daily performance of those students. Based on the below data suggest a new seating arrangement by grouping them by studentId considering there are only 4 seats for 4 students in the class.
        //    Response should have a table with studentId and seating position only. Use the pattern as Row1 Column1.:
        //    {""StudentId"":""1"", ""Seating"" : {""Row"": ""Row1"", ""Coloumn"":""Col1"" }}";

        //    StringBuilder sb = new StringBuilder();
        //    await foreach (var answerToken in chat.SendAs(ChatRole.User, message2))
        //        sb.Append(answerToken);

        //    sb.Replace("```json", string.Empty);
        //    sb.Replace("```", string.Empty);

        //    Console.WriteLine(sb.ToString());

        //    //TODO: it was giving error. So commented it.
        //    //var result = JsonSerializer.Deserialize<dynamic>(sb.ToString());
        //    Console.ReadLine();
        //}


        [HttpGet(Name = "getgroupsforactivity")]
        public async Task<StudentGroupViewModel> GetGroupsForActivity()
        {
            return await this._activityService.GetGroupForActivity();
        }

        [HttpGet("title")]
        public async Task<string> GetActivityTitle(int studentId)
        {
            return await this._activityService.GetActivityTitle(studentId);
        }
    }


}
