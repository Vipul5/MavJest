using ChatInteractionService.Database.Entities;
using MavJest.Repository;

namespace MavJest.Service
{
    public class ActivityService: IActivityService
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public ActivityDetails GetActivitySuggestion(int studentId)
        {
            var activityHistoies = _activityRepository.GetActivityHistoryByStudentId(studentId);

            //TODO:  Write some logic to create activity suggestion for the student and return that.
            return new ActivityDetails { Description = "Test Activity" };
        }
    }
}
