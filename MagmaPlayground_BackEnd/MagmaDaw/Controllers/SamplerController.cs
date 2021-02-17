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
    public class SamplerController : ControllerBase
    {
        private SamplerService samplerService;
        private DawResponseFactory dawResponseFactory;

        public SamplerController(MagmaDawDbContext magmaDbContext)
        {
            samplerService = new SamplerService(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetSamplerById(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(samplerService.GetSamplerById(id));
        }

        [HttpGet("plugin/{pluginId}")]
        public ActionResult<DawResponse> GetSamplerByPluginId(int pluginId)
        {
            return dawResponseFactory.CreateDawControllerResponse(samplerService.GetSamplerByPluginId(pluginId));
        }

        [HttpPost]
        public ActionResult<DawResponse> CreateSampler(Sampler sampler)
        {
            return dawResponseFactory.CreateDawControllerResponse(samplerService.CreateSampler(sampler));
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> UpdateSampler(Sampler sampler)
        {
            return dawResponseFactory.CreateDawControllerResponse(samplerService.UpdateSampler(sampler));
        }

        [HttpDelete("{id}")]
        public ActionResult<DawResponse> DeleteSampler(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(samplerService.DeleteSampler(id));
        }
    }
}