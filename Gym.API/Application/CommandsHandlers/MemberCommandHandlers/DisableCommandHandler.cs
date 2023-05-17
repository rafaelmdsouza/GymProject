using Gym.API.Application.Commands.MemberCommands;
using Gym.Domain.AggregateModels.Member;
using MediatR;

namespace Gym.API.Application.CommandsHandlers.MemberCommandHandlers
{
    public class DisableCommandHandler : IRequestHandler<DisableCommand, bool>
    {
        private readonly IMemberRepository _repository;
        public DisableCommandHandler(IMemberRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DisableCommand request, CancellationToken cancellationToken)
        {
            var member = await _repository.GetByIdAsync(request.Id);
            member.Disable();

            _repository.Update(request.Id, member);

            return true;
        }
    }
}
