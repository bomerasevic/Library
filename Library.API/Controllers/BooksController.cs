using Library.API.Models;
using Library.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : BaseController
    {
        // get all books (returns models collection)
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Unit.Books.Get().Select(x => Factory.Create(x)).ToList());
        }

        // get book by id (returns model)
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Book book = Unit.Books.Get(id);
                if (book == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Factory.Create(book));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // get list of books with filter by title (returns just id and name e.g. MasterModel)
        [HttpGet("find/{filter}")]
        public IActionResult Get(string filter)
        {
            try
            {
                return Ok(Unit.Books.Get(x => x.Title.ToLower().Contains(filter.ToLower())).Select(x => new MasterModel { Id = x.Id, Name = x.Title }).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // insert data into books table using domain class book
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            try
            {
                book.Publisher = Unit.Publishers.Get(book.Publisher.Id);
                Unit.Books.Insert(book);
                Unit.Save();
                return Ok(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // update data in books table by id using domain class book
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Book book, int id)
        {
            try
            {
                book.Publisher = Unit.Publishers.Get(book.Publisher.Id);
                Unit.Books.Update(book, id);
                Unit.Save();
                return Ok(Factory.Create(book));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // delete book by id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Unit.Books.Delete(id);
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