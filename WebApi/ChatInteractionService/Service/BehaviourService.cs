using ChatInteractionService.Database.Entities;
using DataLayer.Repository;
using Ollama;
using System.Text.Json;

namespace ChatInteractionService.Service
{
    public class BehaviourService : BaseChatService, IBehaviourService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IBehaviourRepository behaviourRepository;
        private OllamaApiClient ollama;
        private IDictionary<int, Chat> behaviourChats = new Dictionary<int, Chat>();

        public BehaviourService(IStudentRepository studentRepository, IBehaviourRepository behaviourRepository)
        {
            this.studentRepository = studentRepository;
            this.behaviourRepository = behaviourRepository;
        }

        public async Task BootstrapStudentChat(OllamaApiClient ollama)
        {
            this.ollama = ollama;
            var students = this.studentRepository.GetAllStudents();
            foreach (var student in students)
            {
                var chat = await this.CreateStudentChat(student);
                this.behaviourChats.Add(student.Id, chat);
            }
        }



        private async Task<Chat> CreateStudentChat(Student student)
        {
            var systemMessage = "You need to analyze following data and provide response for upcoming questions.";
            var academicHistory = this.behaviourRepository.GetStudentBehaviorHistory(student.Id);

            var chat = new Chat(ollama, "Phi-3-5-mini-instruct-rzbrc", systemMessage);
            chat.ResponseFormat = ResponseFormat.Json;
            foreach (var academic in academicHistory)
            {
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
                var data = JsonSerializer.Serialize(academic, jsonSerializerOptions);

                await chat.SendAsync(data, MessageRole.Assistant);
            }

            return chat;
        }

        public async Task<string> TitleText(int studentId)
        {
            var message = @"Suggest a title in two to three words for my behavior and attitude. Be more generous and positive while suggesting student title, so that student can be motivated. Just respond with title, and do not type any extra word.";
            return await this.StringResultUserChat(this.behaviourChats[studentId], message);
        }
    }
}
