using TEG.CodingChallenge.Business.Interface.Manager;
using TEG.CodingChallenge.Business.Interface.Repository;
using TEG.CodingChallenge.Domain.Entities;

namespace TEG.CodingChallenge.Business.Manager
{
    /// <summary>
    /// Venue manager.
    /// </summary>
    public class VenueManager : IVenueManager
    {
        private readonly IVenueRepository _venueRepository;
        
        /// <summary>
        /// cTor.
        /// </summary>
        /// <param name="venueRepository"></param>
        public VenueManager(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
        }

        /// <summary>
        /// Fetch.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Venue> Fetch()
        {
            return _venueRepository.Venues.OrderBy(v => v.Name);
        }

        /// <summary>
        /// Get by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Venue GetById(int id)
        {
            var venue = _venueRepository.Venues.FirstOrDefault(v => v.Id == id);

            if(venue == null)
            {
                // TODO: Better exception handling.
                throw new Exception("Invalid entity.");
            }

            return venue;
        }
    }
}
