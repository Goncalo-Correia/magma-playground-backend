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
        private DawResponse response;
        private DawResponseFactory responseFactory;

        public ProjectController(MagmaDawDbContext magmaDbContext)
        {
            projectService = new ProjectService(magmaDbContext);
            responseFactory = new DawResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetProjectById(int id)
        {
            response = new DawResponse();

            response = projectService.GetProjectById(id);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpGet("user/{userId}")]
        public ActionResult<DawResponse> GetProjectsByUserId(int userId)
        {
            response = new DawResponse();

            response = projectService.GetProjectByUserId(userId);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<DawResponse> CreateProject(Project project)
        {
            response = new DawResponse();

            response = projectService.CreateProject(project);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> UpdateProject(Project project)
        {
            response = new DawResponse();

            response = projectService.UpdateProject(project);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<DawResponse> DeleteProject(int id)
        {
            response = new DawResponse();

            response = projectService.DeleteProject(id);

            return responseFactory.CreateControllerResponse(response);
        }
    }
}
