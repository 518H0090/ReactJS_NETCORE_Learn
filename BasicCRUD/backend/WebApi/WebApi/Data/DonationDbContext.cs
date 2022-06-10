using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class DonationDbContext : DbContext
    {
        public DonationDbContext(DbContextOptions<DonationDbContext> options) : base(options)
        {

        }

        public DbSet<DCandidate> dCandidates { get; set; }

    }
}
