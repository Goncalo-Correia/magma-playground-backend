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

        public SynthesizerController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        [HttpGet("{id}")]
        public ActionResult GetSynthesizerById(int id)
        {
            return null;
        }

        [HttpGet("plugin/{id}")]
        public ActionResult GetSynthesizerByPluginId(int pluginId)
        {
            return null;
        }

        [HttpPost]
        public ActionResult CreateSynthesizer(Synthesizer synthesizer)
        {
            return null;
        }

        [HttpPost("update")]
        public ActionResult UpdateSynthesizer(Synthesizer synthesizer)
        {
            return null;
        }

        [HttpDelete]
        public ActionResult RemoveSynthesizer(Synthesizer synthesizer)
        {
            return null;
        }
    }
}