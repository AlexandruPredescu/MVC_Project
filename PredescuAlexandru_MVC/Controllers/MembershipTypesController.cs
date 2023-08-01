using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PredescuAlexandru_MVC.Models;
using PredescuAlexandru_MVC.Repositories;

namespace PredescuAlexandru_MVC.Controllers
{
    [Authorize(Roles = "ADMIN, USER")]
    public class MembershipTypesController : Controller
    {
        private readonly MembershipTypesRepository _membershipTypesRepository;
        private readonly IToastNotification _toastNotificatiopn;

        public MembershipTypesController(MembershipTypesRepository membershipTypesRepository, IToastNotification toastNotification)
        {
            _membershipTypesRepository = membershipTypesRepository;
            _toastNotificatiopn = toastNotification;
        }



        // GET: MembershipTypesController
        public ActionResult Index()
        {
            var membershipTypes = _membershipTypesRepository.GetAllMembershipTypes();
            _toastNotificatiopn.AddInfoToastMessage("Se incarca toate anunturile");
            return View(membershipTypes);
        }

        // GET: MembershipTypesController/Details/5
        public ActionResult Details(Guid id)
        {
            var membershipTypes = _membershipTypesRepository.GetMembershipTypeById(id);
            _toastNotificatiopn.AddInfoToastMessage("Anuntul se incarca");
            return View(membershipTypes);
        }

        // GET: MembershipTypesController/Create
        public ActionResult Create()
        {
            _toastNotificatiopn.AddSuccessToastMessage("Creaza un aunt nou");
            return View();
        }

        // POST: MembershipTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MembershipTypeModel membershipType)
        {
            try
            {
                _membershipTypesRepository.AddMembershipTypes(membershipType);
                _toastNotificatiopn.AddSuccessToastMessage("Anuntul s-a adaugat cu succes");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                _toastNotificatiopn.AddErrorToastMessage("A aparut o eroare la salvarea anuntului");
                return View();
            }
        }

        // GET: MembershipTypesController/Edit/5
        public ActionResult Edit(Guid id)
        {
            MembershipTypeModel membershipType = _membershipTypesRepository.GetMembershipTypeById(id);
            _toastNotificatiopn.AddSuccessToastMessage("Editeaza un anunt");
            return View(membershipType);
        }

        // POST: MembershipTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, MembershipTypeModel membershipType)
        {
            try
            {
                _membershipTypesRepository.UpdateMembershipType(membershipType);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MembershipTypesController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var membershipType = _membershipTypesRepository.GetMembershipTypeById(id);
            _toastNotificatiopn.AddSuccessToastMessage("Sterge un anunt");
            return View(membershipType);
        }

        // POST: MembershipTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _membershipTypesRepository.DeleteMembershipTypes(id);
                _toastNotificatiopn.AddSuccessToastMessage("Anuntul a fost sters");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
