using Gym.Domain.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Domain.AggregateModels.Member
{
    public interface IMemberRepository : IRepository<Member,Guid>
    {
    }
}
