using Gym.API.Application.Auth;
using Gym.API.Application.Commands.MemberCommands;
using Gym.API.Application.Models.Requests.Member;
using Gym.API.Application.Queries.MembersQueries;
using Gym.API.Validators;
using Gym.Domain.AggregateModels.Member;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BasicAuth]
    public class GymController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly MemberValidator _validationRules;
        public GymController(IMediator mediator, MemberValidator validationRules)
        {
            _mediator = mediator;
            _validationRules = validationRules;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("members")]
        public async Task<IActionResult> GetMembers()
        {
            var command = new GetAllMembersQuery();
            var cmd = await _mediator.Send(command);
            if (cmd == null)
                return BadRequest();

            return Ok(cmd);
        }
        [HttpGet]
        [Route("members/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetMemberById(Guid id)
        {
            var command = new GetMemberByIdQuery(id);
            var cmd = await _mediator.Send(command);
            if (cmd == null)
                return BadRequest();

            return Ok(cmd);
        }

        [HttpPost]
        [Route("members")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateMember (MemberRequest request)
        {
            var command = new CreateMemberCommand(request.Name, request.Age, request.Email, request.Plan, request.Subscription);
            var validator = _validationRules.Validate(command);

            if (!validator.IsValid)
                return BadRequest(validator.Errors);

            var cmd = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetMemberById), new {cmd.Id}, cmd);
        }
        [HttpPut]
        [Route("members/{id}/update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRequest request)
        {
            var command = new UpdateCommand(id,request.Name, request.Age, request.Email);
            var cmd = await _mediator.Send(command);

            if (cmd == null)
                return BadRequest();

            return Ok(cmd);
        }

        [HttpPost]
        [Route("members/{id}/change_plan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangePlan(Guid id, [FromBody] ChangePlanRequest request)
        {
           var command = new ChangePlanCommand(id, request.Plan);
           var cmd = await _mediator.Send(command);

            if (!cmd)
                return BadRequest();

            return Ok();
        }

        [HttpPost]
        [Route("members/{id}/change_subscription")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangeSubscription (Guid id, [FromBody] ChangeSubscriptionRequest request)
        {
            var command = new ChangeSubscriptionCommand(id, request.Subscription);

            var cmd = await _mediator.Send(command);

            if (!cmd)
                return BadRequest();
            
            return Ok();
        }

        [HttpPost]
        [Route("members/{id}/disable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Disable(Guid id)
        {
            var command = new DisableCommand(id);

            var cmd = await _mediator.Send(command);

            if (!cmd)
                return BadRequest();

            return Ok();
        }

        [HttpPost]
        [Route("members/{id}/enable")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Enable(Guid id)
        {
            var command = new EnableCommand(id);

            var cmd = await _mediator.Send(command);
            if (!cmd)
                return BadRequest();
            
            return Ok();
        }
    }
}
