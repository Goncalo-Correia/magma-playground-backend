using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using MagmaPlayground_BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class UserController : ControllerBase
    {
        private UserService userService;
        private Response response;
        private ResponseFactory responseFactory;

        public UserController(MagmaDawDbContext magmaDbContext)
        {
            userService = new UserService(magmaDbContext);
            responseFactory = new ResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<Response> GetUserById(int id)
        {
            response = new Response();

            response = userService.GetUserById(id);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpGet("email/{email}")]
        public ActionResult<Response> GetUserByEmail(string email)
        {
            response = new Response();

            response = userService.GetUserByEmail(email);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<Response> CreateUser(User user)
        {
            response = new Response();

            response = userService.CreateUser(user);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<Response> UpdateUser(User user)
        {
            response = new Response();

            response = userService.UpdateUser(user);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response> DeleteUser(int id)
        {
            response = new Response();

            response = userService.DeleteUser(id);

            return responseFactory.CreateControllerResponse(response);
        }
    }
}