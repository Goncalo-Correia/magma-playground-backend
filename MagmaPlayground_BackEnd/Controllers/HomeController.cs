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
        public ResponseFactory responseFactory;

        public HomeController(MagmaDbContext magmaDbContext)
        {
            homeService = new HomeService(magmaDbContext);
            responseFactory = new ResponseFactory();
        }
        
        [HttpPost("/login")]
        public ActionResult<Response> Login(User user)
        {
            response = new Response();

            response = homeService.Login(user.email, user.password);

            return responseFactory.CreateControllerResponse(response);
        }
        
        [HttpPost("/register")]
        public ActionResult<Response> Register(User registerUser)
        {
            response = new Response();

            response = homeService.Register(registerUser);

            return responseFactory.CreateControllerResponse(response);
        }
    }
}
