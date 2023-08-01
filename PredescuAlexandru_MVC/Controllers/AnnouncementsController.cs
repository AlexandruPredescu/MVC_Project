using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PredescuAlexandru_MVC.Models;
using PredescuAlexandru_MVC.Repositories;

namespace PredescuAlexandru_MVC.Controllers
{
    public class AnnouncementsController : Controller
    {

        private readonly AnnouncementsRepository _repository;
        private readonly IToastNotification _toastNotificatiopn;

        public AnnouncementsController(AnnouncementsRepository repository, IToastNotification toastNotification)
        {
            _repository = repository;
            _toastNotificatiopn = toastNotification;
        }
        // GET: AnnouncementsController
        public ActionResult Index()
        {

            var announcements = _repository.GetAllAnnoucements();
            _toastNotificatiopn.AddInfoToastMessage("Se incarca toate anunturile");
            return View(announcements);
        }

        // GET: AnnouncementsController/Details/5
        public ActionResult Details(Guid id)
        {
            var announcements = _repository.GetAnnouncementsById(id);
            _toastNotificatiopn.AddInfoToastMessage("Anuntul se incarca");
            return View(announcements);
        }

        // GET: AnnouncementsController/Create
        [Authorize(Roles = "ADMIN")]
        public ActionResult Create()
        {
            _toastNotificatiopn.AddSuccessToastMessage("Creaza un anunt nou");
            return View();
        }

        // POST: AnnouncementsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnnouncementsModel announcementsModel)
        {
            AnnouncementsModel model = new AnnouncementsModel();

            try
            {
                if (ModelState.IsValid)
                {
                    TryUpdateModelAsync(model);
                    _repository.AddAnnouncement(model);
                    _toastNotificatiopn.AddSuccessToastMessage("Anuntul s-a adaugat cu succes");
                    return RedirectToAction(nameof(Index));
                }
                /*TryUpdateModelAsync(announcementsModel);
                _repository.AddAnnouncement(announcementsModel);
                _toastNotificatiopn.AddSuccessToastMessage("Anuntul s-a adaugat cu succes");*/
                // return RedirectToAction(nameof(Index));
                return View(announcementsModel);
            }
            catch
            {
                _toastNotificatiopn.AddErrorToastMessage("A aparut o eroare la salvarea anuntului");
                return View();
            }
        }

        // GET: AnnouncementsController/Edit/5
        [Authorize(Roles = "ADMIN")]
        public ActionResult Edit(Guid id)
        {
            var announcement = _repository.GetAnnouncementsById(id);
            _toastNotificatiopn.AddSuccessToastMessage("Creaza un anunt nou");
            return View(announcement);
        }

        // POST: AnnouncementsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                AnnouncementsModel annoucementModel = new AnnouncementsModel();
                TryUpdateModelAsync(annoucementModel);
                _repository.UpdateAnnouncement(annoucementModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnnouncementsController/Delete/5
        [Authorize(Roles = "ADMIN")]
        public ActionResult Delete(Guid id)
        {
            var announcement = _repository.GetAnnouncementsById(id);
            _toastNotificatiopn.AddSuccessToastMessage("Sterge un anunt");
            return View(announcement);
        }

        // POST: AnnouncementsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.Delete(id);
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
