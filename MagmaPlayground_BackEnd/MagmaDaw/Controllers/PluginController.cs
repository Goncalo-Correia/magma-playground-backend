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
        private DawResponseFactory dawResponseFactory;

        public PluginController(MagmaDawDbContext magmaDbContext)
        {
            pluginService = new PluginService(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetPluginById(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(pluginService.GetPluginById(id));
        }

        [HttpGet("rack/{rackId}")]
        public ActionResult<DawResponse> GetPluginsByRackId(int rackId)
        {
            return dawResponseFactory.CreateDawControllerResponse(pluginService.GetPluginByRackId(rackId));
        }

        [HttpPost]
        public ActionResult<DawResponse> CreatePlugin(Plugin plugin)
        {
            return dawResponseFactory.CreateDawControllerResponse(pluginService.CreatePlugin(plugin));
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> UpdatePlugin(Plugin plugin)
        {
            return dawResponseFactory.CreateDawControllerResponse(pluginService.UpdatePlugin(plugin));
        }

        [HttpDelete("{id}")]
        public ActionResult<DawResponse> DeletePlugin(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(pluginService.DeletePlugin(id));
        }
    }
}