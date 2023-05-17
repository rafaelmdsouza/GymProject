using Gym.Domain.AggregateModels.Member;
using MediatR;

namespace Gym.API.Application.Commands.MemberCommands
{
    public class UpdateCommand : IRequest<Member>
    {
        public UpdateCommand(Guid id, string name, int age, string email)
        {
            Id = id;
            Name = name;
            Age = age;
            Email = email;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
