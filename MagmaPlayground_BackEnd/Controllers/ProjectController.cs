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
        public ActionResult<Project> GetProject(int id)
        {
            project = magmaDbContext.Projects.Find(id);

            return project;
        }

        [HttpGet("user/{id}")]
        public ActionResult<IEnumerable<Project>> GetProjectsByUser(int id)
        {
            projects = magmaDbContext.Projects.Where<Project>(prop => prop.User.id == id).ToList<Project>();

            return projects;
        }
    }
}
