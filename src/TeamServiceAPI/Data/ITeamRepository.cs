using System;
using TeamServiceAPI.Models;

namespace TeamServiceAPI.Data
{
    public interface ITeamRepository
    {
        Team GetTeamById(Guid id);
        bool SaveChanges();
        void CreateTeam(Team team);
    }
}