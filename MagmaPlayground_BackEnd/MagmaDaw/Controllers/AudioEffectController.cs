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
        private DawResponseFactory dawResponseFactory;

        public AudioEffectController(MagmaDawDbContext magmaDbContext)
        {
            audioEffectService = new AudioEffectService(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetAudioEffectById(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(audioEffectService.GetAudioEffectById(id));
        }

        [HttpGet("plugin/{pluginId}")]
        public ActionResult<DawResponse> GetAudioEffectByPluginId(int pluginId)
        {
            return dawResponseFactory.CreateDawControllerResponse(audioEffectService.GetAudioEffectByPluginId(pluginId));
        }

        [HttpPost]
        public ActionResult<DawResponse> CreateAudioEffect(AudioEffect audioEffect)
        {
            return dawResponseFactory.CreateDawControllerResponse(audioEffectService.CreateAudioEffect(audioEffect));
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> UpdateAudioEffect(AudioEffect audioEffect)
        {
            return dawResponseFactory.CreateDawControllerResponse(audioEffectService.UpdateAudioEffect(audioEffect));
        }

        [HttpDelete("{id}")]
        public ActionResult<DawResponse> DeleteAudioEffect(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(audioEffectService.DeleteAudioEffect(id));
        }
    }
}