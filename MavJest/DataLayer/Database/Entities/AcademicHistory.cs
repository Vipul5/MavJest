namespace ChatInteractionService.Database.Entities
{
    public class AcademicHistory
    {
        public int Id { get; set; }
        public int StudentId { get; set; }  // Foreign key to Student
        public int? Maths { get; set; }
        public int? English { get; set; }
        public int? Hindi { get; set; }
        public bool? MathsAssignment { get; set; }
        public bool? EnglishAssignment { get; set; }
        public bool? HindiAssignment { get; set; }
        public DateTime Date { get; set; }
        public string Feedback { get; set; }

        // Navigation property for relationship
        public Student Student { get; set; }
    }
}
