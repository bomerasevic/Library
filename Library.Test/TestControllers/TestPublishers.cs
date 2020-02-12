using Library.API.Controllers;
using Library.API.Models;
using Library.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace Library.Test.TestControllers
{
    public class TestPublishers
    {
        static LibContext context;
        static IRepository<Publisher> publishers;

        // initialize database
        public TestPublishers()
        {
            context = new TestContext();
            context.Seed();
            publishers = new Repository<Publisher>(context);
        }

        [Fact(DisplayName = "Get all publishers")]
        public void GetAll()
        {
            var controller = new PublishersController();
            var response = controller.Get() as ObjectResult;
            var value = response.Value as List<PublisherModel>;
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(2, value.Count);
        }

        [Fact(DisplayName = "Get publisher by id")]
        public void GetPublisher()
        {
            var controller = new PublishersController();
            var response = controller.Get(2) as ObjectResult;
            var value = response.Value as PublisherModel;
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(2, value.Id);
        }

        [Fact(DisplayName = "Get publisher by wrong id")]
        public void WrongId()
        {
            var controller = new PublishersController();
            var response = controller.Get(33) as ObjectResult;
            Assert.Null(response);
        }
    }
}