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

        private ActionResult<Plugin> plugin;
        private ActionResult<IEnumerable<Plugin>> plugins;

        public PluginController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        [HttpGet("{id}")]
        public ActionResult<Plugin> GetPluginById(int id)
        {

        }

        [HttpGet("rack/{id}")]
        public ActionResult<IEnumerable<Plugin>> GetPluginsByRackId(int rackId)
        {
            try
            {
                if (rackId == 0)
                {
                    return BadRequest("Error: input parameter is null");
                }

                plugins = magmaDbContext.Plugins.Where<Plugin>(prop => prop.rack.id == rackId).ToList();

                if (plugins == null)
                {
                    return NotFound("Error: plugins not found for this rack");
                }
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            return plugins;
        }

        [HttpPost]
        public ActionResult CreatePlugin(Plugin plugin)
        {
            
        }

        [HttpPost("update")]
        public ActionResult UpdatePlugin(Plugin plugin)
        {

        }

        [HttpDelete]
        public ActionResult RemovePlugin(Plugin plugin)
        {
            
        }
    }
}