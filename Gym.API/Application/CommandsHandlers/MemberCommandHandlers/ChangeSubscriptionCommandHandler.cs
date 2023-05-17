using Gym.API.Application.Commands.MemberCommands;
using Gym.Domain.AggregateModels.Member;
using MediatR;

namespace Gym.API.Application.CommandsHandlers.MemberCommandHandlers
{
    public class ChangeSubscriptionCommandHandler : IRequestHandler<ChangeSubscriptionCommand, bool>
    {
        private readonly IMemberRepository _repository;
        public ChangeSubscriptionCommandHandler(IMemberRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(ChangeSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var member = await _repository.GetByIdAsync(request.Id);

            member.ChangeSubscription(request.Subscription);

            return true;
        }
    }
}
