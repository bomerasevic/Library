using Library.DAL;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthBooksController : BaseController
    {
        [HttpPost]
        public IActionResult Post([FromBody] AuthBooks authBooks)
        {
            try
            {
                authBooks.Author = Unit.Authors.Get(authBooks.Author.Id);
                authBooks.Book = Unit.Books.Get(authBooks.Book.Id);
                Unit.AuthBooks.Insert(authBooks);
                Unit.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                Unit.AuthBooks.Delete(id);
                Unit.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}