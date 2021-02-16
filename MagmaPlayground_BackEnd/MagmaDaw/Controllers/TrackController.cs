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
        private DawResponseFactory responseFactory;
        private DawResponse response;

        public TrackController(MagmaDawDbContext magmaDbContext)
        {
            trackService = new TrackService(magmaDbContext);
            responseFactory = new DawResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetTrackById(int id)
        {
            response = new DawResponse();

            response = trackService.GetTrackById(id);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpGet("project/{projectId}")]
        public ActionResult<DawResponse> GetTracksByProjectId(int projectId)
        {
            response = new DawResponse();
            response = trackService.GetTracksByProjectId(projectId);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<DawResponse> CreateTrack(Track track)
        {
            response = new DawResponse();

            response = trackService.CreateTrack(track);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> UpdateTrack(Track track)
        {
            response = new DawResponse();

            response = trackService.UpdateTrack(track);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<DawResponse> DeleteTrack(int id)
        {
            response = new DawResponse();

            response = trackService.DeleteTrack(id);

            return responseFactory.CreateControllerResponse(response);
        }
    }
}