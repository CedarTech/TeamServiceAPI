using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection.Metadata.Ecma335;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using TeamServiceAPI.Dtos;
using TeamServiceAPI.Controllers;
using TeamServiceAPI.Models;
using TeamServiceAPI.Data;
using Moq;
using AutoMapper;
using TeamServiceAPI.Profiles;

namespace TeamServiceAPI.Tests
{
    public class TeamsControllerTest : IDisposable
    {
        private Mock<ITeamRepository> mockRepo;
        private IMapper mapper;
        private MapperConfiguration configuration;
        private TeamProfile realTeamProfile;
        public TeamsControllerTest()
        {
            mockRepo = new Mock<ITeamRepository>();

            realTeamProfile = new TeamProfile();
            configuration = new MapperConfiguration(cfg => cfg.AddProfile(realTeamProfile));
            mapper = new Mapper(configuration);
        }

        public void Dispose()
        {
            mockRepo = null;
            realTeamProfile = null;
            configuration = null;
            mapper = null;
        }

        [Fact]
        public void GetAllTeams_ReturnsCorrectType_WhenDBHasResource()
        {
            var controller = new TeamsController(mockRepo.Object, mapper);

            var result = controller.GetAllTeams();

            Assert.IsType<ActionResult<IEnumerable<TeamReadDto>>>(result);
        }

        [Fact]
        public void GetAllTeams_Returns200OkResult_WhenDBHasResource()
        {
            var controller = new TeamsController(mockRepo.Object, mapper);
            var result = controller.GetAllTeams();
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetTeamById_Returns404NotFound_WhenNonExistentResourceIdSubmitted()
        {
            mockRepo.Setup(r => r.GetTeamById(Guid.NewGuid())).Returns(() => null);
            var controller = new TeamsController(mockRepo.Object, mapper);
            var result = controller.GetTeamById(Guid.NewGuid());
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetTeamById_ReturnsCorrectType_WhenExistentResourceIdSubmitted()
        {
            mockRepo.Setup(r => r.GetTeamById(Guid.NewGuid())).Returns(() => new Team { ID = Guid.NewGuid(), Name = "Fake Team", Members = new List<Member>() });

            var controller = new TeamsController(mockRepo.Object, mapper);
            var result = controller.GetTeamById(Guid.NewGuid());
            Assert.IsType<ActionResult<TeamReadDto>>(result);
        }

        [Fact]
        public void CreateTeam_Returns201Created_WhenValidObjectSubmitted()
        {
            mockRepo.Setup(r => r.SaveChanges()).Returns(true);
            var controller = new TeamsController(mockRepo.Object, mapper);
            var result = controller.CreateTeam(new TeamCreateDto { });
            Assert.IsType<CreatedAtRouteResult>(result.Result);
        }

        [Fact]
        public void CreateTeam_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        {
            mockRepo.Setup(r => r.SaveChanges()).Returns(true);
            var controller = new TeamsController(mockRepo.Object, mapper);
            var result = controller.CreateTeam(new TeamCreateDto { });
            Assert.IsType<ActionResult<TeamReadDto>>(result);
        }

    }

}