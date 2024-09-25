using System.ComponentModel.DataAnnotations.Schema;

namespace ChatInteractionService.Database.Entities
{
    public class ActivityHistory
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime Date { get; set; }
        public string ActivityName { get; set; }
        public string Description { get; set; }
        public string Performance { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }  // Foreign key relationship
    }
}
