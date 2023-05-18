using Gym.Domain.AggregateModels.Member;
using MediatR;

namespace Gym.API.Application.Commands.MemberCommands
{
    public class CreateMemberCommand : IRequest<Member>
    {
        public CreateMemberCommand(string name, int age, string email, GymPlan plan, GymSubscription subscription)
        {
            Name = name;
            Age = age;
            Email = email;
            Plan = plan;
            Subscription = subscription;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public GymPlan Plan { get; set; }
        public GymSubscription Subscription { get; set; }   
    }
}
