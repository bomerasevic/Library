using Library.API.Controllers;
using Library.API.Models;
using Library.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Library.Test.TestControllers
{
    public class TestBooks
    {

        static LibContext context;
        static IRepository<Book> books;

        // initialize database
        public TestBooks()
        {
            context = new TestContext();
            context.Seed();
            books = new Repository<Book>(context);
        }

        [Fact(DisplayName = "Get all books")]
        public void GetAll()
        {
            var controller = new BooksController();

            var response = controller.Get() as ObjectResult;
            var value = response.Value as List<BookModel>;

            Assert.Equal(200, response.StatusCode);
            Assert.Equal(4, value.Count);
        }

        [Fact(DisplayName = "Get book by id")]
        public void GetBook()
        {
            var controller = new BooksController();

            var response = controller.Get(3) as ObjectResult;
            var value = response.Value as BookModel;

            Assert.Equal(200, response.StatusCode);
            Assert.Equal(3, value.Id);
        }

        [Fact(DisplayName = "Get book by wrong id")]
        public void WrongId()
        {
            var controller = new BooksController();

            var response = controller.Get(33) as ObjectResult;

            Assert.Null(response);
        }

    }
}