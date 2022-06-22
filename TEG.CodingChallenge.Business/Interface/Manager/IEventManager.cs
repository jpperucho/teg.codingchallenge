using TEG.CodingChallenge.Domain.Entities;

namespace TEG.CodingChallenge.Business.Interface.Manager
{
    public interface IEventManager
    {
        IEnumerable<Event> Fetch();

        Event GetById(int id);

        IEnumerable<Event> FetchByVenueId(int venueId);
    }
}
