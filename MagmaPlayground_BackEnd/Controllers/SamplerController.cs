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