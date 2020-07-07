using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private ControllerResponseFactory controllerResponseFactory;
        private Response response;

        public PlaygroundController(MagmaDbContext magmaDbContext)
        {
            playgroundService = new PlaygroundService(magmaDbContext);
            controllerResponseFactory = new ControllerResponseFactory();
        }

        [HttpGet("project/{id}")]
        public ActionResult<Response> GetCompleteProjectById(int id)
        {
            response = new Response();
            response = playgroundService.GetCompleteProjectById(id);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

    }
}