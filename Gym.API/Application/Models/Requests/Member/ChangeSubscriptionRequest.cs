using Gym.Domain.AggregateModels.Member;

namespace Gym.API.Application.Models.Requests.Member
{
    public class ChangeSubscriptionRequest
    {
        public GymSubscription Subscription { get; set; }
    }
}
