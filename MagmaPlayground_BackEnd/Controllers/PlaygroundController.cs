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
        private ResponseFactory responseFactory;
        private Response response;

        public PlaygroundController(MagmaDbContext magmaDbContext)
        {
            playgroundService = new PlaygroundService(magmaDbContext);
            responseFactory = new ResponseFactory();
        }

        [HttpGet("project/{id}")]
        public ActionResult<Response> GetProjectById(int id)
        {
            response = new Response();
            response = playgroundService.GetProjectById(id);

            return responseFactory.BuildControllerResponse(response);
        }
    }
}