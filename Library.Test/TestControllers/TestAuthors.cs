using Library.API.Controllers;
using Library.API.Models;
using Library.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Library.Test.TestControllers
{
    public class TestAuthors
    {
        static LibContext context;
        static IRepository<Author> authors;

        // initialize database
        public TestAuthors()
        {
            context = new TestContext();
            context.Seed();
            authors = new Repository<Author>(context);
        }

        [Fact(DisplayName = "Get all authors")]
        public void GetAll()
        {
            var controller = new AuthorsController();

            var response = controller.Get() as ObjectResult;
            var value = response.Value as List<AuthorModel>;

            Assert.Equal(200, response.StatusCode);
            Assert.Equal(3, value.Count);
        }

        [Fact(DisplayName = "Get author by id")]
        public void GetAuthor()
        {
            var controller = new AuthorsController();

            var response = controller.Get(3) as ObjectResult;
            var value = response.Value as AuthorModel;

            Assert.Equal(200, response.StatusCode);
            Assert.Equal(3, value.Id);
        }

        [Fact(DisplayName = "Get author by wrong id")]
        public void WrongId()
        {
            var controller = new AuthorsController();

            var response = controller.Get(333) as ObjectResult;

            Assert.Null(response);
        }
    }
}
