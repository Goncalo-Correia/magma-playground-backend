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
        private DawResponseFactory dawResponseFactory;

        public SynthesizerController(MagmaDawDbContext magmaDbContext)
        {
            synthesizerService = new SynthesizerService(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetSynthesizerById(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(synthesizerService.GetSynthesizerById(id));
        }

        [HttpGet("plugin/{pluginId}")]
        public ActionResult<DawResponse> GetSynthesizerByPluginId(int pluginId)
        {
            return dawResponseFactory.CreateDawControllerResponse(synthesizerService.GetSynthesizerByPluginId(pluginId));
        }

        [HttpPost]
        public ActionResult<DawResponse> CreateSynthesizer(Synthesizer synthesizer)
        {
            return dawResponseFactory.CreateDawControllerResponse(synthesizerService.CreateSynthesizer(synthesizer));
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> UpdateSynthesizer(Synthesizer synthesizer)
        {
            return dawResponseFactory.CreateDawControllerResponse(synthesizerService.UpdateSynthesizer(synthesizer));
        }

        [HttpDelete("{id}")]
        public ActionResult<DawResponse> DeleteSynthesizer(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(synthesizerService.DeleteSynthesizer(id));
        }
    }
}