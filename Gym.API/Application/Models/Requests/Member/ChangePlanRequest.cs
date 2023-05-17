using Gym.Domain.AggregateModels.Member;

namespace Gym.API.Application.Models.Requests.Member
{
    public class ChangePlanRequest
    {
        public GymPlan Plan { get; set; }
    }
}