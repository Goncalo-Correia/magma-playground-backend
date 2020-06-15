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
    public class AudioEffectController : ControllerBase
    {
        private MagmaDbContext magmaDbContext;

        private ActionResult<AudioEffect> audioEffect;
        private ActionResult<IEnumerable<AudioEffect>> audioEffects;

        public AudioEffectController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        [HttpGet("{id}")]
        public ActionResult<AudioEffect> GetAudioEffectById(int id)
        {
            return audioEffect;
        }

        [HttpGet("plugin/{id}")]
        public ActionResult<IEnumerable<AudioEffect>> GetAudioEffectByPluginId(int pluginId)
        {
            return audioEffects;
        }

        [HttpPost]
        public ActionResult CreateAudioEffect(AudioEffect audioEffect)
        {
            return Ok("Success: created audio effect");
        }

        [HttpPost("update")]
        public ActionResult UpdateAudioEffect(AudioEffect audioEffect)
        {
            return Ok("Success: updated audio effect");
        }

        [HttpDelete]
        public ActionResult RemoveAudioEffect(AudioEffect audioEffect)
        {
            return Ok("Success: removed audio effect");
        }
    }
}