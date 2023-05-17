using AutoMapper;
using Gym.API.Application.Models.Requests.Member;
using Gym.Domain.AggregateModels.Member;

namespace Gym.API.Application.Mappings
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles()
        {
            CreateMap<Member, MemberRequest>().ReverseMap();
        }
    }
}
