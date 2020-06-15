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
    public class SynthesizerController : ControllerBase
    {
        private MagmaDbContext magmaDbContext;

        private ActionResult<Synthesizer> synthesizer;

        public SynthesizerController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        [HttpGet("{id}")]
        public ActionResult<Synthesizer> GetSynthesizerById(int id)
        {
            return synthesizer;
        }

        [HttpGet("plugin/{id}")]
        public ActionResult<Synthesizer> GetSynthesizerByPluginId(int pluginId)
        {
            return synthesizer;
        }

        [HttpPost]
        public ActionResult CreateSynthesizer(Synthesizer synthesizer)
        {
            return Ok("Success: created synthesizer");
        }

        [HttpPost("update")]
        public ActionResult UpdateSynthesizer(Synthesizer synthesizer)
        {
            return Ok("Success: updated synthesizer");
        }

        [HttpDelete]
        public ActionResult RemoveSynthesizer(Synthesizer synthesizer)
        {
            return Ok("Success: removed synthesizer");
        }
    }
}