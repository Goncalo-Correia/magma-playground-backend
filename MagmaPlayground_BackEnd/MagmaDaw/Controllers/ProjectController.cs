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
        private DawResponseFactory dawResponseFactory;

        public ProjectController(MagmaDawDbContext magmaDbContext)
        {
            projectService = new ProjectService(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetProjectById(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(projectService.GetProjectById(id));
        }

        [HttpPost]
        public ActionResult<DawResponse> CreateProject(Project project)
        {
            return dawResponseFactory.CreateDawControllerResponse(projectService.CreateProject(project));
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> UpdateProject(Project project)
        {
            return dawResponseFactory.CreateDawControllerResponse(projectService.UpdateProject(project));
        }

        [HttpDelete("{id}")]
        public ActionResult<DawResponse> DeleteProject(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(projectService.DeleteProject(id));
        }
    }
}
