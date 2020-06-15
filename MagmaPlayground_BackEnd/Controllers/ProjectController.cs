using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private MagmaDbContext magmaDbContext;

        private ActionResult<IEnumerable<Project>> projects;
        private ActionResult<Project> project;

        public ProjectController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        [HttpGet("{id}")]
        public ActionResult<Project> GetProjectById(int id)
        {
            return project;
        }

        [HttpGet("user/{id}")]
        public ActionResult<IEnumerable<Project>> GetProjectsByUserId(int userId)
        {
            return projects;
        }

        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            return Ok("Success: created project");
        }

        [HttpPost("update")]
        public ActionResult UpdateProject(Project project)
        {
            return Ok("Success: updated project");
        }

        [HttpDelete]
        public ActionResult RemoveProject(Project project)
        {
            return Ok("Success: removed user");
        }
    }
}
