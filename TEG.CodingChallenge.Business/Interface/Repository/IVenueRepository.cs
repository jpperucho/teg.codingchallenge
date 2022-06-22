using TEG.CodingChallenge.Domain.Entities;

namespace TEG.CodingChallenge.Business.Interface.Repository
{
    public interface IVenueRepository
    {
        IEnumerable<Venue> Venues { get; }
    }
}
