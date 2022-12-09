namespace VCProryv.Core.Repositories
{
    public interface IVolunteersRepository
    {
        Task<Volunteer[]> Get();
        Task<int> Add(Volunteer volunteer);
        Task<bool> Update(Volunteer volunteer);
        Task<bool> Delete(int id);
    }
}
