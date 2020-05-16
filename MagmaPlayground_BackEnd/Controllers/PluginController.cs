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

        public PluginController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        [HttpGet("{id}")]
        public ActionResult GetPluginById(int  id)
        {
            return null;
        }

        [HttpGet("rack/{id}")]
        public ActionResult GetPluginsByRackId(int rackId)
        {
            return null;
        }

        [HttpPost]
        public ActionResult CreatePlugin(Plugin plugin)
        {
            return null;
        }

        [HttpPost("update")]
        public ActionResult UpdatePlugin(Plugin plugin)
        {
            return null;
        }

        [HttpDelete]
        public ActionResult RemovePlugin(Plugin plugin)
        {
            return null;
        }
    }
}