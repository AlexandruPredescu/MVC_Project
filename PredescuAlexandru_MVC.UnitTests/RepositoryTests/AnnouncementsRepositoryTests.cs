using NuGet.ContentModel;
using PredescuAlexandru_MVC.Data;
using PredescuAlexandru_MVC.Models;
using PredescuAlexandru_MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredescuAlexandru_MVC.UnitTests.RepositoryTests
{
    public class AnnouncementsRepositoryTests
    {
        private readonly AnnouncementsRepository _repository;
        private readonly ClubLibraDbContext _contextInMemory;

        public AnnouncementsRepositoryTests()
        {
            _contextInMemory =Helpers.DbContextHelper.GetDatabaseContext();
            _repository = new AnnouncementsRepository(_contextInMemory);
        }

        [Fact]
        public void DeleteAnnouncement_AnnoucementNotExists()
        {
            //Averrage
            Guid id = Guid.NewGuid();

            //Act
            _repository.Delete(id);
        }

        [Fact]
        public void DeleteAnnouncement_AnnoucementExists()
        {
            // Averrage -> voi crea un anunt fals
            Guid id = Guid.NewGuid();
            AnnouncementsModel myAnnoucement = new AnnouncementsModel
            {
                IdAnnouncement = id,
                ValidFrom = DateTime.Now,
                ValidTo = DateTime.Now,
                EventDate = DateTime.Now,
                Title = "Anuntul poate fi sters",
                Tags = "tags1",
                Text = "Anunt de text"
            };
            AnnouncementsModel dbAnnouncement = Helpers.DbContextHelper.AddAnnouncement(_contextInMemory, myAnnoucement);

            //Act 
            var resultBeforeDelete = _repository.GetAnnouncementsById(id);
            _repository.Delete(id);
            var resultAfterDelete = _repository.GetAnnouncementsById(id);



            //Assert
            Assert.NotNull(resultBeforeDelete);
            Assert.Null(resultAfterDelete);



        }
    }

}

