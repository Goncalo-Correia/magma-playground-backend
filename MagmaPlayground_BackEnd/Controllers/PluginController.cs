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

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class PluginController : ControllerBase
    {
        private PluginService pluginService;
        private ResponseFactory responseFactory;
        private Response response;

        public PluginController(MagmaDbContext magmaDbContext)
        {
            pluginService = new PluginService(magmaDbContext);
            responseFactory = new ResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<Response> GetPluginById(int id)
        {
            response = new Response();
            response = pluginService.GetPluginById(id);

            return responseFactory.BuildControllerResponse(response);
        }

        [HttpGet("rack/{rackId}")]
        public ActionResult<Response> GetPluginsByRackId(int rackId)
        {
            response = new Response();
            response = pluginService.GetPluginByRackId(rackId);

            return responseFactory.BuildControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<Response> CreatePlugin(Plugin plugin)
        {
            response = new Response();
            response = pluginService.CreatePlugin(plugin);

            return responseFactory.BuildControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<Response> UpdatePlugin(Plugin plugin)
        {
            response = new Response();
            response = pluginService.UpdatePlugin(plugin);

            return responseFactory.BuildControllerResponse(response);
        }

        [HttpDelete]
        public ActionResult<Response> DeletePlugin(Plugin plugin)
        {
            response = new Response();
            response = pluginService.DeletePlugin(plugin);

            return responseFactory.BuildControllerResponse(response);
        }
    }
}