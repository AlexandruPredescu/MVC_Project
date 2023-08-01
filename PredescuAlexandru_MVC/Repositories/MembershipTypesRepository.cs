using Microsoft.EntityFrameworkCore;
using PredescuAlexandru_MVC.Data;
using PredescuAlexandru_MVC.Models;
using System.Linq;

namespace PredescuAlexandru_MVC.Repositories
{
    public class MembershipTypesRepository
    {
        private readonly ClubLibraDbContext _context;

        public MembershipTypesRepository(ClubLibraDbContext context)
        {
            _context = context;
        }

        public DbSet<MembershipTypeModel> GetAllMembershipTypes()
        {
            return _context.MembershipTypes;
        }

        public MembershipTypeModel GetMembershipTypeById(Guid id)
        {
            MembershipTypeModel membershipType = _context.MembershipTypes.FirstOrDefault(x => x.IdMembershipType == id);
            return membershipType;
        }

        public void AddMembershipTypes(MembershipTypeModel membershipType)
        {
            membershipType.IdMembershipType = Guid.NewGuid();
            _context.MembershipTypes.Add(membershipType);
            _context.SaveChanges();
        }

        public void UpdateMembershipType(MembershipTypeModel membershipType)
        {
            _context.MembershipTypes.Update(membershipType);
            _context.SaveChanges();
        }

        public void DeleteMembershipTypes(Guid id)
        {
            MembershipTypeModel membershipType = GetMembershipTypeById(id);
            _context.MembershipTypes.Remove(membershipType);
            _context.SaveChanges();
        }
    }
}
