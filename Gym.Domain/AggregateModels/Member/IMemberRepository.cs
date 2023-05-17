using Gym.Domain.Core.Data;

namespace Gym.Domain.AggregateModels.Member
{
    public interface IMemberRepository : IRepository<Member,Guid>
    {
    }
}
