using Gym.Domain.AggregateModels.Member;
using MediatR;

namespace Gym.API.Application.Commands.MemberCommands
{
    public class ChangeSubscriptionCommand : IRequest<bool>
    {
        public ChangeSubscriptionCommand(Guid id, GymSubscription subscription)
        {
            Id = id;
            Subscription = subscription;
        }
        public Guid Id { get; set; }
        public GymSubscription Subscription { get;set ;}
    }
}
