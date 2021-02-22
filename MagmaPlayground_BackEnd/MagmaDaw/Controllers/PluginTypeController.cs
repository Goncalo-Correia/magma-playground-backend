using MagmaPlayground_BackEnd.MagmaDaw.Models;
using MagmaPlayground_BackEnd.MagmaDaw.Services;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaDaw.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class PluginTypeController : ControllerBase
    {
        private PluginTypeService pluginTypeService;
        private DawResponseFactory dawResponseFactory;

        public PluginTypeController(MagmaDawDbContext magmaDbContext)
        {
            pluginTypeService = new PluginTypeService(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetPluginTypeById(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(pluginTypeService.GetPluginTypeById(id));
        }

        [HttpGet("")]
        public ActionResult<DawResponse> GetPluginTypes()
        {
            return dawResponseFactory.CreateDawControllerResponse(pluginTypeService.GetPluginTypes());
        }

        [HttpPost]
        public ActionResult<DawResponse> CreatePluginType(PluginType pluginType)
        {
            return dawResponseFactory.CreateDawControllerResponse(pluginTypeService.CreatePluginType(pluginType));
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> UpdatePluginType(PluginType pluginType)
        {
            return dawResponseFactory.CreateDawControllerResponse(pluginTypeService.UpdatePluginType(pluginType));
        }

        [HttpDelete("{id}")]
        public ActionResult<DawResponse> DeletePluginType(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(pluginTypeService.DeletePluginType(id));
        }
    }
}
