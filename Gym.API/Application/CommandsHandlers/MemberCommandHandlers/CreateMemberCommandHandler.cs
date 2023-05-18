using Gym.API.Application.Commands.MemberCommands;
using Gym.API.Application.Models.Requests.Member;
using Gym.Domain.AggregateModels.Member;
using MediatR;

namespace Gym.API.Application.CommandsHandlers.MemberCommandHandlers
{
    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Member>
    {
        private readonly IMemberRepository _repository;
        public CreateMemberCommandHandler(IMemberRepository repository)
        {
            _repository = repository;
        }
        public async Task<Member> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var newMember = new Member(request.Name, request.Age, request.Email, request.Plan, request.Subscription);

            _repository.Add(newMember);

            return newMember;
        }
    }
}
