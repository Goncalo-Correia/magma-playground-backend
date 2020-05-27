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
            if (id == 0)
            {
                return BadRequest("Error: input parameter id is null");
            }

            project = magmaDbContext.Projects.Find(id);

            if (project == null)
            {
                return NotFound("Error: project not found");
            }

            return project;
        }

        [HttpGet("user/{id}")]
        public ActionResult<IEnumerable<Project>> GetProjectsByUserId(int userId)
        {
            try
            {
                if (userId == 0)
                {
                    return BadRequest("Error: input parameter userId is null");
                }

                projects = magmaDbContext.Projects.Where<Project>(prop => prop.userId == userId).ToList<Project>();

                if (projects == null)
                {
                    return NotFound("Error: projects not found for this user");
                }
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

            return projects;
        }

        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    return BadRequest("Error: input parameter is null");
                }

                if (project.id != 0)
                {
                    return BadRequest("Error: project already exists, id must be null");
                }

                magmaDbContext.Add<Project>(project);
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

            return Ok("Success: created project");
        }

        [HttpPost("update")]
        public ActionResult UpdateProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    return BadRequest("Error: input parameter is null");
                }

                if (project.id == 0)
                {
                    return BadRequest("Error: project id is null");
                }

                magmaDbContext.Update<Project>(project);
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

            return Ok("Success: updated project");
        }

        [HttpDelete]
        public ActionResult RemoveProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    return BadRequest("Error: input parameter is null");
                }

                if (project.id == 0)
                {
                    return BadRequest("Error: project id is null");
                }

                magmaDbContext.Remove<Project>(project);
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
