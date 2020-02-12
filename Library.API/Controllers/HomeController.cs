using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Welcome to Web API, have a nice time!";
        }
    }
}
