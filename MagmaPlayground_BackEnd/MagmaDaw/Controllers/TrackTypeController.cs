using MagmaPlayground_BackEnd.MagmaDaw.Models;
using MagmaPlayground_BackEnd.MagmaDaw.Services;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaDaw.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class TrackTypeController : ControllerBase
    {
        private TrackTypeService trackTypeService;
        private DawResponseFactory dawResponseFactory;

        public TrackTypeController(MagmaDawDbContext magmaDbContext)
        {
            trackTypeService = new TrackTypeService(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<DawResponse> GetTrackTypeById(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(trackTypeService.GetTrackTypeById(id));
        }

        [HttpGet("")]
        public ActionResult<DawResponse> GetTrackTypes()
        {
            return dawResponseFactory.CreateDawControllerResponse(trackTypeService.GetTrackTypes());
        }

        [HttpPost]
        public ActionResult<DawResponse> CreateTrackType(TrackType trackType)
        {
            return dawResponseFactory.CreateDawControllerResponse(trackTypeService.CreateTrackType(trackType));
        }

        [HttpPost("update")]
        public ActionResult<DawResponse> UpdateTrackType(TrackType trackType)
        {
            return dawResponseFactory.CreateDawControllerResponse(trackTypeService.UpdateTrackType(trackType));
        }

        [HttpDelete("{id}")]
        public ActionResult<DawResponse> DeleteTrackType(int id)
        {
            return dawResponseFactory.CreateDawControllerResponse(trackTypeService.DeleteTrackType(id));
        }
    }
}
