using TEG.CodingChallenge.Business.Interface.Manager;
using TEG.CodingChallenge.Business.Interface.Repository;
using TEG.CodingChallenge.Domain.Entities;

namespace TEG.CodingChallenge.Business.Manager
{
    /// <summary>
    /// Event manager.
    /// </summary>
    public class EventManager : IEventManager
    {
        private readonly IEventRepository _eventRepository;

        /// <summary>
        /// cTor.
        /// </summary>
        /// <param name="eventRepository"></param>
        public EventManager(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        /// <summary>
        /// Fetch.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Event> Fetch()
        {
            return _eventRepository.Events.OrderBy(e => e.StartDate);
        }

        /// <summary>
        /// Fetch by venue ID.
        /// </summary>
        /// <param name="venueId"></param>
        /// <returns></returns>
        public IEnumerable<Event> FetchByVenueId(int venueId)
        {
            return _eventRepository.Events.Where(e => e.VenueId == venueId);
        }

        /// <summary>
        /// Get by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Event GetById(int id)
        {
            var e = _eventRepository.Events.FirstOrDefault(e => e.Id == id);

            if (e == null)
            {
                // TODO: Better exception handling.
                throw new Exception("Invalid entity");
            }

            return e;
        }
    }
}
