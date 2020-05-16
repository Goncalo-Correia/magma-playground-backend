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
    public class AudioEffectController : ControllerBase
    {
        private MagmaDbContext magmaDbContext;

        public AudioEffectController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        [HttpGet("{id}")]
        public ActionResult GetAudioEffectById(int id)
        {
            return null;
        }

        [HttpGet("plugin/{id}")]
        public ActionResult GetAudioEffectByPluginId(int pluginId)
        {
            return null;
        }

        [HttpPost]
        public ActionResult CreateAudioEffect(AudioEffect audioEffect)
        {
            return null;
        }

        [HttpPost("update")]
        public ActionResult UpdateAudioEffect(AudioEffect audioEffect)
        {
            return null;
        }

        [HttpDelete]
        public ActionResult RemoveAudioEffect(AudioEffect audioEffect)
        {
            return null;
        }
    }
}