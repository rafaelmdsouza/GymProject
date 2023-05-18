using Gym.API.Application.Queries.MembersQueries;
using Gym.Domain.AggregateModels.Member;
using MediatR;

namespace Gym.API.Application.QueriesHandlers.MemberHandlers
{
    public class GetMemberByIdQueryHandler : IRequestHandler<GetMemberByIdQuery, Member>
    {
        private readonly IMemberRepository _repository;
        public GetMemberByIdQueryHandler(IMemberRepository repository)
        {
            _repository = repository;
        }
        public async Task<Member> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        {
            var member = await _repository.GetByIdAsync(request.Id);

            return member;
        }
    }
}
