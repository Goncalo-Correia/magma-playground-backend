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
            if (id == 0)
            {
                return BadRequest("Error: input parameter is null");
            }

            rack = magmaDbContext.Find<Rack>(id);
            
            if (rack == null)
            {
                return NotFound("Error: rack not found");
            }

            return rack;
        }

        [HttpGet("track/{id}")]
        public ActionResult<Rack> GetRackByTrackId(int trackId)
        {
            try
            {
                if (trackId == 0)
                {
                    return BadRequest("Error: input parameter is null");
                }

                rack = magmaDbContext.Racks.Single<Rack>(prop => prop.trackId == trackId);

                if (rack == null)
                {
                    return NotFound("Error: rack not found for this track");
                }
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }

            return rack;

        }

        [HttpPost]
        public ActionResult CreateRack(Rack rack)
        {
            try
            {
                if (rack == null)
                {
                    return BadRequest("Error: input parameter is null");
                }

                if (rack.id != 0)
                {
                    return BadRequest("Error: rack already exists, id must be null");
                }

                magmaDbContext.Add<Rack>(rack);
                magmaDbContext.SaveChanges();

            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Success: created rack");
        }

        [HttpPost("update")]
        public ActionResult UpdateRack(Rack rack)
        {
            try
            {
                if (rack == null)
                {
                    return BadRequest("Error: input parameter is null");
                }

                if (rack.id == 0)
                {
                    return BadRequest("Error: rack id is null");
                }

                magmaDbContext.Update<Rack>(rack);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Success: updated rack");
        }

        [HttpDelete]
        public ActionResult RemoveRack(Rack rack)
        {
            try
            {
                if (rack == null)
                {
                    return BadRequest("Error: input parameter is null");
                }

                if (rack.id == 0)
                {
                    return BadRequest("Error: rack id is null");
                }

                magmaDbContext.Remove<Rack>(rack);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Success: removed rack");
        }
    }
}