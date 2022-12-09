using VCProryv.Core;
using VCProryv.Core.Repositories;

namespace VCProryv.DataAccess.Postgres.Repositories
{
    public class ActivitiesRepository : IActivitiesRepository
    {
        public readonly VCProryvDbContext _context;
        public ActivitiesRepository(VCProryvDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Activity activity)
        {
            var newHomeworkEntity = new Entities.Activity
            {
                Name = activity.Name,
                Degree = activity.Degree,
                Date = activity.Date,
                Volunteers = activity.Volunteers.Select(x => new Entities.Volunteer
                {
                    Name = x.Name,
                    Surname = x.Surname,
                    MiddleName = x.MiddleName,
                    Institute = x.Institute

                }).ToArray()
            };
            await _context.Activities.AddAsync(newHomeworkEntity);
            await _context.SaveChangesAsync(); 

            return newHomeworkEntity.Id;
        }
    }
}
