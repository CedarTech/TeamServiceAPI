using Microsoft.EntityFrameworkCore;
using TeamServiceAPI.Models;

namespace TeamServiceAPI.Data
{
    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options) : base(options) { }
        public DbSet<Team> TeamItems { get; set; }
    }
}