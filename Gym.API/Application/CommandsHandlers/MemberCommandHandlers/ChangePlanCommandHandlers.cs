using Gym.API.Application.Commands.MemberCommands;
using Gym.API.Application.Models.Requests.Member;
using Gym.Domain.AggregateModels.Member;
using MediatR;

namespace Gym.API.Application.CommandsHandlers.MemberCommandHandlers
{
    public class ChangePlanCommandHandlers : IRequestHandler<ChangePlanCommand, bool>
    {
        private readonly IMemberRepository _memberRepository;
        public ChangePlanCommandHandlers(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public async Task<bool> Handle(ChangePlanCommand request, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetByIdAsync(request.Id);

            member.ChangePlan(request.Plan);

            _memberRepository.Update(request.Id, member);

            return true;

        }
    }
}
