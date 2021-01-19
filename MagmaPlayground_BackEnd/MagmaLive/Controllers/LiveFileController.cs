using MagmaPlayground_BackEnd.MagmaDB.MagmaLive.MagmaDbContext;
using MagmaPlayground_BackEnd.MagmaLive.Response;
using MagmaPlayground_BackEnd.MagmaLive.Services;
using MagmaPlayground_BackEnd.Models.MagmaLive;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaLive.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class LiveFileController : ControllerBase
    {
        private LiveFileService liveFileService;
        private LiveResponseFactory liveResponseFactory;

        public LiveFileController (MagmaLiveDbContext magmaLiveDbContext)
        {
            liveFileService = new LiveFileService(magmaLiveDbContext);
            liveResponseFactory = new LiveResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetLiveFileById(int id)
        {
            return liveResponseFactory.CreateLiveControllerResponse(liveFileService.GetLiveFileById(id));
        }

        [HttpPost("create")]
        public ActionResult<string> CreateLiveFile(LiveFile liveFile)
        {
            return liveResponseFactory.CreateLiveControllerResponse(liveFileService.CreateLiveFile(liveFile));
        }

        [HttpPost("update")]
        public ActionResult<string> UpdateLiveFile(LiveFile liveFile)
        {
            return liveResponseFactory.CreateLiveControllerResponse(liveFileService.UpdateLiveFile(liveFile));
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteLiveFile(LiveFile liveFile)
        {
            return liveResponseFactory.CreateLiveControllerResponse(liveFileService.DeleteLiveFile(liveFile));
        }
    }
}
