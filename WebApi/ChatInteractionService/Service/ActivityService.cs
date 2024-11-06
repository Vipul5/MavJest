using DataLayer.Repository;
using ChatInteractionService.Model;
using MavJest.Repository;

namespace ChatInteractionService.Service;

public class ActivityService : BaseChatService, IActivityService
{
    private readonly IStudentRepository studentRepository;
    private readonly IActivityRepository _activityRepository;
    protected override object ContextData { get; set; }

    public ActivityService(IStudentRepository studentRepository,
            IActivityRepository activityRepository,
     ChatServerModel chatServerModel)
     : base(chatServerModel)
    {
        this.studentRepository = studentRepository;
        _activityRepository = activityRepository;
    }

    private List<ActivityBehaviourModel> GetStudentBehaviourData(int studentId)
    {
        var behaviourHistories = this._activityRepository.GetActivityHistoryByStudentId(studentId);

        List<ActivityBehaviourModel> behaviourHistoryModels = new List<ActivityBehaviourModel>();
        foreach (var behaviour in behaviourHistories)
        {
            behaviourHistoryModels.Add(new ActivityBehaviourModel
            {
                Date = behaviour.Date,
                Mood = behaviour.Mood,
                Efforts = behaviour.Efforts,
                Enthusiasm = behaviour.Enthusiasm,
                ParticipationLevel = behaviour.ParticipationLevel,
            });
        }
        return behaviourHistoryModels;
    }
//            var chat = new Chat(ollama, "You need to analyze following data and provide response for upcoming questions.");
    public async Task<string> BriefBehavior(int studentId)
    {
        var student = this.studentRepository.GetStudent(studentId);

        var message = $"{student.Name} study in class {student.Class}. " +
                $"This is behaviour data of student in activity" +
                $" recorded on different dates by his/her teacher." +
                $"Summarize his/her general behaviour in activy in three to four words. " +
                $"Like \"Interested and Cooperative\". " +
                $"Be more generous and positive while suggesting the title, " +
                $"so that student can be motivated, do not suggest weak areas, " +
                $"just suggest positive behaviour. Just respond with single title, and do not type any extra word.";
        this.Temperature = 0.9f;
        this.TopK = 60;
        this.TopP = 0.9f;
        this.ContextData = this.GetStudentBehaviourData(studentId);
        return (await this.JsonResultUserChat<ChatResponseModel>(message)).ChatResponse;
    }

    public async Task<string> BriefParticipation(int studentId)
    {
        var student = this.studentRepository.GetStudent(studentId);

        var message = $"{student.Name} study in class {student.Class}. " +
                $"This is behaviour data of student in activity" +
                $" recorded on different dates by his/her teacher." +
                $"Summarize his/her participation in activities in three to four words. " +
                $"Like \"Participative and Excited\". " +
                $"Be more generous and positive while suggesting the title, " +
                $"so that student can be motivated, do not suggest weak areas, " +
                $"just suggest positive behaviour. Just respond with single title, and do not type any extra word.";
        this.Temperature = 0.9f;
        this.TopK = 60;
        this.TopP = 0.9f;
        this.ContextData = this.GetStudentBehaviourData(studentId);
        return (await this.JsonResultUserChat<ChatResponseModel>(message)).ChatResponse;
    }
}
