using DataLayer.Repository;
using ChatInteractionService.Service;
using ChatInteractionService.Model;

namespace MavJest.Service
{
    public class AcademicHistoryService : BaseChatService, IAcademicHistoryService
    {
        private readonly IStudentRepository studentRepository;
        private readonly IAcademicHistoryRepository academicHistoryRepository;
        private readonly IBehaviourRepository behaviourRepository;
        protected override object ContextData { get; set; }

        public AcademicHistoryService(IStudentRepository studentRepository, 
            IAcademicHistoryRepository academicHistoryRepository, 
            IBehaviourRepository behaviourRepository,
            ChatServerModel chatServerModel)
            : base(chatServerModel) 
        {
            this.studentRepository = studentRepository;
            this.academicHistoryRepository = academicHistoryRepository;
            this.behaviourRepository = behaviourRepository;
        }

        private List<AcademicHistoryModel> GetStudentAcademicData(int studentId)
        {
            var academicHistory = this.academicHistoryRepository.GetStudentAcademicHistory(studentId);

            List<AcademicHistoryModel> academicHistoryModels = new List<AcademicHistoryModel>();
            foreach (var academic in academicHistory)
            {
                academicHistoryModels.Add(new AcademicHistoryModel
                {
                    English = new SubjectModel { ClassScore = academic.English, IsAssignmentDone = academic.EnglishAssignment },
                    Hindi = new SubjectModel { ClassScore = academic.Hindi, IsAssignmentDone = academic.HindiAssignment },
                    Maths = new SubjectModel { ClassScore = academic.Maths, IsAssignmentDone = academic.MathsAssignment },
                    Date = academic.Date,
                    Day_Feedback = academic.Feedback
                });
            }
            return academicHistoryModels;
        }

        public async Task<string> BriefAcademicSkill(int studentId)
        {
            var student = this.studentRepository.GetStudent(studentId);
            var message = $"{student.Name} study in class {student.Class}. " +
                $"This is data, recorded on different dates by his/her teacher." +
                $"Suggest a title in three to four words for his/her academic performance. " +
                $"Like \"Excellent Orator in English Language Arts\". " +
                $"Be more generous and positive while suggesting the academic title, " +
                $"so that student can be motivated, do not suggest weak areas, " +
                $"just suggest positive skills. Just respond with single title, and do not type any extra word.";

            this.ContextData = this.GetStudentAcademicData(studentId);

            return (await this.JsonResultUserChat<ChatResponseModel>(message)).ChatResponse;
        }

        public async Task<StudentAcademicProfileViewModel> AcademicProfile(int studentId)
        {
            var student = this.studentRepository.GetStudent(studentId);
            var message = $"{student.Name} study in class {student.Class}. " +
                $"This is data, recorded on different dates by his/her teacher. " +
                $"Where teacher records {student.Name}'s classroom performance in each subject, and his/her feedback for that day." +
                $"Analyze this data and basis on this suggest me title and brief feedback in each subject, telling me how he/she is performing, " +
                $"and what are the gaps he/she need to work upon in that subject. " +
                $"Title needs to be a one liner saying performing good or not, " +
                $"feedback could be in 2 to 3 lines telling his performance trend, " +
                $"classwork and practice work or assignment done. Generate title and detailed feedback for each subject. " +
                $"Feedback should be only his peformance trend and how he is doing his assignment. " +
                $"Like Feedback is \"Performance is consistently increasing, assignments are sometime missed, can work more on assignments.\"";

            this.ContextData = this.GetStudentAcademicData(studentId);

            return await this.JsonResultUserChat<StudentAcademicProfileViewModel>(message);
        }
    }
}
