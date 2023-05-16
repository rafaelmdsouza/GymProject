using Gym.Domain.AggregateModels.Member;

namespace Gym.API.Application.Models.Response.Member
{
    public class MemberResponse
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public GymPlan Plan { get; set; }
        public GymSubscription Subscription { get; set; }
        public Guid? TrainerId { get; set; }
        public DateTime SubscriptionExpirationDate { get; set; }

    }
}
