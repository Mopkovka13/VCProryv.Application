using VCProryv.Core;
using VCProryv.Core.Exceptions;
using VCProryv.Core.Repositories;
using VCProryv.Core.Services;

namespace VCProryv.BusinessLogic
{
    public class VolunteersService : IVolunteersService
    {
        public const string VOLUNTEER_IS_INVALID = "Volunteer is invalid!";
        private readonly IVolunteersRepository _volunteersRepository;

        public VolunteersService(IVolunteersRepository volunteersRepository)
        {
            _volunteersRepository = volunteersRepository;
        }
        public async Task<Volunteer[]> Get()
        {
            return await _volunteersRepository.Get();
        }
        public async Task<int> Create(Volunteer volunteer)
        {
            if (volunteer == null)
            {
                throw new ArgumentNullException(nameof(volunteer));
            }

            var isInvalid = volunteer.Name == null || string.IsNullOrWhiteSpace(volunteer.Name) ||
                            volunteer.Surname == null || string.IsNullOrWhiteSpace(volunteer.Surname) ||
                            volunteer.MiddleName == null || string.IsNullOrWhiteSpace(volunteer.MiddleName) ||
                            volunteer.Institute == null || string.IsNullOrWhiteSpace(volunteer.Institute);

            if (isInvalid)
            {
                throw new BusinessException(VOLUNTEER_IS_INVALID);
            }

            var volunteerId = await _volunteersRepository.Add(volunteer);
            return volunteerId;
        }
        public async Task<bool> Update(Volunteer volunteer)
        {
            if (volunteer == null)
            {
                throw new ArgumentNullException(nameof(volunteer));
            }

            var isInvalid = volunteer.Name == null || string.IsNullOrWhiteSpace(volunteer.Name) ||
                            volunteer.Surname == null || string.IsNullOrWhiteSpace(volunteer.Surname) ||
                            volunteer.MiddleName == null || string.IsNullOrWhiteSpace(volunteer.MiddleName) ||
                            volunteer.Institute == null || string.IsNullOrWhiteSpace(volunteer.Institute);

            if (isInvalid)
            {
                throw new BusinessException(VOLUNTEER_IS_INVALID);
            }

            var status = await _volunteersRepository.Update(volunteer);
            return status;
        }

        public async Task<bool> Delete(int id)
        {
            var status = await _volunteersRepository.Delete(id);
            return status;
        }
    }
}
