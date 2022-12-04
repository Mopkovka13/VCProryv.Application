namespace VCProryv.Core.Services
{
    public interface IActivityService
    {
        Task<int> Create(Activity activity);
        
    }
}
