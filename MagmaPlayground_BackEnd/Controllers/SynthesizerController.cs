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
    public class SynthesizerController : ControllerBase
    {
        private MagmaDbContext magmaDbContext;

        private ActionResult<Synthesizer> synthesizer;
        private IQueryable<Synthesizer> queryableSynthesizer;

        public SynthesizerController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        [HttpGet("{id}")]
        public ActionResult<Synthesizer> GetSynthesizerById(int id)
        {
            synthesizer = magmaDbContext.Find<Synthesizer>(id);

            return synthesizer;
        }

        [HttpGet("plugin/{id}")]
        public IQueryable<Synthesizer> GetSynthesizerByPluginId(int pluginId)
        {
            queryableSynthesizer = magmaDbContext.Synthesizers.Where<Synthesizer>(prop => prop.plugin.id == pluginId);

            return queryableSynthesizer;
        }

        [HttpPost]
        public ActionResult CreateSynthesizer(Synthesizer synthesizer)
        {
            magmaDbContext.Add<Synthesizer>(synthesizer);
            magmaDbContext.SaveChanges();

            return Ok("Success: created synthesizer");
        }

        [HttpPost("update")]
        public ActionResult UpdateSynthesizer(Synthesizer synthesizer)
        {
            magmaDbContext.Update<Synthesizer>(synthesizer);
            magmaDbContext.SaveChanges();

            return Ok("Success: updated synthesizer");
        }

        [HttpDelete]
        public ActionResult RemoveSynthesizer(Synthesizer synthesizer)
        {
            magmaDbContext.Remove<Synthesizer>(synthesizer);
            magmaDbContext.SaveChanges();

            return Ok("Success: removed synthesizer");
        }
    }
}