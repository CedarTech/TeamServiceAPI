using System;
using System.Linq;
using TeamServiceAPI.Models;

namespace TeamServiceAPI.Data
{
    public class SqlTeamRepository : ITeamRepository
    {
        private readonly TeamContext _context;
        public SqlTeamRepository(TeamContext context)
        {
            _context = context;
        }
        public void CreateTeam(Team team)
        {
            if (team == null) { throw new ArgumentNullException(nameof(team)); }
            _context.TeamItems.Add(team);
        }

        public void DeleteTeam(Team team)
        {
            if (team == null) { throw new ArgumentNullException(nameof(team)); }
            _context.TeamItems.Remove(team);
        }

        public Team GetTeamById(Guid id)
        {
            return _context.TeamItems.FirstOrDefault(p => p.ID == id);
        }

        public bool SaveChanges()
        {
            var result = _context.SaveChanges();
            return result > 0;
        }

        public void UpdateTeam(Team team)
        {
            //It's a placeholder, don't need to do anything when using EF.
        }
    }
}