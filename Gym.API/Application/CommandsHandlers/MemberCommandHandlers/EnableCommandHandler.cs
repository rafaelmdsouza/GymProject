using Gym.API.Application.Commands.MemberCommands;
using Gym.Domain.AggregateModels.Member;
using MediatR;

namespace Gym.API.Application.CommandsHandlers.MemberCommandHandlers
{
    public class EnableCommandHandler : IRequestHandler<EnableCommand, bool>
    {
        private readonly IMemberRepository _repository;
        public EnableCommandHandler(IMemberRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(EnableCommand request, CancellationToken cancellationToken)
        {
            var member = await _repository.GetByIdAsync(request.Id);
            member.Enable();

            _repository.Update(request.Id, member);

            return true;
        }
    }
}
