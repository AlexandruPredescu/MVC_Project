using Microsoft.EntityFrameworkCore;
using PredescuAlexandru_MVC.Data;
using PredescuAlexandru_MVC.Models;

namespace PredescuAlexandru_MVC.Repositories
{
    public class CodeSnippetsRepository
    {
        private readonly ClubLibraDbContext _context;

        public CodeSnippetsRepository(ClubLibraDbContext context)
        {
            _context = context;
        }

        public DbSet<CodeSnippetModel> GetAllCodeSnippets()
        {
            return _context.CodeSnippets;
        }

        public void Delete(Guid idCodeSnipet)
        {
            var codeSnippet = _context.CodeSnippets.FirstOrDefault(x => x.IdCodeSnippet == idCodeSnipet);
            _context.CodeSnippets.Remove(codeSnippet);
            _context.SaveChanges();
        }

        public CodeSnippetModel GetCodeSnippetById(Guid id)
        {
            return _context.CodeSnippets.FirstOrDefault(x => x.IdCodeSnippet == id);
        }

        public void AddCodeSnippet(CodeSnippetModel codeSnippet)
        {
            codeSnippet.IdCodeSnippet = Guid.NewGuid();
            _context.CodeSnippets.Add(codeSnippet);
            _context.SaveChanges();
        }

        public void UpdateCodeSnippet(CodeSnippetModel codeSnippet)
        {
            _context.CodeSnippets.Update(codeSnippet);
            _context.SaveChanges();
        }

    }
}
