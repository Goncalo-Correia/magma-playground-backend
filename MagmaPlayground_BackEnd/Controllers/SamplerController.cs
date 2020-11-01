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
        private ResponseFactory responseFactory;
        private Response response;

        public SamplerController(MagmaDbContext magmaDbContext)
        {
            samplerService = new SamplerService(magmaDbContext);
            responseFactory = new ResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<Response> GetSamplerById(int id)
        {
            response = new Response();

            response = samplerService.GetSamplerById(id);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpGet("plugin/{pluginId}")]
        public ActionResult<Response> GetSamplerByPluginId(int pluginId)
        {
            response = new Response();

            response = samplerService.GetSamplerByPluginId(pluginId);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<Response> CreateSampler(Sampler sampler)
        {
            response = new Response();

            response = samplerService.CreateSampler(sampler);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<Response> UpdateSampler(Sampler sampler)
        {
            response = new Response();

            response = samplerService.UpdateSampler(sampler);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response> DeleteSampler(int id)
        {
            response = new Response();

            response = samplerService.DeleteSampler(id);

            return responseFactory.CreateControllerResponse(response);
        }
    }
}