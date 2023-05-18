using AutoMapper;
using Gym.API.Application.Models.Response.Member;
using Gym.API.Application.Queries.MembersQueries;
using Gym.Domain.AggregateModels.Member;
using MediatR;

namespace Gym.API.Application.QueriesHandlers.MemberHandlers
{
    public class GetAllMemberQueryHandler : IRequestHandler<GetAllMembersQuery, IReadOnlyList<MemberResponse>>
    {
        private readonly IMemberRepository _repository;
        private readonly IMapper _mapper;
        public GetAllMemberQueryHandler(IMemberRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<MemberResponse>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
        {
            var members = await _repository.GetAllAsync();
            var membersMapped = _mapper.Map<IReadOnlyList<MemberResponse>>(members);

            return membersMapped;
        }
    }
}
