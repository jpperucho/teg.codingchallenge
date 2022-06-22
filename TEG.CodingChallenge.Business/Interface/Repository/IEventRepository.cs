using TEG.CodingChallenge.Domain.Entities;

namespace TEG.CodingChallenge.Business.Interface.Repository
{
    public interface IEventRepository
    {
        IEnumerable<Event> Events { get; }
    }
}
