using Gym.API.Application.Models.Requests.Member;
using Gym.Domain.AggregateModels.Member;
using MediatR;

namespace Gym.API.Application.Commands.MemberCommands
{
    public class ChangePlanCommand : IRequest<bool>
    {
        public ChangePlanCommand(Guid id, GymPlan plan)
        {
            Id = id;
            Plan = plan;
        }
        public Guid Id { get; set; }
        public GymPlan Plan { get; set; }
    }
}
