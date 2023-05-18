using Gym.API.Application.Models.Response.Member;
using MediatR;

namespace Gym.API.Application.Queries.MembersQueries
{
    public class GetAllMembersQuery : IRequest<IReadOnlyList<MemberResponse>>
    {
    }
}
