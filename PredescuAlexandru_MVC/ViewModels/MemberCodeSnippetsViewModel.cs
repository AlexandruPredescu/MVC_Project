using PredescuAlexandru_MVC.Models;

namespace PredescuAlexandru_MVC.ViewModels
{
    public class MemberCodeSnippetsViewModel
    {
        public string Name { get; set; }

        public string Position { get; set; }

        public List<CodeSnippetModel> CodeSnippetModels = new List<CodeSnippetModel>();
    }
}
