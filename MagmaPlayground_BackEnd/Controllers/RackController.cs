using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class RackController : ControllerBase
    {
        private MagmaDbContext magmaDbContext;

        private ActionResult<Rack> rack;

        public RackController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }
        
        [HttpGet("{id}")]
        public ActionResult<Rack> GetRackById(int id)
        {
            return rack;
        }

        [HttpGet("track/{id}")]
        public ActionResult<Rack> GetRackByTrackId(int trackId)
        {
            return rack;
        }

        [HttpPost]
        public ActionResult CreateRack(Rack rack)
        {
            return Ok("Success: created rack");
        }

        [HttpPost("update")]
        public ActionResult UpdateRack(Rack rack)
        {
            return Ok("Success: updated rack");
        }

        [HttpDelete]
        public ActionResult RemoveRack(Rack rack)
        {
            return Ok("Success: removed rack");
        }
    }
}