namespace MavJest.ChatInteractionService.Model
{
    public record StudentAcademicProfileViewModel
    {
        public SubjectFeedbackViewModel MathSummary { get; set; } = new SubjectFeedbackViewModel();

        public SubjectFeedbackViewModel EnglishSummary { get; set; } = new SubjectFeedbackViewModel();

        public SubjectFeedbackViewModel HindiSummary { get; set; } = new SubjectFeedbackViewModel();
    }
}
