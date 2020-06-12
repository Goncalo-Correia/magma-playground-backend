using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class UserController : ControllerBase
    {
        private MagmaDbContext magmaDbContext;

        private ActionResult<IEnumerable<User>> usersList;
        private User singleUser;
        private ActionResult<User> user;

        public UserController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            /*
            try
            {
                usersList = magmaDbContext.Users.ToList();

                if (usersList == null)
                {
                    return NotFound("Error: users list is empty");
                }
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            */

            return usersList;
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            return user;
        }

        [HttpGet("email/{email}")]
        public ActionResult<User> GetUserByEmail(string email)
        {
            return singleUser;
        }

        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            return Ok("Success: created user");
        }

        [HttpPost("update")]
        public ActionResult<User> UpdateUser(User user)
        {
            return Ok("Success: updated user");
        }

        [HttpDelete]
        public ActionResult RemoveUser(User user)
        {
            return Ok("Success: removed user");
        }
    }
}