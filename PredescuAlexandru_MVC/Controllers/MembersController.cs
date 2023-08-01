using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PredescuAlexandru_MVC.Models;
using PredescuAlexandru_MVC.Repositories;
using PredescuAlexandru_MVC.ViewModels;

namespace PredescuAlexandru_MVC.Controllers
{
    [Authorize(Roles = "ADMIN, USER")]
    public class MembersController : Controller
    {
        private readonly MembersRepository _membersRepository;
        private readonly IToastNotification _toastNotificatiopn;

        public MembersController(MembersRepository membersRepository, IToastNotification toastNotification)
        {
            _membersRepository = membersRepository;
            _toastNotificatiopn = toastNotification;
        }



        // GET: MembersController
        public ActionResult Index()
        {
            var members = _membersRepository.GetAllMembers();
            _toastNotificatiopn.AddInfoToastMessage("Se incarca toti membrii");
            return View(members);
        }

        // GET: MembersController/Details/5
        public ActionResult Details(Guid id)
        {
            var member = _membersRepository.GetMemberById(id);
            _toastNotificatiopn.AddInfoToastMessage("Membrul se incarca");
            return View(member);
        }

        // GET: MembersController/Create
        public ActionResult Create()
        {
            _toastNotificatiopn.AddSuccessToastMessage("Creaza un membru nou");
            return View();
        }

        // POST: MembersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MemberModel member)
        {
            try
            {
                _membersRepository.AddMember(member);
                _toastNotificatiopn.AddSuccessToastMessage("Membrul s-a adaugat cu succes");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _toastNotificatiopn.AddErrorToastMessage("A aparut o eroare la salvarea membrului");
                return View();
            }
        }

        // GET: MembersController/Edit/5
        public ActionResult Edit(Guid id)
        {
            MemberModel member = _membersRepository.GetMemberById(id);
            _toastNotificatiopn.AddSuccessToastMessage("Creaza un membru nou nou");
            return View(member);
        }

        // POST: MembersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, MemberModel member)
        {
            try
            {
                _membersRepository.UpdateMember(member);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MembersController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var member = _membersRepository.GetMemberById(id);
            _toastNotificatiopn.AddSuccessToastMessage("Sterge un membru");
            return View(member);
        }

        // POST: MembersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                if (_membersRepository.HasCodeSnippets(id))
                {
                    _toastNotificatiopn.AddErrorToastMessage("Membrul nu poate fi sters deoarece are cod adaugat !!!");
                }
                else
                {
                    _membersRepository.DeleteMember(id);
                    _toastNotificatiopn.AddErrorToastMessage("Membrul a fost sters");
                }
                //_membersRepository.DeleteMember(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DetailsWithCodeSnippets(Guid id)
        {
            MemberCodeSnippetsViewModel viewModel = _membersRepository.GetMemberCodeSnippets(id);

            return View(viewModel);
        }
    }
}
