using Microsoft.EntityFrameworkCore;
using PredescuAlexandru_MVC.Data;
using PredescuAlexandru_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredescuAlexandru_MVC.UnitTests.Helpers
{
    internal class DbContextHelper
    {
        public static ClubLibraDbContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ClubLibraDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())  //configurare si utilizarea unei baze de date in memorie
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;

            var databaseContext = new ClubLibraDbContext(options);
            databaseContext.Database.EnsureCreated();
            return databaseContext;
        }

        public static AnnouncementsModel AddAnnouncement(ClubLibraDbContext dbContext, AnnouncementsModel model)
        {
            dbContext.Add(model);
            dbContext.SaveChanges();
            dbContext.Entry(model).State = EntityState.Detached;
            return model;
        }
    }
    
}
