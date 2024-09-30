namespace ChatInteractionService.Database.Entities
{
    public class ActivityHistory
    {
        public int Id { get; set; }
        public int StudentId { get; set; }             // Foreign key to Student
        public int ActivityDetailsId { get; set; }     // Foreign key to ActivityDetails
        public string TaskCompletion { get; set; }     // e.g., Fully Completed, Incomplete
        public string Efforts { get; set; }            // e.g., High, Average
        public string Enthusiasm { get; set; }         // e.g., Enthusiastic, Neutral
        public string ParticipationLevel { get; set; } // e.g., Fully Engaged, Somewhat Engaged
        public string Mood { get; set; }               // e.g., Happy, Anxious
        public string Feedback { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }

        // Navigation properties for relationships
        public Student Student { get; set; }
        public ActivityDetails ActivityDetails { get; set; }
    }

}
