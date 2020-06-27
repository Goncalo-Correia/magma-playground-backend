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
    public class SynthesizerController : ControllerBase
    {
        private SynthesizerService synthesizerService;
        private ControllerResponseFactory controllerResponseFactory;
        private Response response;

        public SynthesizerController(MagmaDbContext magmaDbContext)
        {
            synthesizerService = new SynthesizerService(magmaDbContext);
            controllerResponseFactory = new ControllerResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<Response> GetSynthesizerById(int id)
        {
            response = new Response();
            response = synthesizerService.GetSynthesizerById(id);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpGet("plugin/{pluginId}")]
        public ActionResult<Response> GetSynthesizerByPluginId(int pluginId)
        {
            response = new Response();
            response = synthesizerService.GetSynthesizerByPluginId(pluginId);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<Response> CreateSynthesizer(Synthesizer synthesizer)
        {
            response = new Response();
            response = synthesizerService.CreateSynthesizer(synthesizer);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<Response> UpdateSynthesizer(Synthesizer synthesizer)
        {
            response = new Response();
            response = synthesizerService.UpdateSynthesizer(synthesizer);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpDelete]
        public ActionResult<Response> DeleteSynthesizer(Synthesizer synthesizer)
        {
            response = new Response();
            response = synthesizerService.DeleteSynthesizer(synthesizer);

            return controllerResponseFactory.BuildControllerResponse(response);
        }
    }
}