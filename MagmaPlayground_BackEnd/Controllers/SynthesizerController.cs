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
        private ResponseFactory responseFactory;
        private Response response;

        public SynthesizerController(MagmaDbContext magmaDbContext)
        {
            synthesizerService = new SynthesizerService(magmaDbContext);
            responseFactory = new ResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<Response> GetSynthesizerById(int id)
        {
            response = new Response();

            response = synthesizerService.GetSynthesizerById(id);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpGet("plugin/{pluginId}")]
        public ActionResult<Response> GetSynthesizerByPluginId(int pluginId)
        {
            response = new Response();

            response = synthesizerService.GetSynthesizerByPluginId(pluginId);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<Response> CreateSynthesizer(Synthesizer synthesizer)
        {
            response = new Response();

            response = synthesizerService.CreateSynthesizer(synthesizer);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<Response> UpdateSynthesizer(Synthesizer synthesizer)
        {
            response = new Response();

            response = synthesizerService.UpdateSynthesizer(synthesizer);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response> DeleteSynthesizer(int id)
        {
            response = new Response();

            response = synthesizerService.DeleteSynthesizer(id);

            return responseFactory.CreateControllerResponse(response);
        }
    }
}