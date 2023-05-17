using MediatR;

namespace Gym.API.Application.Commands.MemberCommands
{
    public class DisableCommand : IRequest<bool>
    {
        public DisableCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
