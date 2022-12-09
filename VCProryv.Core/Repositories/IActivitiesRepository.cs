namespace VCProryv.Core.Repositories
{
    public interface IActivitiesRepository
    {
        Task<int> Add(Activity activity);
    }
}
