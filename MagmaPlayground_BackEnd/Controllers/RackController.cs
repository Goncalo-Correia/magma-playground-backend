﻿using System;
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
                return BadRequest(ex.InnerException.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

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