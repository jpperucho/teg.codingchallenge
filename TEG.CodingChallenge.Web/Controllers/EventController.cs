using Microsoft.AspNetCore.Mvc;
using TEG.CodingChallenge.Business.Interface.Manager;

namespace TEG.CodingChallenge.Web.Controllers
{
    [Route("api/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventManager _eventManager;

        /// <summary>
        /// cTor.
        /// </summary>
        /// <param name="eventManager"></param>
        public EventController(IEventManager eventManager)
        {
            _eventManager = eventManager;
        }

        /// <summary>
        /// Fetch events.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Fetch()
        {
            return Ok(_eventManager.Fetch());
        }

        /// <summary>
        /// Get by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_eventManager.GetById(id));
        }

        /// <summary>
        /// Fetch by venue ID.
        /// </summary>
        /// <param name="venueId"></param>
        /// <returns></returns>
        [HttpGet("byvenueid/{venueId}")]
        public IActionResult FetchByVenueId(int venueId)
        {
            return Ok(_eventManager.FetchByVenueId(venueId));
        }
    }
}
