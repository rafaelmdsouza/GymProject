using AutoMapper;
using Gym.API.Application.Commands.MemberCommands;
using Gym.API.Application.Models.Requests.Member;
using Gym.Domain.AggregateModels.Member;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMediator _mediator;
        public GymController(IMemberRepository memberRepository, IMediator mediator)
        {
            _memberRepository = memberRepository;
            _mediator = mediator;

        }

        [HttpGet]
        [Route("members")]
        public async Task<IActionResult> GetMembers()
        {
            var cmd = await _memberRepository.GetAllAsync();
            return Ok(cmd);
        }
        [HttpGet]
        [Route("members/{id}")]
        public async Task<IActionResult> GetMemberById(Guid id)
        {
            var cmd = await _memberRepository.GetByIdAsync(id);
            return Ok(cmd);
        }

        [HttpPost]
        [Route("members")]
        public async Task<IActionResult> CreateMember (MemberRequest request)
        {
            var member = new Member(request.Name, request.Age, request.Email, request.Plan, request.Subscription);

            _memberRepository.Add(member);
            return CreatedAtAction(nameof(GetMemberById), new {member.Id}, member);
        }
        [HttpPut]
        [Route("members/{id}/update")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRequest request)
        {
            var command = new UpdateCommand(id,request.Name, request.Age, request.Email);

            var cmd = await _mediator.Send(command);
            return Ok(cmd);
        }

        [HttpPost]
        [Route("members/{id}/change_plan")]
        public async Task<IActionResult> ChangePlan(Guid id, [FromBody] ChangePlanRequest request)
        {
            var command = new ChangePlanCommand(id, request.Plan);

            var cmd = await _mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        [Route("members/{id}/change_subscription")]
        public async Task<IActionResult> ChangeSubscription (Guid id, [FromBody] ChangeSubscriptionRequest request)
        {
            var command = new ChangeSubscriptionCommand(id, request.Subscription);

            var cmd = await _mediator.Send(command);
            return Ok();
        }
    }
}
