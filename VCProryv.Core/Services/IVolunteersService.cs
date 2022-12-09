namespace VCProryv.Core.Services
{
    public interface IVolunteersService
    {
        Task<Volunteer[]> Get();
        Task<int> Create(Volunteer volunteer);
        Task<bool> Update(Volunteer volunteer);
        Task<bool> Delete(int id);
    }
}
