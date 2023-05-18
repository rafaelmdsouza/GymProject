using Gym.Domain.AggregateModels.Member;
using MediatR;

namespace Gym.API.Application.Queries.MembersQueries
{
    public class GetMemberByIdQuery : IRequest<Member>
    {
        public GetMemberByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
