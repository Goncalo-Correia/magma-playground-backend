using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MagmaPlayground_BackEnd.Controllers
{
    [Route("magma_api/[controller]")]
    public class HomeController : Controller
    {

        public MagmaDbContext magmaDbContext;

        public HomeController(MagmaDbContext magmaDbContext)
            => this.magmaDbContext = magmaDbContext;

        [HttpGet]
        public IActionResult GetHome()
        {
            return Ok("Home controller: GET OK");
        }
        
        [HttpPost]
        public IActionResult PostHome()
        {
            return Ok("Home controller: POST Ok");
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = magmaDbContext.Users.ToList();

            return Ok(users);
        }

        [HttpPost]
        public IActionResult createUser()
        {
            var user = new User()
            {
                name = "joao",
                lastName = "rocha",
                email = "joao@email.com",
                password = "joaopassword",
            };

            magmaDbContext.Add(user);
            magmaDbContext.SaveChanges();

            return Ok("Created User");
        }
    }
}
