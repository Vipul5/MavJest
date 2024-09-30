namespace ChatInteractionService.Database.Entities
{
    public class BehaviourHistory
    {
        public int Id { get; set; }
        public int StudentId { get; set; }  // Foreign key to Student
        public string SeatingLocation { get; set; }
        public int? SeatedWithStudentId { get; set; }  // Nullable if student is not seated with anyone
        public string ClassroomBehaviour { get; set; }
        public string EngagementLevel { get; set; }    // e.g., Highly Engaged, Motivated
        public string Attitude { get; set; }           // e.g., Curious, Positive
        public string Mood { get; set; }               // e.g., Happy, Calm, Anxious
        public string SocialBehaviour { get; set; }    // e.g., Cooperative, Disruptive
        public DateTime Date { get; set; }

        // Navigation property for relationship
        public Student Student { get; set; }
        public Student SeatedWithStudent { get; set; }  // Self-reference for seating with another student
    }

}
