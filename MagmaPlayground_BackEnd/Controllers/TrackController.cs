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
        private ResponseFactory responseFactory;
        private Response response;

        public TrackController(MagmaDbContext magmaDbContext)
        {
            trackService = new TrackService(magmaDbContext);
            responseFactory = new ResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<Response> GetTrackById(int id)
        {
            response = new Response();
            response = trackService.GetTrackById(id);

            return responseFactory.BuildControllerResponse(response);
        }

        [HttpGet("project/{projectId}")]
        public ActionResult<Response> GetTracksByProjectId(int projectId)
        {
            response = new Response();
            response = trackService.GetTracksByProjectId(projectId);

            return responseFactory.BuildControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<Response> CreateTrack(Track track)
        {
            response = new Response();
            response = trackService.CreateTrack(track);

            return responseFactory.BuildControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<Response> UpdateTrack(Track track)
        {
            response = new Response();
            response = trackService.UpdateTrack(track);

            return responseFactory.BuildControllerResponse(response);
        }

        [HttpDelete]
        public ActionResult<Response> DeleteTrack(Track track)
        {
            response = new Response();
            response = trackService.DeleteTrack(track);

            return responseFactory.BuildControllerResponse(response);
        }
    }
}