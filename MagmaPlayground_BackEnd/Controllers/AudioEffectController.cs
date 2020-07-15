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
        private ResponseFactory responseFactory;
        private Response response;

        public AudioEffectController(MagmaDbContext magmaDbContext)
        {
            audioEffectService = new AudioEffectService(magmaDbContext);
            responseFactory = new ResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<Response> GetAudioEffectById(int id)
        {
            response = new Response();
            response = audioEffectService.GetAudioEffectById(id);

            return responseFactory.BuildControllerResponse(response);
        }

        [HttpGet("plugin/{pluginId}")]
        public ActionResult<Response> GetAudioEffectByPluginId(int pluginId)
        {
            response = new Response();
            response = audioEffectService.GetAudioEffectByPluginId(pluginId);

            return responseFactory.BuildControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<Response> CreateAudioEffect(AudioEffect audioEffect)
        {
            response = new Response();
            response = audioEffectService.CreateAudioEffect(audioEffect);

            return responseFactory.BuildControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<Response> UpdateAudioEffect(AudioEffect audioEffect)
        {
            response = new Response();
            response = audioEffectService.UpdateAudioEffect(audioEffect);

            return responseFactory.BuildControllerResponse(response);
        }

        [HttpDelete]
        public ActionResult<Response> DeleteAudioEffect(AudioEffect audioEffect)
        {
            response = new Response();
            response = audioEffectService.DeleteAudioEffect(audioEffect);

            return responseFactory.BuildControllerResponse(response);
        }
    }
}