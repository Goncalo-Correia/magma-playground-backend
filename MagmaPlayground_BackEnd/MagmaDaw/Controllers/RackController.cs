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
    public class RackController : ControllerBase
    {
        private RackService rackService;
        private DawResponseFactory responseFactory;
        private DawResponse response;


        public RackController(MagmaDawDbContext magmaDbContext)
        {
            rackService = new RackService(magmaDbContext);
            responseFactory = new DawResponseFactory();
        }
        
        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetRackById(int id)
        {
            response = new DawResponse();

            response = rackService.GetRackById(id);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpGet("track/{trackId}")]
        public ActionResult<DawResponse> GetRackByTrackId(int trackId)
        {
            response = new DawResponse();

            response = rackService.GetRackByTrackId(trackId);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<DawResponse> CreateRack(Rack rack)
        {
            response = new DawResponse();

            response = rackService.CreateRack(rack);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> UpdateRack(Rack rack)
        {
            response = new DawResponse();

            response = rackService.UpdateRack(rack);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<DawResponse> DeleteRack(int id)
        {
            response = new DawResponse();

            response = rackService.DeleteRack(id);

            return responseFactory.CreateControllerResponse(response);
        }
    }
}