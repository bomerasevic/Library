using Library.API.Models;
using Library.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : BaseController
    {
        // get all publishers (return models collection)
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Unit.Publishers.Get().Select(x => Factory.Create(x)).ToList());
        }

        // get publisher by id (returns model)
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Publisher publisher = Unit.Publishers.Get(id);
                if(publisher == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(Factory.Create(publisher));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // get list of publishers with filter by name (returns just id and name e.g. MasterModel)
        [HttpGet("find/{filter}")]
        public IActionResult Get(string filter)
        {
            try
            {
                return Ok(Unit.Publishers.Get(x => x.Name.ToLower().Contains(filter.ToLower())).Select(x => new MasterModel { Id = x.Id, Name = x.Name }).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // insert data into publishers table using domain class publisher
        [HttpPost]
        public IActionResult Post([FromBody] Publisher publisher)
        {
            try
            {
                Unit.Publishers.Insert(publisher);
                Unit.Save();
                return Ok(Factory.Create(publisher));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // update data in publishers table by id using domain class publisher
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Publisher publisher, int id)
        {
            try
            {
                Unit.Publishers.Update(publisher, id);
                Unit.Save();
                return Ok(Factory.Create(publisher));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // delete publisher by id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Unit.Publishers.Delete(id);
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