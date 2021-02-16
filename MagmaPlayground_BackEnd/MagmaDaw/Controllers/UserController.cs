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
        private DawResponse response;
        private DawResponseFactory responseFactory;

        public UserController(MagmaDawDbContext magmaDbContext)
        {
            userService = new UserService(magmaDbContext);
            responseFactory = new DawResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetUserById(int id)
        {
            response = new DawResponse();

            response = userService.GetUserById(id);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpGet("email/{email}")]
        public ActionResult<DawResponse> GetUserByEmail(string email)
        {
            response = new DawResponse();

            response = userService.GetUserByEmail(email);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<DawResponse> CreateUser(User user)
        {
            response = new DawResponse();

            response = userService.CreateUser(user);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> UpdateUser(User user)
        {
            response = new DawResponse();

            response = userService.UpdateUser(user);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<DawResponse> DeleteUser(int id)
        {
            response = new DawResponse();

            response = userService.DeleteUser(id);

            return responseFactory.CreateControllerResponse(response);
        }
    }
}