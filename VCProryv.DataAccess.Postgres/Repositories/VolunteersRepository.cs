using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using VCProryv.Core;
using VCProryv.Core.Repositories;

namespace VCProryv.DataAccess.Postgres.Repositories
{
    public class VolunteersRepository : IVolunteersRepository
    {
        private readonly VCProryvDbContext _context;

        public VolunteersRepository(VCProryvDbContext context)
        {
            _context = context;
        }

        public async Task<Volunteer[]> Get()
        {
            var volunteers = await _context.Volunteers
                .AsNoTracking()
                .ToArrayAsync();
            return volunteers.Select(x => new Volunteer
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                MiddleName = x.MiddleName,
                Institute = x.Institute
            }).ToArray();
        }

        public async Task<int> Add(Volunteer volunteer)
        {
            if(volunteer is null)
            {
                throw new ArgumentNullException(nameof(volunteer));
            }

            var newVolunteerEntity = new Entities.Volunteer
            {
                Name = volunteer.Name,
                Surname = volunteer.Surname,
                MiddleName= volunteer.MiddleName,
                Institute = volunteer.Institute
            };

            await _context.Volunteers.AddAsync(newVolunteerEntity);
            await _context.SaveChangesAsync();

            return newVolunteerEntity.Id;
        }

        

        public async Task<bool> Update(Volunteer correctVolunteer)
        {
            var volunteer = await _context.Volunteers.FirstOrDefaultAsync(x => x.Id == correctVolunteer.Id);
            if(volunteer != null)
            {
                volunteer.Name = correctVolunteer.Name;
                volunteer.Surname = correctVolunteer.Surname;
                volunteer.MiddleName = correctVolunteer.MiddleName;
                volunteer.Institute = correctVolunteer.Institute;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var volunteer = await _context.Volunteers.FirstOrDefaultAsync(x => x.Id == id);
            if(volunteer != null)
            {
                _context.Volunteers.Remove(volunteer);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

        }
    }
}
