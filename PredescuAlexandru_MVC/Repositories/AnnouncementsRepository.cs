using Microsoft.EntityFrameworkCore;
using PredescuAlexandru_MVC.Data;
using PredescuAlexandru_MVC.Models;
namespace PredescuAlexandru_MVC.Repositories
{
    // repositiry - clase care implementeaza operatile crud din baza de date
    public class AnnouncementsRepository
    {
        private readonly ClubLibraDbContext _context;
        public AnnouncementsRepository(ClubLibraDbContext context)
        {
            _context = context;
        }

        public DbSet<AnnouncementsModel> GetAllAnnoucements()
        {
            return _context.Announcements;
        }

        public void Delete(Guid IdAnnouncements)
        {
            var announcement = _context.Announcements.FirstOrDefault(x => x.IdAnnouncement == IdAnnouncements);
            if (announcement != null)
            {
                _context.Announcements.Remove(announcement);
                _context.SaveChanges();
            }
            // _context.Announcements.Remove(announcement);
            // _context.SaveChanges();
        }

        public AnnouncementsModel GetAnnouncementsById(Guid Id)
        {
            return _context.Announcements.FirstOrDefault(x => x.IdAnnouncement == Id);
        }

        public void AddAnnouncement(AnnouncementsModel announcement)
        {
            announcement.IdAnnouncement = Guid.NewGuid();

            _context.Announcements.Add(announcement);
            _context.SaveChanges();
        }

        public void UpdateAnnouncement(AnnouncementsModel announcement)
        {
            if (announcement != null)
            {
                //verificam daca exista in Db
                _context.Announcements.Update(announcement);
                _context.SaveChanges();
            }

        }
    }
}
