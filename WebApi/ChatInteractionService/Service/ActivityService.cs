//using ChatInteractionService.Database.Entities;
//using ChatInteractionService.Model;
//using ChatInteractionService.Service;
//using DataLayer.Repository;
//using MavJest.Repository;
//using Ollama;
//using OpenAI.Chat;
//using System;
//using System.Text;
//using System.Text.Json;

//namespace MavJest.Service
//{
//    public class ActivityService : BaseChatService, IActivityService
//    {
//        private readonly IStudentRepository studentRepository;
//        private OllamaApiClient ollama;
//        private IDictionary<int, Chat> activityChats = new Dictionary<int, Chat>();
//        private Chat classChat;
//        private readonly IActivityRepository _activityRepository;

//        public ActivityService(IStudentRepository studentRepository, IActivityRepository activityRepository)
//        {
//            this.studentRepository = studentRepository;
//            _activityRepository = activityRepository;
//        }

//        public async Task BootstrapStudentChat(OllamaApiClient ollama)
//        {
//            this.ollama = ollama;
//            var students = this.studentRepository.GetAllStudents();
//            foreach (var student in students)
//            {
//                var chat = await this.CreateStudentChat(student);
//                this.activityChats.Add(student.Id, chat);
//            }
//            this.classChat = this.CreateClassChat();
//        }

//        private async Task<Chat> CreateStudentChat(Student student)
//        {
//            var systemMessage = "You need to analyze following data and provide response for upcoming questions.";
//            var activityHistories = this._activityRepository.GetActivityHistoryByStudentId(student.Id);

//            var chat = new Chat(ollama, "Phi-3-5-mini-instruct-rzbrc", systemMessage);
//            chat.ResponseFormat = ResponseFormat.Json;
//            foreach (var activity in activityHistories)
//            {
//                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

//                var data = JsonSerializer.Serialize(activity, jsonSerializerOptions);
//                await chat.SendAsync(data, MessageRole.Assistant);
//            }

//            return chat;
//        }

//        private Chat CreateClassChat()
//        {
//            var chat = new Chat(ollama, "You need to analyze following data and provide response for upcoming questions.");
//            //chat.SetMessages(messages);
//            return chat;
//        }

//        public async Task<ChatInteractionService.Model.StudentActivityDetailViewModel> GetActivitySuggestion(int studentId)
//        {
//            var message = @"Analyze the provided data for this question. Now you have to analyze and share with me which activity should i plan with each student in class.";

//            return await this.JsonResultUserChat<ChatInteractionService.Model.StudentActivityDetailViewModel>(this.activityChats[studentId], message);
//        }

//        public async Task<ChatInteractionService.Model.StudentGroupViewModel> GetGroupForActivity()
//        {
//            var message = @"create two groups of students having 2 in each out of the below details given based on their performance on different activities.";
//            return await this.JsonResultUserChat<ChatInteractionService.Model.StudentGroupViewModel>(this.classChat, message);
//        }

//        public async Task<string> GetActivityTitle(int studentId)
//        {
//            var message = @"This is data of single student. Suggest an activity title in three to four words for student's activity participation and behaviour. Like ""Enthusiastic Group Collaborator"". Be more generous and positive while suggesting the activity title, so that student can be motivated, do not suggest weak areas, just suggest positive behviour. Just respond with single title, and do not type any extra word.";
//            return await this.StringResultUserChat(this.activityChats[studentId], message);
//        }
//    }
//}
