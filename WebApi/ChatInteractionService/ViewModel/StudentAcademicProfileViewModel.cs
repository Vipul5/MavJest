using ChatInteractionService.Helper;

namespace ChatInteractionService.Model
{
    public record StudentAcademicProfileViewModel
    {
        public SubjectFeedbackViewModel MathFeedback { get; set; } = new SubjectFeedbackViewModel();

        public SubjectFeedbackViewModel EnglishFeedback { get; set; } = new SubjectFeedbackViewModel();

        public SubjectFeedbackViewModel HindiFeedback { get; set; } = new SubjectFeedbackViewModel();
    }
}
