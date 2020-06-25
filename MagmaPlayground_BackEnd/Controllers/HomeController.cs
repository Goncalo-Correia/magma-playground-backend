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
        public ControllerResponseFactory controllerResponseFactory;

        public HomeController(MagmaDbContext magmaDbContext)
        {
            homeService = new HomeService(magmaDbContext);
            controllerResponseFactory = new ControllerResponseFactory();
        }
        
        [HttpGet]
        public ActionResult<Response> Login(string email, string password)
        {
            response = new Response();
            response = homeService.Login(email, password);

            return controllerResponseFactory.BuildControllerResponse(response);
        }
        
        [HttpPost]
        public ActionResult<Response> Register(User registerUser)
        {
            response = new Response();
            response = homeService.Register(registerUser);

            return controllerResponseFactory.BuildControllerResponse(response);
        }
    }
}
