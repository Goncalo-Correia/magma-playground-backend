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

        public SamplerController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        [HttpGet("{id}")]
        public ActionResult GetSamplerById(int id)
        {
            return null;
        }

        [HttpGet("plugin/{id}")]
        public ActionResult GetSamplerByPluginId(int pluginId)
        {
            return null;
        }

        [HttpPost]
        public ActionResult CreateSampler(Sampler sampler)
        {
            return null;
        }

        [HttpPost("update")]
        public ActionResult UpdateSampler(Sampler sampler)
        {
            return null;
        }

        [HttpDelete]
        public ActionResult RemoveSampler(Sampler sampler)
        {
            return null;
        }
    }
}