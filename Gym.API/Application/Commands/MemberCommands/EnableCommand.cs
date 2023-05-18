using MediatR;

namespace Gym.API.Application.Commands.MemberCommands
{
    public class EnableCommand : IRequest<bool>
    {
        public EnableCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
