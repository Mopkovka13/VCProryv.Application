namespace VCProryv.Core.Repositories
{
    public interface IVolunteersRepository
    {
        Task<Volunteer[]> Get();
        Task<int> Add(Volunteer volunteer);
    }
}
