using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.Model;

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
            track = magmaDbContext.Find<Track>(id);

            return track;
        }

        [HttpGet("project/{id}")]
        public ActionResult<IEnumerable<Track>> GetTracksByProjectId(int projectId)
        {
            tracks = magmaDbContext.Tracks.Where<Track>(prop => prop.project.id == projectId).ToList();

            return tracks;
        }

        [HttpPost]
        public ActionResult CreateTrack(Track track)
        {
            magmaDbContext.Add<Track>(track);
            magmaDbContext.SaveChanges();

            return Ok("Success: created track");
        }

        [HttpPost("update")]
        public ActionResult UpdateTrack(Track track)
        {
            if (track.id == 0)
            {
                return BadRequest("Error: invalid data");
            }

            magmaDbContext.Update<Track>(track);
            magmaDbContext.SaveChanges();

            return Ok("Success: updated track");
        }

        [HttpDelete]
        public ActionResult RemoveTrack(Track track)
        {
            magmaDbContext.Remove<Track>(track);
            magmaDbContext.SaveChanges();

            return Ok("Success: removed track");
        }
    }
}