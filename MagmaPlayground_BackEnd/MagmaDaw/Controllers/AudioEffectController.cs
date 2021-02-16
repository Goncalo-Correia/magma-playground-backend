using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using MagmaPlayground_BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class AudioEffectController : ControllerBase
    {
        private AudioEffectService audioEffectService;
        private DawResponseFactory responseFactory;
        private DawResponse response;

        public AudioEffectController(MagmaDawDbContext magmaDbContext)
        {
            audioEffectService = new AudioEffectService(magmaDbContext);
            responseFactory = new DawResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetAudioEffectById(int id)
        {
            response = new DawResponse();

            response = audioEffectService.GetAudioEffectById(id);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpGet("plugin/{pluginId}")]
        public ActionResult<DawResponse> GetAudioEffectByPluginId(int pluginId)
        {
            response = new DawResponse();

            response = audioEffectService.GetAudioEffectByPluginId(pluginId);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<DawResponse> CreateAudioEffect(AudioEffect audioEffect)
        {
            response = new DawResponse();

            response = audioEffectService.CreateAudioEffect(audioEffect);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> UpdateAudioEffect(AudioEffect audioEffect)
        {
            response = new DawResponse();

            response = audioEffectService.UpdateAudioEffect(audioEffect);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<DawResponse> DeleteAudioEffect(int id)
        {
            response = new DawResponse();

            response = audioEffectService.DeleteAudioEffect(id);

            return responseFactory.CreateControllerResponse(response);
        }
    }
}