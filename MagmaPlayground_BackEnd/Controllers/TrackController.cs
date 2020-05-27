using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.Model;
using Microsoft.EntityFrameworkCore.Internal;

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class TrackController : ControllerBase
    {
        private MagmaDbContext magmaDbContext;

        private ActionResult<IEnumerable<Track>> tracks;
        private ActionResult<Track> track;

        public TrackController(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        [HttpGet("{id}")]
        public ActionResult<Track> GetTrackById(int id)
        {
            if (id == 0)
            {
                return BadRequest("Error: input parameter id is null");
            } 

            track = magmaDbContext.Find<Track>(id);

            if (track == null)
            {
                return NotFound("Error: track not found");
            }

            return track;
        }

        [HttpGet("project/{id}")]
        public ActionResult<IEnumerable<Track>> GetTracksByProjectId(int projectId)
        {
            try
            {
                if (projectId == 0)
                {
                    return BadRequest("Error: input paramenter projectId is null");
                }
                
                tracks = magmaDbContext.Tracks.Where<Track>(prop => prop.projectId == projectId).ToList();

                if (tracks == null)
                {
                    return NotFound("Error: tracks not found for this project");
                }
            }
            catch(ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

            return tracks;
        }

        [HttpPost]
        public ActionResult CreateTrack(Track track)
        {
            try
            {
                if (track == null)
                {
                    return BadRequest("Error: input parameter is null");
                }

                if (track.id != 0)
                {
                    return BadRequest("Error: track already exists, id must be null");
                }

                magmaDbContext.Add<Track>(track);
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

            return Ok("Success: created track");
        }

        [HttpPost("update")]
        public ActionResult UpdateTrack(Track track)
        {
            try
            {
                if (track == null)
                {
                    return BadRequest("Error: input parameter is null");
                }

                if (track.id == 0)
                {
                    return BadRequest("Error: track id is null");
                }

                magmaDbContext.Update<Track>(track);
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

            return Ok("Success: updated track");
        }

        [HttpDelete]
        public ActionResult RemoveTrack(Track track)
        {
            try
            {
                if (track == null)
                {
                    return BadRequest("Error: input parameter is null");
                }

                if (track.id == 0)
                {
                    return BadRequest("Error: track id is null");
                }

                magmaDbContext.Remove<Track>(track);
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

            return Ok("Success: removed track");
        }
    }
}