using MagmaPlayground_BackEnd.MagmaDaw.Models;
using MagmaPlayground_BackEnd.MagmaDaw.Services;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaDaw.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class AudioEffectTypeController : ControllerBase
    {
        private AudioEffectTypeService audioEffectTypeService;
        private DawResponseFactory dawResponseFactory;

        public AudioEffectTypeController(MagmaDawDbContext magmaDbContext)
        {
            audioEffectTypeService = new AudioEffectTypeService(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetAudioEffectTypeById(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(audioEffectTypeService.GetAudioEffectTypeById(id));
        }

        [HttpGet("")]
        public ActionResult<DawResponse> GetAudioEffectTypes()
        {
            return dawResponseFactory.CreateDawControllerResponse(audioEffectTypeService.GetAudioEffectTypes());
        }

        [HttpPost]
        public ActionResult<DawResponse> CreateAudioEffectType(AudioEffectType audioEffectType)
        {
            return dawResponseFactory.CreateDawControllerResponse(audioEffectTypeService.CreateAudioEffectType(audioEffectType));
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> UpdateAudioEffectType(AudioEffectType audioEffectType)
        {
            return dawResponseFactory.CreateDawControllerResponse(audioEffectTypeService.UpdateAudioEffectType(audioEffectType));
        }

        [HttpDelete("{id}")]
        public ActionResult<DawResponse> DeleteAudioEffectType(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(audioEffectTypeService.DeleteAudioEffectType(id));
        }
    }
}
