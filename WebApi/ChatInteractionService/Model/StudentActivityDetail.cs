using ChatInteractionService.Helper;

namespace ChatInteractionService.Model
{
    public class StudentActivityDetail
    {
        [PropertyExample("Drawing")]
        public string ActivityTitle { get; set; }

        [PropertyExample("Drawing shapes, animals, etc.")]
        public string Description { get; set; }
    }
}
