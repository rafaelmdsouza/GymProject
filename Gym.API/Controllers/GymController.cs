using Gym.Domain.AggregateModels.Member;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;
        public GymController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
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
    }
}
