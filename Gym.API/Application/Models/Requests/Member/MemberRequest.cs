using Gym.Domain.AggregateModels.Member;

namespace Gym.API.Application.Models.Requests.Member
{
    public class MemberRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public GymPlan Plan { get; set; }
        public GymSubscription Subscription { get; set; }
    }
}
