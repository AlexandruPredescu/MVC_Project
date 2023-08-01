using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore;
using PredescuAlexandru_MVC.Models;
using PredescuAlexandru_MVC.Repositories;

namespace PredescuAlexandru_MVC.Data
{
    public class ClubLibraDbContext : DbContext
    {
        public ClubLibraDbContext(DbContextOptions<ClubLibraDbContext> options) : base(options) { }


        public DbSet<AnnouncementsModel> Announcements { get; set; }
        public DbSet<MemberModel> Members { get; set; }
        public DbSet<MembershipModel> Memberships { get; set; }
        public DbSet<MembershipTypeModel> MembershipTypes { get; set; }
        public DbSet<CodeSnippetModel> CodeSnippets { get; set; }

    }
}

