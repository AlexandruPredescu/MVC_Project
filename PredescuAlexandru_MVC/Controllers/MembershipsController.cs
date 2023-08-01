using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PredescuAlexandru_MVC.Models;
using PredescuAlexandru_MVC.Repositories;

namespace PredescuAlexandru_MVC.Controllers
{
    [Authorize(Roles = "ADMIN, USER")]
    public class MembershipsController : Controller
    {
        private readonly MembershipsRepository _membershipsRepository;
        private readonly MembersRepository _membersRepository;
        private readonly MembershipTypesRepository _membershipTypesRepository;
        private readonly IToastNotification _toastNotificatiopn;

        public MembershipsController(MembershipsRepository membershipRepository, MembersRepository membersRepository, MembershipTypesRepository membershipTypesRepository, IToastNotification toastNotification)
        {
            _membershipsRepository = membershipRepository;
            _membersRepository = membersRepository;
            _membershipTypesRepository = membershipTypesRepository;
            _toastNotificatiopn = toastNotification;
        }

        // GET: MembershipController
        public ActionResult Index()
        {
            var memberships = _membershipsRepository.GetAllMembership();
            _toastNotificatiopn.AddInfoToastMessage("Se incarca membership");
            return View(memberships);
        }

        // GET: MembershipController/Details/5
        public ActionResult Details(Guid id)
        {
            var membership = _membershipsRepository.GetMembershipById(id);
            _toastNotificatiopn.AddInfoToastMessage("Membership se incarca");
            return View(membership);
        }

        // GET: MembershipController/Create
        public ActionResult Create()
        {
            var members = _membersRepository.GetAllMembers();
            ViewBag.Members = members;
            var membership = _membershipTypesRepository.GetAllMembershipTypes();
            ViewBag.membershipTypes = membership;
            _toastNotificatiopn.AddSuccessToastMessage("Creaza un membership nou");
            return View();

        }

        // POST: MembershipController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MembershipModel membership)
        {
            try
            {
                _membershipsRepository.AddMembership(membership);
                _toastNotificatiopn.AddSuccessToastMessage("Membership s-a adaugat cu succes");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _toastNotificatiopn.AddErrorToastMessage("A aparut o eroare la salvarea membership");
                return View();
            }
        }

        // GET: MembershipController/Edit/5
        public ActionResult Edit(Guid id)
        {
            MembershipModel membership = _membershipsRepository.GetMembershipById(id);
            _toastNotificatiopn.AddSuccessToastMessage("Editeaza un membership");
            return View(membership);
        }

        // POST: MembershipController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, MembershipModel membership)
        {
            try
            {
                _membershipsRepository.UpdateMembership(membership);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MembershipController/Delete/5
        public ActionResult Delete(Guid id)
        {
            MembershipModel membership = _membershipsRepository.GetMembershipById(id);
            _toastNotificatiopn.AddSuccessToastMessage("Sterge un anunt");
            return View(membership);
        }

        // POST: MembershipController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _membershipsRepository.DeleteMembership(id);
                _toastNotificatiopn.AddSuccessToastMessage("Membership a fost sters");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
