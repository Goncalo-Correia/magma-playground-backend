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
            if (id == 0)
            {
                return BadRequest("Error: input parameter id is null");
            }

            sampler = magmaDbContext.Find<Sampler>(id);

            if (sampler == null)
            {
                return NotFound("Error: track not found");
            }

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
            try
            {
                if (sampler == null)
                {
                    return BadRequest("Error: input parameter is null");
                }
                if (sampler.id != 0)
                {
                    return BadRequest("Error: sampler already exists, id must be null");
                }

                magmaDbContext.Add<Sampler>(sampler);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            return Ok("Success: created sampler");
        }

        [HttpPost("update")]
        public ActionResult UpdateSampler(Sampler sampler)
        {
            try
            {
                if (sampler == null)
                {
                    return BadRequest("Error: input parameter is null");
                }
                if (sampler.id == 0)
                {
                    return BadRequest("Error: sampler id is null");
                }

                magmaDbContext.Update<Sampler>(sampler);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            return Ok("Success: updated sampler");
        }

        [HttpDelete]
        public ActionResult RemoveSampler(Sampler sampler)
        {
            try
            {
                if (sampler == null)
                {
                    return BadRequest("Error: input parameter is null");
                }
                if (sampler.id == 0)
                {
                    return BadRequest("Error: sampler id is null");
                }

                magmaDbContext.Remove<Sampler>(sampler);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

            return Ok("Success: removed sampler");
        }
    }
}