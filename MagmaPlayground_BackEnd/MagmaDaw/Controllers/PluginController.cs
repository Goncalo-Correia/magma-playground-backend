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
        private DawResponseFactory responseFactory;
        private DawResponse response;

        public PluginController(MagmaDawDbContext magmaDbContext)
        {
            pluginService = new PluginService(magmaDbContext);
            responseFactory = new DawResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetPluginById(int id)
        {
            response = new DawResponse();

            response = pluginService.GetPluginById(id);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpGet("rack/{rackId}")]
        public ActionResult<DawResponse> GetPluginsByRackId(int rackId)
        {
            response = new DawResponse();

            response = pluginService.GetPluginByRackId(rackId);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<DawResponse> CreatePlugin(Plugin plugin)
        {
            response = new DawResponse();

            response = pluginService.CreatePlugin(plugin);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> UpdatePlugin(Plugin plugin)
        {
            response = new DawResponse();

            response = pluginService.UpdatePlugin(plugin);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<DawResponse> DeletePlugin(int id)
        {
            response = new DawResponse();

            response = pluginService.DeletePlugin(id);

            return responseFactory.CreateControllerResponse(response);
        }
    }
}