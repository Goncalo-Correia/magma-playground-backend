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
            if (id == 0)
            {
                return BadRequest("Error: input parameter is null");
            }

            audioEffect = magmaDbContext.Find<AudioEffect>(id);

            if (audioEffect == null)
            {
                return NotFound("Error: audio effect not found");
            }

            return audioEffect;
        }

        [HttpGet("plugin/{id}")]
        public ActionResult<IEnumerable<AudioEffect>> GetAudioEffectByPluginId(int pluginId)
        {
            try
            {
                if (pluginId == 0)
                {
                    return BadRequest("Error: id cannot be null");
                }

                audioEffects = magmaDbContext.AudioEffects.Where<AudioEffect>(prop => prop.plugin.id == pluginId).ToList();

                if (audioEffects == null)
                {
                    return NotFound("Error: audio effects not found for this plugin");
                }

            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

            return audioEffects;
        }

        [HttpPost]
        public ActionResult CreateAudioEffect(AudioEffect audioEffect)
        {
            try
            {
                if (audioEffect == null)
                {
                    return BadRequest("Error: input parameter is null");
                }
                if (audioEffect.id != 0)
                {
                    return BadRequest("Error: audio effect already exists, id must be null");
                }

                magmaDbContext.Add<AudioEffect>(audioEffect);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Success: created audio effect");
        }

        [HttpPost("update")]
        public ActionResult UpdateAudioEffect(AudioEffect audioEffect)
        {
            try
            {
                if (audioEffect == null)
                {
                    return BadRequest("Error: input parameter is null");
                }
                if (audioEffect.id == 0)
                {
                    return BadRequest("Error: audio effect id is null");
                }

                magmaDbContext.Update<AudioEffect>(audioEffect);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Success: updated audio effect");
        }

        [HttpDelete]
        public ActionResult RemoveAudioEffect(AudioEffect audioEffect)
        {
            try
            {
                if (audioEffect == null)
                {
                    return BadRequest("Error: input parameter is null");
                }
                if (audioEffect.id == 0)
                {
                    return BadRequest("Error: audio effect id is null");
                }

                magmaDbContext.Remove<AudioEffect>(audioEffect);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Success: removed audio effect");
        }
    }
}