using OllamaSharp;
using OllamaSharp.Models.Chat;
using System.Text.Json;
using ChatInteractionService.Database.Entities;
using ChatInteractionService.Database.Context;
using Microsoft.EntityFrameworkCore;
using MavJest.Repository;
using DataLayer.Repository;
using ChatInteractionService.Service;
using ChatInteractionService.Model;

namespace MavJest.Service
{
    public class AcademicHistoryService : BaseChatService, IAcademicHistoryService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IAcademicHistoryRepository academicHistoryRepository;
        private OllamaApiClient ollama;
        private IDictionary<int, Chat> academicChats = new Dictionary<int, Chat>();

        public AcademicHistoryService(IStudentRepository studentRepository, IAcademicHistoryRepository academicHistoryRepository)
        {
            this.studentRepository = studentRepository;
            this.academicHistoryRepository = academicHistoryRepository;
        }

        public void BootstrapStudentChat(OllamaApiClient ollama)
        {
            this.ollama = ollama;
            var students = this.studentRepository.GetAllStudents();
            foreach (var student in students)
            {
                var chat = this.CreateStudentChat(student);
                this.academicChats.Add(student.Id, chat);
            }
        }



        private Chat CreateStudentChat(Student student)
        {
            var chat = new Chat(ollama, "You need to analyze following data and provide response for upcoming questions.");
            var academicHistory = this.academicHistoryRepository.GetStudentAcademicHistory(student.Id);
            List<Message> messages = new List<Message>();
            foreach (var academic in academicHistory)
            {
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
                var data = JsonSerializer.Serialize(new AcademicHistoryModel
                {
                    English = new SubjectModel { ClassScore = academic.English, IsAssignmentDone = academic.EnglishAssignment },
                    Hindi = new SubjectModel { ClassScore = academic.Hindi, IsAssignmentDone = academic.HindiAssignment },
                    Maths = new SubjectModel { ClassScore = academic.Maths, IsAssignmentDone = academic.MathsAssignment },
                    Date = academic.Date
                }, jsonSerializerOptions);
                messages.Add(new Message(ChatRole.System, data));
            }
            chat.SetMessages(messages);
            return chat;
        }

        public async Task<string> BriefAcademicSkill(int studentId)
        {
            var message = @"This is data of single student. Suggest a title in three to four words for student's academic skills. Like ""Excellent Orator in English Language Arts"". Be more generous and positive while suggesting the academic title, so that student can be motivated, do not suggest weak areas, just suggest positive skills. Just respond with single title, and do not type any extra word.";
            return await this.StringResultUserChat(this.academicChats[studentId], message);
        }

        public async Task<StudentAcademicProfileViewModel> AcademicProfile(int studentId)
        {
            var message = @"Analyze students records provided. Now suggest me title and brief feedback of each subject, telling me how he is performing, and what are the gaps he need to work upon in that subject. Title needs to be a one liner saying performing good or not, feedback could be in 2 to 3 lines telling his performance trend, classwork and practice work or assignment done. Generate title and detailed feedback for each subject.";
            return await this.JsonResultUserChat<StudentAcademicProfileViewModel>(this.academicChats[studentId], message);
        }
    }
}
