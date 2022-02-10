using System;
using TeamServiceAPI.Models;

namespace TeamServiceAPI.Data
{
    public class SqlTeamRepository : ITeamRepository
    {
        public void CreateTeam(Team team)
        {
            if (team == null) { throw new ArgumentNullException(nameof(team)); }

        }

        public void DeleteTeam(Team team)
        {

        }

        public Team GetTeamById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateTeam(Team team)
        {
            //It's a placeholder, don't need to do anything when using EF.
        }
    }
}