using Microsoft.AspNetCore.Mvc;
using System.Net;
using VCProryv.API.Contracts;
using VCProryv.Core.Services;

namespace VCProryv.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VolunteersController : ControllerBase
    {
        private readonly IVolunteersService _volunteersService;

        public VolunteersController(IVolunteersService volunteersService)
        {
            _volunteersService = volunteersService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetVolunteersResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var volunteers = await _volunteersService.Get();
            var response = new GetVolunteersResponse
            {
                Volunteers = volunteers.Select(x => new Volunteer
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname= x.Surname,
                    MiddleName= x.MiddleName,
                    Institute= x.Institute
                }).ToArray()
            };
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] CreateVolunteerRequest request)
        {
            var volunteer = new Core.Volunteer
            {
                Name = request.Name,
                Surname= request.Surname,
                MiddleName= request.MiddleName,
                Institute= request.Institute
            };

            var volunteerId = await _volunteersService.Create(volunteer);
            return Ok(new CreateVolunteerResponse { VolunteerId = volunteerId});
        }

    }
}
