namespace MavJest.ChatInteractionService.Model;

public class ActivityBehaviourModel
{
    public string Efforts { get; set; }            
    public string Enthusiasm { get; set; }        
    public string ParticipationLevel { get; set; } 
    public string Mood { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}
