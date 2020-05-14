using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class HomeController : ControllerBase
    {
        public UserController userController;

        public MagmaDbContext magmaDbContext;
        public ActionResult<User> user;

        public HomeController(MagmaDbContext magmaDbContext)
        {
            userController = new UserController(magmaDbContext);
            this.magmaDbContext = magmaDbContext;
        }
            
        
        [HttpGet]
        public ActionResult Login(string email, string password)
        {
            user = userController.GetUserByEmail(email);
            if(user.Value.password == password)
            {
                return Ok("Success: login valid");
            }

            return NotFound("Error: user not found");
        }
        
        [HttpPost]
        public ActionResult Register(User registerUser)
        {
            user = userController.GetUserByEmail(registerUser.email);
            if(user.Value.id == 0)
            {
                userController.CreateUser(registerUser);

                return Ok("Success: register valid");
            }

            return BadRequest("Error: user already exists");
        }
    }
}
