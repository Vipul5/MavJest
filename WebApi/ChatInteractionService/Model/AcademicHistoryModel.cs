using ChatInteractionService.Database.Entities;

namespace ChatInteractionService.Model
{
    public class AcademicHistoryModel
    {
        public SubjectModel Maths { get; set; } = new SubjectModel();
        public SubjectModel English { get; set; } = new SubjectModel();
        public SubjectModel Hindi { get; set; } = new SubjectModel();
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
