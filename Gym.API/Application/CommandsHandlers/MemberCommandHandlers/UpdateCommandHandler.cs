using Gym.API.Application.Commands.MemberCommands;
using Gym.Domain.AggregateModels.Member;
using MediatR;

namespace Gym.API.Application.CommandsHandlers.MemberCommandHandlers
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, Member>
    {
        private readonly IMemberRepository _repository;
        public UpdateCommandHandler(IMemberRepository repository)
        {
            _repository = repository;
        }
        public async Task<Member> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var member = await _repository.GetByIdAsync(request.Id);

            member.Update(request.Name, request.Age, request.Email);

            _repository.Update(request.Id, member);

            return member;
        }
    }
}
