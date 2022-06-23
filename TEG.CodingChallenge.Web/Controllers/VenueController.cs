using Microsoft.AspNetCore.Mvc;
using TEG.CodingChallenge.Business.Interface.Manager;

namespace TEG.CodingChallenge.Web.Controllers
{
    [Route("api/venue")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly IVenueManager _venueManager;

        // TODO: Implement mapping (AutoMapper) to prevent over posting.
        /// <summary>
        /// cTor.
        /// </summary>
        /// <param name="venuManager"></param>
        public VenueController(IVenueManager venuManager)
        {
            _venueManager = venuManager;
        }

        /// <summary>
        /// Get venues.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Fetch()
        {
            return Ok(_venueManager.Fetch());
        }

        /// <summary>
        /// Get by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_venueManager.GetById(id));
        }
    }
}
