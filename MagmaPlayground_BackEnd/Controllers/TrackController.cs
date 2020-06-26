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
        private ControllerResponseFactory controllerResponseFactory;
        private Response response;

        public TrackController(MagmaDbContext magmaDbContext)
        {
            trackService = new TrackService(magmaDbContext);
            controllerResponseFactory = new ControllerResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<Response> GetTrackById(int id)
        {
            response = new Response();
            response = trackService.GetTrackById(id);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpGet("project/{id}")]
        public ActionResult<Response> GetTracksByProjectId(int projectId)
        {
            response = new Response();
            response = trackService.GetTracksByProjectId(projectId);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<Response> CreateTrack(Track track)
        {
            response = new Response();
            response = trackService.CreateTrack(track);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<Response> UpdateTrack(Track track)
        {
            response = new Response();
            response = trackService.UpdateTrack(track);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpDelete]
        public ActionResult<Response> DeleteTrack(Track track)
        {
            response = new Response();
            response = trackService.DeleteTrack(track);

            return controllerResponseFactory.BuildControllerResponse(response);
        }
    }
}