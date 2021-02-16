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
        private DawResponseFactory responseFactory;
        private DawResponse response;

        public SamplerController(MagmaDawDbContext magmaDbContext)
        {
            samplerService = new SamplerService(magmaDbContext);
            responseFactory = new DawResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetSamplerById(int id)
        {
            response = new DawResponse();

            response = samplerService.GetSamplerById(id);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpGet("plugin/{pluginId}")]
        public ActionResult<DawResponse> GetSamplerByPluginId(int pluginId)
        {
            response = new DawResponse();

            response = samplerService.GetSamplerByPluginId(pluginId);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<DawResponse> CreateSampler(Sampler sampler)
        {
            response = new DawResponse();

            response = samplerService.CreateSampler(sampler);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> UpdateSampler(Sampler sampler)
        {
            response = new DawResponse();

            response = samplerService.UpdateSampler(sampler);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<DawResponse> DeleteSampler(int id)
        {
            response = new DawResponse();

            response = samplerService.DeleteSampler(id);

            return responseFactory.CreateControllerResponse(response);
        }
    }
}