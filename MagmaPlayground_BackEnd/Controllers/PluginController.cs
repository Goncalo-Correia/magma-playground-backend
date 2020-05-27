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
            if (id == 0)
            {
                return BadRequest("Error: input parameter is null");
            }

            plugin = magmaDbContext.Find<Plugin>(id);

            if (plugin == null)
            {
                return NotFound("Error: plugin not found");
            }

            return plugin;
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
                return BadRequest(ex.Message);
            }

            return plugins;
        }

        [HttpPost]
        public ActionResult CreatePlugin(Plugin plugin)
        {
            try
            {
                if (plugin == null)
                {
                    return BadRequest("Error: input parameter is null");
                }

                if (plugin.id != 0)
                {
                    return BadRequest("Error: plugin already exists, id must be null");
                }

                magmaDbContext.Add<Plugin>(plugin);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Success: created plugin");
        }

        [HttpPost("update")]
        public ActionResult UpdatePlugin(Plugin plugin)
        {
            try
            {
                if (plugin == null)
                {
                    return BadRequest("Error: input parameter is null");
                }

                if (plugin.id == 0)
                {
                    return BadRequest("Error: plugin id is null");
                }

                magmaDbContext.Update<Plugin>(plugin);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Success: updated plugin");
        }

        [HttpDelete]
        public ActionResult RemovePlugin(Plugin plugin)
        {
            try
            {
                if (plugin == null)
                {
                    return BadRequest("Error: input parameter is null");
                }

                if (plugin.id == 0)
                {
                    return BadRequest("Error: track id is null");
                }

                magmaDbContext.Remove<Plugin>(plugin);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Success: removed plugin");
        }
    }
}