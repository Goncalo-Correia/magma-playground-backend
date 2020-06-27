using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using MagmaPlayground_BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class AudioEffectController : ControllerBase
    {
        private AudioEffectService audioEffectService;
        private ControllerResponseFactory controllerResponseFactory;
        private Response response;

        public AudioEffectController(MagmaDbContext magmaDbContext)
        {
            audioEffectService = new AudioEffectService(magmaDbContext);
            controllerResponseFactory = new ControllerResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<Response> GetAudioEffectById(int id)
        {
            response = new Response();
            response = audioEffectService.GetAudioEffectById(id);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpGet("plugin/{id}")]
        public ActionResult<Response> GetAudioEffectByPluginId(int pluginId)
        {
            response = new Response();
            response = audioEffectService.GetAudioEffectsByPluginId(pluginId);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<Response> CreateAudioEffect(AudioEffect audioEffect)
        {
            response = new Response();
            response = audioEffectService.CreateAudioEffect(audioEffect);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<Response> UpdateAudioEffect(AudioEffect audioEffect)
        {
            response = new Response();
            response = audioEffectService.UpdateAudioEffect(audioEffect);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpDelete]
        public ActionResult<Response> DeleteAudioEffect(AudioEffect audioEffect)
        {
            response = new Response();
            response = audioEffectService.DeleteAudioEffect(audioEffect);

            return controllerResponseFactory.BuildControllerResponse(response);
        }
    }
}