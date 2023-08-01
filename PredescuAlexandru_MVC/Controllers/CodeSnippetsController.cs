using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PredescuAlexandru_MVC.Models;
using PredescuAlexandru_MVC.Repositories;
using System.Data;

namespace PredescuAlexandru_MVC.Controllers
{
    [Authorize(Roles = "ADMIN, USER")]
    public class CodeSnippetsController : Controller
    {
        private readonly CodeSnippetsRepository _repository;
        private readonly MembersRepository _membersRepository;
        private readonly IToastNotification _toastNotificatiopn;

        public CodeSnippetsController(CodeSnippetsRepository repository, MembersRepository membersRepository, IToastNotification toastNotification)
        {
            _repository = repository;
            _membersRepository = membersRepository;
            _toastNotificatiopn = toastNotification;
        }


        // GET: CodeSnippetsController
        public ActionResult Index()
        {
            var codeSnippets = _repository.GetAllCodeSnippets();
            _toastNotificatiopn.AddInfoToastMessage("Se incarca toate codurile");
            return View(codeSnippets);
        }

        // GET: CodeSnippetsController/Details/5
        public ActionResult Details(Guid id)
        {
            var codeSnippet = _repository.GetCodeSnippetById(id);
            _toastNotificatiopn.AddInfoToastMessage("Codul se incarca");
            return View(codeSnippet);
        }

        // GET: CodeSnippetsController/Create
        public ActionResult Create()
        {
            var members = _membersRepository.GetAllMembers();
            ViewBag.Members = members;
            _toastNotificatiopn.AddSuccessToastMessage("Creaza un cod nou");
            return View();
        }

        // POST: CodeSnippetsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
            try
            {
                TryUpdateModelAsync(codeSnippetModel);
                _repository.AddCodeSnippet(codeSnippetModel);
                _toastNotificatiopn.AddSuccessToastMessage("Codul s-a adaugat cu succes");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _toastNotificatiopn.AddErrorToastMessage("A aparut o eroare la salvarea codului");
                return View();
            }
        }

        // GET: CodeSnippetsController/Edit/5
        public ActionResult Edit(Guid id)
        {
            CodeSnippetModel codeSnippet = _repository.GetCodeSnippetById(id);
            _toastNotificatiopn.AddSuccessToastMessage("Editeaza un cod");
            return View(codeSnippet);
        }

        // POST: CodeSnippetsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection codeSnippet)
        {
            try
            {
                CodeSnippetModel codeSnippetModel = new CodeSnippetModel();
                TryUpdateModelAsync(codeSnippetModel);
                _repository.UpdateCodeSnippet(codeSnippetModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CodeSnippetsController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var codeSnippet = _repository.GetCodeSnippetById(id);
            _toastNotificatiopn.AddSuccessToastMessage("Sterge un cod");
            return View(codeSnippet);
        }

        // POST: CodeSnippetsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.Delete(id);
                _toastNotificatiopn.AddSuccessToastMessage("Codul a fost sters");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
