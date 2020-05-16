using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using Microsoft.AspNetCore.Mvc;

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class RackController : ControllerBase
    {
        private MagmaDbContext magmaDbContext;

        private ActionResult<IEnumerable<Rack>> racks;
        private ActionResult<Rack> rack;

        public RackController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }
        
        [HttpGet]
        public ActionResult<Rack> GetRackById(int id)
        {
            rack = magmaDbContext.Find<Rack>(id);

            return rack;
        }

        [HttpPost]
        public ActionResult CreateRack(Rack rack)
        {
            magmaDbContext.Add<Rack>(rack);
            magmaDbContext.SaveChanges();

            return Ok("Success: created rack");
        }

        [HttpPost("update")]
        public ActionResult UpdateRack(Rack rack)
        {
            magmaDbContext.Update<Rack>(rack);

            return Ok("Success: updated rack");
        }

        [HttpDelete]
        public ActionResult RemoveRack(Rack rack)
        {
            magmaDbContext.Remove<Rack>(rack);
            magmaDbContext.SaveChanges();

            return Ok("Success: removed rack");
        }
    }
}