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
        private DawResponse response;
        public DawResponseFactory responseFactory;

        public HomeController(MagmaDawDbContext magmaDbContext)
        {
            homeService = new HomeService(magmaDbContext);
            responseFactory = new DawResponseFactory();
        }
        
        [HttpPost("/login")]
        public ActionResult<DawResponse> Login(User user)
        {
            response = new DawResponse();

            response = homeService.Login(user.email, user.password);

            return responseFactory.CreateControllerResponse(response);
        }
        
        [HttpPost("/register")]
        public ActionResult<DawResponse> Register(User registerUser)
        {
            response = new DawResponse();

            response = homeService.Register(registerUser);

            return responseFactory.CreateControllerResponse(response);
        }
    }
}
