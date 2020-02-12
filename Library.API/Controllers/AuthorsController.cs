using Library.API.Models;
using Library.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : BaseController
    {
        // get all authors (returns collection of author models)
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Unit.Authors.Get().Select(x => Factory.Create(x)).ToList());
        }

        // get author by id (returns author model)
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Author author = Unit.Authors.Get(id);
                if (author == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Factory.Create(author));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // get list of authors with filter by name (returns just id and name e.g. MasterModel)
        [HttpGet("find/{filter}")]
        public IActionResult Get(string filter)
        {
            try
            {
                return Ok(Unit.Authors.Get(x => x.Name.ToLower().Contains(filter.ToLower())).Select(x => new MasterModel { Id = x.Id, Name = x.Name }).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // insert data into authors table using domain class author
        [HttpPost]
        public IActionResult Post([FromBody] Author author)
        {
            try
            {
                Unit.Authors.Insert(author);
                Unit.Save();
                return Ok(Factory.Create(author));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // update data in authors table by id using domain class author
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Author author, int id)
        {
            try
            {
                Unit.Authors.Update(author, id);
                Unit.Save();
                return Ok(Factory.Create(author));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // delete author by id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Unit.Authors.Delete(id);
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