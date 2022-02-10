using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TeamServiceAPI.Data;
using TeamServiceAPI.Dtos;
using TeamServiceAPI.Models;

namespace TeamServiceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamRepository _repo;
        private readonly IMapper _mapper;

        public TeamsController(ITeamRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }

        [HttpGet]
        public ActionResult<IEnumerable<TeamReadDto>> GetAllTeams()
        {
            return Ok(new TeamReadDto[] { new TeamReadDto(), new TeamReadDto() });

        }

        [HttpGet("{id}")]
        public ActionResult<TeamReadDto> GetTeamById(Guid id)
        {
            var teamItem = _repo.GetTeamById(id);
            if (teamItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TeamReadDto>(teamItem));
        }

        [HttpPost]
        public ActionResult<TeamReadDto> CreateTeam(TeamCreateDto teamCreateDto)
        {
            var teamModel = _mapper.Map<Team>(teamCreateDto);
            _repo.CreateTeam(teamModel);
            var result = _repo.SaveChanges();
            if (result == false) { return StatusCode(500); }

            var TeamReadDto = _mapper.Map<TeamReadDto>(teamModel);

            return CreatedAtRoute(new { Id = TeamReadDto.ID }, TeamReadDto);
        }

        [HttpPut("{guid}")]
        public ActionResult UpdateTeam(Guid guid, TeamUpdateDto teamUpdateDto)
        {
            var teamModelFromRepo = _repo.GetTeamById(guid);
            if (teamModelFromRepo == null) { return NotFound(); }
            _mapper.Map(teamUpdateDto, teamModelFromRepo);
            _repo.UpdateTeam(teamModelFromRepo);//Placeholder for ORMs other than EF.
            var result = _repo.SaveChanges();

            if (!result) { return StatusCode(500); }
            return NoContent();
        }

        [HttpDelete("{guid}")]
        public ActionResult DeleteTeam(Guid guid)
        {
            var teamModelFromRepo = _repo.GetTeamById(guid);
            if (teamModelFromRepo == null) { return NotFound(); }
            _repo.DeleteTeam(teamModelFromRepo);
            _repo.SaveChanges();
            return NoContent();
        }
    }
}