using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class HomeController : ControllerBase
    {
        public MagmaDbContext magmaDbContext;

        public HomeController(MagmaDbContext magmaDbContext)
            => this.magmaDbContext = magmaDbContext;
        
        [HttpGet]
        public ActionResult Login()
        {
            return Ok("Success: get request");
        }
        
        [HttpPost]
        public ActionResult Register()
        {
            return Ok("Success: post request");
        }
    }
}
