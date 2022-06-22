using TEG.CodingChallenge.Domain.Entities;

namespace TEG.CodingChallenge.Business.Interface.Manager
{
    public interface IVenueManager
    {
        IEnumerable<Venue> Fetch();

        Venue GetById(int id);
    }
}
