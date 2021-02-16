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
        private DawResponseFactory responseFactory;
        private DawResponse response;

        public SynthesizerController(MagmaDawDbContext magmaDbContext)
        {
            synthesizerService = new SynthesizerService(magmaDbContext);
            responseFactory = new DawResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetSynthesizerById(int id)
        {
            response = new DawResponse();

            response = synthesizerService.GetSynthesizerById(id);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpGet("plugin/{pluginId}")]
        public ActionResult<DawResponse> GetSynthesizerByPluginId(int pluginId)
        {
            response = new DawResponse();

            response = synthesizerService.GetSynthesizerByPluginId(pluginId);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<DawResponse> CreateSynthesizer(Synthesizer synthesizer)
        {
            response = new DawResponse();

            response = synthesizerService.CreateSynthesizer(synthesizer);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> UpdateSynthesizer(Synthesizer synthesizer)
        {
            response = new DawResponse();

            response = synthesizerService.UpdateSynthesizer(synthesizer);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<DawResponse> DeleteSynthesizer(int id)
        {
            response = new DawResponse();

            response = synthesizerService.DeleteSynthesizer(id);

            return responseFactory.CreateControllerResponse(response);
        }
    }
}