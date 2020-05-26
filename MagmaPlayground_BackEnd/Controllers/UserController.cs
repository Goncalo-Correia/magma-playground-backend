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
                return BadRequest(ex.Message);
            }
            
            return Ok(usersList);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            if (id == 0)
            {
                return BadRequest("Error: input parameter id is null");
            }

            user = magmaDbContext.Users.Find(id);

            if (user == null)
            {
                return NotFound("Error: user not found");
            }

            return Ok(user);
        }

        [HttpGet("email/{email}")]
        public ActionResult<User> GetUserByEmail(string email)
        {
            try
            {
                if (email == null)
                {
                    return BadRequest("Error: input parameter email is null");
                }

                singleUser = magmaDbContext.Users.Single<User>(prop => prop.email == email);

                if (singleUser == null)
                {
                    return NotFound("Error: user not found");
                }
            } 
            catch (ArgumentNullException ex) {
                return NotFound(ex.Message);

            } 
            catch (InvalidOperationException ex) {
                return BadRequest(ex.Message);

            }

            return singleUser;
        }

        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Error: input parameter user is null");
                }

                if (user.id != 0)
                {
                    return BadRequest("Error: user already exists, id must be null");
                }

                magmaDbContext.Add<User>(user);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Success: created user");
        }

        [HttpPost("update")]
        public ActionResult<User> UpdateUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Error: input parameter user is null");
                }

                if (user.id == 0)
                {
                    return BadRequest("Error: user id is null");
                }

                magmaDbContext.Update<User>(user);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Success: updated user");
        }

        [HttpDelete]
        public ActionResult RemoveUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Error: input parameter user is null");
                }

                if (user.id == 0)
                {
                    return BadRequest("Error: user id is null");
                }

                magmaDbContext.Remove<User>(user);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Success: removed user");
        }
    }
}