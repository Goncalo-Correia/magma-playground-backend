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

        private ActionResult<AudioEffect> audioEffect;
        private IEnumerable<AudioEffect> audioEffects;

        public AudioEffectController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        [HttpGet("{id}")]
        public ActionResult<AudioEffect> GetAudioEffectById(int id)
        {
            audioEffect = magmaDbContext.Find<AudioEffect>(id);
            
            return audioEffect;
        }

        [HttpGet("plugin/{id}")]
        public IEnumerable<AudioEffect> GetAudioEffectByPluginId(int pluginId)
        {
            audioEffects = magmaDbContext.AudioEffects.Where<AudioEffect>(prop => prop.plugin.id == pluginId).ToList();

            return audioEffects;
        }

        [HttpPost]
        public ActionResult CreateAudioEffect(AudioEffect audioEffect)
        {
            magmaDbContext.Add<AudioEffect>(audioEffect);
            magmaDbContext.SaveChanges();

            return Ok("Success: created audio effect");
        }

        [HttpPost("update")]
        public ActionResult UpdateAudioEffect(AudioEffect audioEffect)
        {
            magmaDbContext.Update<AudioEffect>(audioEffect);
            magmaDbContext.SaveChanges();

            return Ok("Success: updated audio effect");
        }

        [HttpDelete]
        public ActionResult RemoveAudioEffect(AudioEffect audioEffect)
        {
            magmaDbContext.Remove<AudioEffect>(audioEffect);
            magmaDbContext.SaveChanges();

            return Ok("Success: removed audio effect");
        }
    }
}