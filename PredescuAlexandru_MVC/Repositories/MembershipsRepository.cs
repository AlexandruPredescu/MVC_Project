using Microsoft.EntityFrameworkCore;
using PredescuAlexandru_MVC.Data;
using PredescuAlexandru_MVC.Models;

namespace PredescuAlexandru_MVC.Repositories
{
    public class MembershipsRepository
    {
        private readonly ClubLibraDbContext _context;

        public MembershipsRepository (ClubLibraDbContext context)
        {
            _context = context;
        }

        public DbSet<MembershipModel> GetAllMembership()
        {
            return _context.Memberships;
        }

        public MembershipModel GetMembershipById(Guid id)
        {
            MembershipModel membership = _context.Memberships.FirstOrDefault(x => x.IdMembership == id);
            return membership;
        }

        public void AddMembership (MembershipModel membership)
        {
            membership.IdMembership = Guid.NewGuid();
            _context.Memberships.Add(membership);
            _context.SaveChanges();
        }

        public void UpdateMembership (MembershipModel membership)
        {
            _context.Memberships.Update(membership);
            _context.SaveChanges();
        }

        public void DeleteMembership (Guid id)
        {
            MembershipModel membership = GetMembershipById(id);
            _context.Memberships.Remove(membership);
            _context.SaveChanges();
        }
    }
}

