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
    public class SynthesizerTypeController : ControllerBase
    {
        private SynthesizerTypeService synthesizerTypeService;
        private DawResponseFactory dawResponseFactory;

        public SynthesizerTypeController(MagmaDawDbContext magmaDbContext)
        {
            synthesizerTypeService = new SynthesizerTypeService(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetSynthesizerTypeById(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(synthesizerTypeService.GetSynthesizerTypeById(id));
        }

        [HttpGet("")]
        public ActionResult<DawResponse> GetSynthesizerTypes()
        {
            return dawResponseFactory.CreateDawControllerResponse(synthesizerTypeService.GetSynthesizerTypes());
        }

        [HttpPost]
        public ActionResult<DawResponse> CreateSynthesizerType(SynthesizerType synthesizerType)
        {
            return dawResponseFactory.CreateDawControllerResponse(synthesizerTypeService.CreateSynthesizerType(synthesizerType));
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> UpdateSynthesizerType(SynthesizerType synthesizerType)
        {
            return dawResponseFactory.CreateDawControllerResponse(synthesizerTypeService.UpdateSynthesizerType(synthesizerType));
        }

        [HttpDelete("{id}")]
        public ActionResult<DawResponse> DeleteSynthesizerType(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(synthesizerTypeService.DeleteSynthesizerType(id));
        }
    }
}
