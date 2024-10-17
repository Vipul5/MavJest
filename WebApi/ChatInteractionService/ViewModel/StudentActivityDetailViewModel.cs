using ChatInteractionService.Helper;

namespace ChatInteractionService.Model
{
    public class StudentActivityDetailViewModel
    {
        [PropertyExample("Drawing")]
        public string ActivityTitle { get; set; }

        [PropertyExample("Drawing shapes, animals, etc.")]
        public string Description { get; set; }
    }
}
