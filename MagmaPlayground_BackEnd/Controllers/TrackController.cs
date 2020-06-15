using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.Model;
using Microsoft.EntityFrameworkCore.Internal;
using Npgsql;

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
            return track;
        }

        [HttpGet("project/{id}")]
        public ActionResult<IEnumerable<Track>> GetTracksByProjectId(int projectId)
        {
            return tracks;
        }

        [HttpPost]
        public ActionResult CreateTrack(Track track)
        {
            return Ok("Success: created track");
        }

        [HttpPost("update")]
        public ActionResult UpdateTrack(Track track)
        {
            return Ok("Success: updated track");
        }

        [HttpDelete]
        public ActionResult RemoveTrack(Track track)
        {
            return Ok("Success: removed track");
        }
    }
}