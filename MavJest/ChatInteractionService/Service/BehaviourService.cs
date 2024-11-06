﻿using DataLayer.Repository;
using ChatInteractionService.Model;

namespace ChatInteractionService.Service;

public class BehaviourService : BaseChatService, IBehaviourService
{
    private readonly IStudentRepository studentRepository;
    private readonly IBehaviourRepository behaviourRepository;
    protected override object ContextData { get; set; }

    public BehaviourService(IStudentRepository studentRepository,
        IBehaviourRepository behaviourRepository,
     ChatServerModel chatServerModel)
     : base(chatServerModel)
    {
        this.studentRepository = studentRepository;
        this.behaviourRepository = behaviourRepository;
    }


    private List<BehaviourHistoryModel> GetStudentBehaviourData(int studentId)
    {
        var behaviourHistories = this.behaviourRepository.GetStudentBehaviorHistory(studentId);

        List<BehaviourHistoryModel> behaviourHistoryModels = new List<BehaviourHistoryModel>();
        foreach (var behaviour in behaviourHistories)
        {
            behaviourHistoryModels.Add(new BehaviourHistoryModel
            {
                Date = behaviour.Date,
                Behaviour = behaviour.ClassroomBehaviour,
                Social_Behaviour = behaviour.SocialBehaviour,
                Attitude = behaviour.Attitude,
                Engagement = behaviour.EngagementLevel,
                Mood = behaviour.Mood,
            });
        }
        return behaviourHistoryModels;
    }

    public async Task<string> StudentTitle(int studentId)
    {
        var student = this.studentRepository.GetStudent(studentId);

        var message = $"{student.Name} study in class {student.Class}. " +
                $"This is behaviour data, social behavior data, attitude in class, and engagement level" +
                $" recorded on different dates by his/her teacher." +
                $"Suggest a title in three to four words for his/her behaviour describing his/her charachter. " +
                $"Like \"Courageous and Bold\". " +
                $"Be more generous and positive while suggesting the title, " +
                $"so that student can be motivated, do not suggest weak areas, " +
                $"just suggest positive behaviour. Just respond with single title, and do not type any extra word.";
        this.Temperature = 0.9f;
        this.TopK = 60;
        this.TopP = 0.9f;
        this.ContextData = this.GetStudentBehaviourData(studentId);
        return (await this.JsonResultUserChat<ChatResponseModel>(message)).ChatResponse;
    }

    public async Task<string> BriefBehavior(int studentId)
    {
        var student = this.studentRepository.GetStudent(studentId);

        var message = $"{student.Name} study in class {student.Class}. " +
                $"This is behaviour data, social behavior data, attitude in class, and engagement level" +
                $" recorded on different dates by his/her teacher." +
                $"Summarize his/her general behaviour in class in three to four words. " +
                $"Like \"Extrovert and Orator\". " +
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