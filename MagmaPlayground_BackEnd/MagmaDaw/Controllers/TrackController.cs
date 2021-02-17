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
using MagmaPlayground_BackEnd.Services;
using MagmaPlayground_BackEnd.ResponseUtilities;

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class TrackController : ControllerBase
    {
        private TrackService trackService;
        private DawResponseFactory dawResponseFactory;

        public TrackController(MagmaDawDbContext magmaDbContext)
        {
            trackService = new TrackService(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetTrackById(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(trackService.GetTrackById(id));
        }

        [HttpGet("project/{projectId}")]
        public ActionResult<DawResponse> GetTracksByProjectId(int projectId)
        {
            return dawResponseFactory.CreateDawControllerResponse(trackService.GetTracksByProjectId(projectId));
        }

        [HttpPost]
        public ActionResult<DawResponse> CreateTrack(Track track)
        {
            return dawResponseFactory.CreateDawControllerResponse(trackService.CreateTrack(track));
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> UpdateTrack(Track track)
        {
            return dawResponseFactory.CreateDawControllerResponse(trackService.UpdateTrack(track));
        }

        [HttpDelete("{id}")]
        public ActionResult<DawResponse> DeleteTrack(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(trackService.DeleteTrack(id));
        }
    }
}