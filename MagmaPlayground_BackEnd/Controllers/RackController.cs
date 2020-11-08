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
        private ResponseFactory responseFactory;
        private Response response;


        public RackController(MagmaDbContext magmaDbContext)
        {
            rackService = new RackService(magmaDbContext);
            responseFactory = new ResponseFactory();
        }
        
        [HttpGet("{id}")]
        public ActionResult<Response> GetRackById(int id)
        {
            response = new Response();

            response = rackService.GetRackById(id);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpGet("track/{trackId}")]
        public ActionResult<Response> GetRackByTrackId(int trackId)
        {
            response = new Response();

            response = rackService.GetRackByTrackId(trackId);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<Response> CreateRack(Rack rack)
        {
            response = new Response();

            response = rackService.CreateRack(rack);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<Response> UpdateRack(Rack rack)
        {
            response = new Response();

            response = rackService.UpdateRack(rack);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response> DeleteRack(int id)
        {
            response = new Response();

            response = rackService.DeleteRack(id);

            return responseFactory.CreateControllerResponse(response);
        }
    }
}