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
using Microsoft.VisualBasic.CompilerServices;

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private ProjectService projectService;
        private Response response;
        private ControllerResponseFactory controllerResponseFactory;

        public ProjectController(MagmaDbContext magmaDbContext)
        {
            projectService = new ProjectService(magmaDbContext);
            controllerResponseFactory = new ControllerResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<Response> GetProjectById(int id)
        {
            response = new Response();
            response = projectService.GetProjectById(id);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpGet("user/{id}")]
        public ActionResult<Response> GetProjectsByUserId(int userId)
        {
            response = new Response();
            response = projectService.GetProjectByUserId(userId);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<Response> CreateProject(Project project)
        {
            response = new Response();
            response = projectService.CreateProject(project);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<Response> UpdateProject(Project project)
        {
            response = new Response();
            response = projectService.UpdateProject(project);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpDelete]
        public ActionResult<Response> DeleteProject(Project project)
        {
            response = new Response();
            response = projectService.DeleteProject(project);

            return controllerResponseFactory.BuildControllerResponse(response);
        }
    }
}
