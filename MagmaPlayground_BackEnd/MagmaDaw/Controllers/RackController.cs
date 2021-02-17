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
        private DawResponseFactory dawResponseFactory;


        public RackController(MagmaDawDbContext magmaDbContext)
        {
            rackService = new RackService(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }
        
        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetRackById(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(rackService.GetRackById(id));
        }

        [HttpPost]
        public ActionResult<DawResponse> CreateRack(Rack rack)
        {
            return dawResponseFactory.CreateDawControllerResponse(rackService.CreateRack(rack));
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> UpdateRack(Rack rack)
        {
            return dawResponseFactory.CreateDawControllerResponse(rackService.UpdateRack(rack));
        }

        [HttpDelete("{id}")]
        public ActionResult<DawResponse> DeleteRack(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(rackService.DeleteRack(id));
        }
    }
}