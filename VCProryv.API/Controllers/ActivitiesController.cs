using Microsoft.AspNetCore.Mvc;
using System.Net;
using VCProryv.API.Contracts;
using VCProryv.Core.Services;

namespace VCProryv.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivitiesService _activitiesService;

        public ActivitiesController(IActivitiesService activitiesService)
        {
            _activitiesService = activitiesService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] NewActivity request)
        {
            var activity = new Core.Activity
            {
                Name = request.Name,
                Degree = request.Degree,
                Date = request.Date,
                Volunteers = request.Volunteers.Select(x => new Core.Volunteer //Зачем мне все новые данные, если нужно указать только Id Добавленных волонтёров ;(
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    MiddleName = x.MiddleName,
                    Institute = x.Institute

                }).ToArray()
            };
            var result = await _activitiesService.Create(activity);
            return Ok(result);
        }
    }
}
