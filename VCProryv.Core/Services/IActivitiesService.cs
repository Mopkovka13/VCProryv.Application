namespace VCProryv.Core.Services
{
    public interface IActivitiesService
    {
        Task<int> Create(Activity activity);
    }
}
