namespace MavJest.ChatInteractionService.Model;

public class BehaviourHistoryModel
{
    public string Classroom_Behaviour { get; set; }
    public string Engagement { get; set; }
    public string Attitude { get; set; }
    public string Mood { get; set; }
    public string Social_Behaviour { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}
