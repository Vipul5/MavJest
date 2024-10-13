using ChatInteractionService.Database.Entities;
using DataLayer.Repository;
using OllamaSharp.Models.Chat;
using OllamaSharp;
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

        public void BootstrapStudentChat(OllamaApiClient ollama)
        {
            this.ollama = ollama;
            var students = this.studentRepository.GetAllStudents();
            foreach (var student in students)
            {
                var chat = this.CreateStudentChat(student);
                this.behaviourChats.Add(student.Id, chat);
            }
        }



        private Chat CreateStudentChat(Student student)
        {
            var chat = new Chat(ollama, "You need to analyze following data and provide response for upcoming questions.");
            var academicHistory = this.behaviourRepository.GetStudentBehaviorHistory(student.Id);
            List<Message> messages = new List<Message>();
            foreach (var academic in academicHistory)
            {
                var data = JsonSerializer.Serialize(academic);
                messages.Add(new Message(ChatRole.System, data));
            }
            chat.SetMessages(messages);
            return chat;
        }

        public async Task<string> TitleText(int studentId)
        {
            var message = @"Suggest a title in two to three words for my behavior and attitude. Be more generous and positive while suggesting student title, so that student can be motivated. Just respond with title, and do not type any extra word.";
            return await this.StringResultUserChat(this.behaviourChats[studentId], message);
        }
    }
}
