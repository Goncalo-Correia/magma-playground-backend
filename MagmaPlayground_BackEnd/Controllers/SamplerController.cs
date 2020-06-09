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
    public class SamplerController : ControllerBase
    {
        private MagmaDbContext magmaDbContext;

        private ActionResult<Sampler> sampler;

        public SamplerController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        [HttpGet("{id}")]
        public ActionResult<Sampler> GetSamplerById(int id)
        {
            return sampler;
        }

        [HttpGet("plugin/{id}")]
        public ActionResult<Sampler> GetSamplerByPluginId(int pluginId)
        {
            try
            {
                if (pluginId == 0)
                {
                    return BadRequest("Error: input parameter is null");
                }

                sampler = magmaDbContext.Samplers.Single<Sampler>(prop => prop.plugin.id == pluginId);

                if (sampler == null)
                {
                    return NotFound("Error: sampler not found for this plugin");
                }
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            return sampler;
        }

        [HttpPost]
        public ActionResult CreateSampler(Sampler sampler)
        {
            return Ok("Success: created sampler");
        }

        [HttpPost("update")]
        public ActionResult UpdateSampler(Sampler sampler)
        {
            return Ok("Success: updated sampler");
        }

        [HttpDelete]
        public ActionResult RemoveSampler(Sampler sampler)
        {
            return Ok("Success: removed sampler");
        }
    }
}