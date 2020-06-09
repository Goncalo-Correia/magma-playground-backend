using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class PluginController : ControllerBase
    {
        private MagmaDbContext magmaDbContext;

        private ActionResult response;
        private ActionResult<Plugin> plugin;
        private ActionResult<IEnumerable<Plugin>> plugins;

        public PluginController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        [HttpGet("{id}")]
        public ActionResult<Plugin> GetPluginById(int id)
        {
            return plugin;
        }

        [HttpGet("rack/{id}")]
        public ActionResult<IEnumerable<Plugin>> GetPluginsByRackId(int rackId)
        {
            return plugins;
        }

        [HttpPost]
        public ActionResult CreatePlugin(Plugin plugin)
        {
            return response;
        }

        [HttpPost("update")]
        public ActionResult UpdatePlugin(Plugin plugin)
        {
            return response;
        }

        [HttpDelete]
        public ActionResult RemovePlugin(Plugin plugin)
        {
            return response;
        }
    }
}