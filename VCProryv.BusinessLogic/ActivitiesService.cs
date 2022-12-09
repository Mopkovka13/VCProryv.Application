using VCProryv.Core;
using VCProryv.Core.Repositories;
using VCProryv.Core.Services;

namespace VCProryv.BusinessLogic
{
    public class ActivitiesService : IActivitiesService
    {
        private IActivitiesRepository _activitiesRepository;
        public ActivitiesService(IActivitiesRepository activitiesRepository)
        {
            _activitiesRepository = activitiesRepository;
        }
        public async Task<int> Create(Activity activity)
        {
            if (activity == null)
                throw new ArgumentNullException();

            var activityId = await _activitiesRepository.Add(activity);

            return activityId;
        }
    }
}
