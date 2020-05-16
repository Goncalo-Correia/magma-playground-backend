using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using Microsoft.AspNetCore.Mvc;

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class PluginController : ControllerBase
    {
        private MagmaDbContext magmaDbContext;

        private ActionResult<Plugin> plugin;
        private IQueryable<Plugin> queryablePlugin;

        public PluginController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        [HttpGet("{id}")]
        public ActionResult<Plugin> GetPluginById(int  id)
        {
            plugin = magmaDbContext.Find<Plugin>(id);

            return plugin;
        }

        [HttpGet("rack/{id}")]
        public IQueryable<Plugin> GetPluginsByRackId(int rackId)
        {
            queryablePlugin = magmaDbContext.Plugins.Where<Plugin>(prop => prop.rack.id == rackId);

            return queryablePlugin;
        }

        [HttpPost]
        public ActionResult CreatePlugin(Plugin plugin)
        {
            magmaDbContext.Add<Plugin>(plugin);
            magmaDbContext.SaveChanges();

            return Ok("Success: created plugin");
        }

        [HttpPost("update")]
        public ActionResult UpdatePlugin(Plugin plugin)
        {
            magmaDbContext.Update<Plugin>(plugin);
            magmaDbContext.SaveChanges();

            return Ok("Success: updated plugin");
        }

        [HttpDelete]
        public ActionResult RemovePlugin(Plugin plugin)
        {
            magmaDbContext.Remove<Plugin>(plugin);
            magmaDbContext.SaveChanges();

            return Ok("Success: removed plugin");
        }
    }
}