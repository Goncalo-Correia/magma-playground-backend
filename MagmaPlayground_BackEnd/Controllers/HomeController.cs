using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using MagmaPlayground_BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class HomeController : ControllerBase
    {
        private HomeService homeService;
        private Response response;
        public ActionResult<User> user;

        public HomeController(MagmaDbContext magmaDbContext)
        {
            homeService = new HomeService(magmaDbContext);
        }
        
        [HttpGet]
        public ActionResult<Response> Login(string email, string password)
        {
            response = new Response();
            response = homeService.Login(email, password);

            if(response.responseStatus == ResponseStatus.OK)
            {
                response.message = "Success: login valid";
                return Ok(response);
            }

            response.message = "Error: user not found";
            return NotFound(response);
        }
        
        [HttpPost]
        public ActionResult<Response> Register(User registerUser)
        {
            response = new Response();
            response = homeService.Register(registerUser);

            if(response.responseStatus == ResponseStatus.OK)
            {
                response.message = "Success: register valid";
                return Ok(response);
            }

            response.message = "Error: user already exists";
            return BadRequest(response);
        }
    }
}
