using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using MagmaPlayground_BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class PlaygroundController : ControllerBase
    {
        private PlaygroundService playgroundService;
        private DawResponseFactory responseFactory;
        private DawResponse response;

        public PlaygroundController(MagmaDawDbContext magmaDbContext)
        {
            playgroundService = new PlaygroundService(magmaDbContext);
            responseFactory = new DawResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetProjectById(int id)
        {
            response = new DawResponse();

            response = playgroundService.GetProjectById(id);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost("create")]
        public ActionResult<DawResponse> SaveNewProject(Project project)
        {
            response = new DawResponse();

            response = playgroundService.SaveNewProject(project);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> SaveProject(Project project)
        {
            response = new DawResponse();

            response = playgroundService.SaveProject(project);

            return responseFactory.CreateControllerResponse(response);
        }
    }
}