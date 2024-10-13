using ChatInteractionService.Helper;

namespace ChatInteractionService.Model
{
    public class StudentAcademicProfile
    {
        [PropertyExample("Consistent Performance with Strong Skills")]
        public string MathFeedbackTitle { get; set; }


        [PropertyExample("Demonstrated excellent problem-solving abilities in Math. Understanding of key concepts is strong, and you consistently show improvement. Keep up the good work!")]
        public string MathFeedback { get; set; }


        [PropertyExample("Confident Speaker, Improving Writing")]
        public string EnglishFeedbackTitle { get; set; }


        [PropertyExample("Spoken English is fluent and clear, showcasing his/her confidence and command of the language. Focus on improving written work by practicing grammar and sentence structure.")]
        public string EnglishFeedback { get; set; }

        [PropertyExample("Needs Improvement in Writing and Reading")]
        public string HindiFeedbackTitle { get; set; }


        [PropertyExample("Show potential in Hindi, but more effort is required in reading comprehension and written expression. Regular practice with reading and writing will help enhance his/her skills.")]
        public string HindiFeedback { get; set; }
    }
}
