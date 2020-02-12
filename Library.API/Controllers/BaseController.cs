using Library.API.Models;
using Library.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private UnitOfWork _unit;
        private ModelFactory _factory;

        public UnitOfWork Unit => _unit ?? (_unit = new UnitOfWork());
        public ModelFactory Factory => _factory ?? (_factory = new ModelFactory());
    }
}