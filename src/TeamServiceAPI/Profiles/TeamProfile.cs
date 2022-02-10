using AutoMapper;
using TeamServiceAPI.Dtos;
using TeamServiceAPI.Models;

namespace TeamServiceAPI.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamReadDto>();
            CreateMap<TeamCreateDto, Team>();
        }

    }
}