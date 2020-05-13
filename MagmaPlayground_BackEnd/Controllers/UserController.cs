﻿using System;
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

        private ActionResult<IEnumerable<User>> usersList;
        private ActionResult<User> user;

        public UserController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> getAllUsers()
        {
            usersList = magmaDbContext.Users.ToList();

            return usersList;
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            user = magmaDbContext.Users.Find(id);

            return user;
        }

        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            magmaDbContext.Add<User>(user);
            magmaDbContext.SaveChanges();

            return Ok("Success: created user");
        }

        [HttpPost("update")]
        public ActionResult<User> UpdateUser(User user)
        {
            magmaDbContext.Users.Update(user);
            magmaDbContext.SaveChanges();

            return Ok("Success: updated user");
        }
    }
}