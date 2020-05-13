using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using Microsoft.AspNetCore.Mvc;

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class UserController : ControllerBase
    {
        public MagmaDbContext magmaDbContext;
        public ActionResult<IEnumerable<User>> usersList;

        public UserController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            usersList = magmaDbContext.Users.ToList();

            return usersList;
        }

        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            magmaDbContext.Add<User>(user);
            magmaDbContext.SaveChanges();

            return Accepted();
        }
    }
}