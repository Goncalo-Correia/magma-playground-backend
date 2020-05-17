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
        private IQueryable<Sampler> queryableSampler;

        public SamplerController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        [HttpGet("{id}")]
        public ActionResult<Sampler> GetSamplerById(int id)
        {
            sampler = magmaDbContext.Find<Sampler>(id);

            return sampler;
        }

        [HttpGet("plugin/{id}")]
        public IQueryable<Sampler> GetSamplerByPluginId(int pluginId)
        {
            queryableSampler = magmaDbContext.Samplers.Where(prop => prop.plugin.id == pluginId);

            return queryableSampler;
        }

        [HttpPost]
        public ActionResult CreateSampler(Sampler sampler)
        {
            magmaDbContext.Add<Sampler>(sampler);
            magmaDbContext.SaveChanges();

            return Ok("Success: created sampler");
        }

        [HttpPost("update")]
        public ActionResult UpdateSampler(Sampler sampler)
        {
            magmaDbContext.Update<Sampler>(sampler);
            magmaDbContext.SaveChanges();

            return Ok("Success: updated sampler");
        }

        [HttpDelete]
        public ActionResult RemoveSampler(Sampler sampler)
        {
            magmaDbContext.Remove<Sampler>(sampler);
            magmaDbContext.SaveChanges();

            return Ok("Success: removed sampler");
        }
    }
}