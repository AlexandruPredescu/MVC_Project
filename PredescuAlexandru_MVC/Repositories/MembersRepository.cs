using Microsoft.EntityFrameworkCore;
using PredescuAlexandru_MVC.Data;
using PredescuAlexandru_MVC.Models;
using PredescuAlexandru_MVC.ViewModels;
using System.Runtime.InteropServices;

namespace PredescuAlexandru_MVC.Repositories
{
    public class MembersRepository
    {
        private readonly ClubLibraDbContext _context;

        public MembersRepository(ClubLibraDbContext context)
        {
            _context = context;
        }

        public DbSet<MemberModel> GetAllMembers()
        {
            return _context.Members;
        }

        public MemberModel GetMemberById(Guid id)
        {
            MemberModel member = _context.Members.FirstOrDefault(x => x.IdMember == id);
            return member;
        }


        public void AddMember(MemberModel member)

        {

            member.IdMember = Guid.NewGuid();
            _context.Members.Add(member);
            _context.SaveChanges();

        }

        public void UpdateMember(MemberModel member)

        {

            _context.Members.Update(member);
            _context.SaveChanges();

        }



        public void DeleteMember(Guid id)

        {

            MemberModel member = GetMemberById(id);
            _context.Members.Remove(member);
            _context.SaveChanges();

        }

        public MemberCodeSnippetsViewModel GetMemberCodeSnippets(Guid id)
        {
            MemberCodeSnippetsViewModel memberCodeSnippetsViewModel = new MemberCodeSnippetsViewModel();

            MemberModel member = GetMemberById(id);

            if (member != null)
            {
                memberCodeSnippetsViewModel.Name = member.Name;
                memberCodeSnippetsViewModel.Position = member.Position;

                memberCodeSnippetsViewModel.CodeSnippetModels = _context.CodeSnippets.Where(x => x.IdMember == member.IdMember).ToList();
            }
            return memberCodeSnippetsViewModel;
        }

        public bool HasCodeSnippets(Guid id)
        {
            return _context.CodeSnippets.Any(x => x.IdMember == id);
        }
    }
}

