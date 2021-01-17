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

        public LiveFileController (MagmaLiveDbContext magmaLiveDbContext)
        {
            liveFileService = new LiveFileService(magmaLiveDbContext);
        }

        [HttpGet("{id}")]
        public ActionResult<LiveResponse> GetLiveFileById(int id)
        {
            return liveFileService.GetLiveFileById(id);
        }

        [HttpPost("create")]
        public ActionResult<LiveResponse> CreateLiveFile(LiveFile liveFile)
        {
            return liveFileService.CreateLiveFile(liveFile);
        }

        [HttpPost("update")]
        public ActionResult<LiveResponse> UpdateLiveFile(LiveFile liveFile)
        {
            return liveFileService.UpdateLiveFile(liveFile);
        }

        [HttpDelete("{id}")]
        public ActionResult<LiveResponse> DeleteLiveFile(LiveFile liveFile)
        {
            return liveFileService.DeleteLiveFile(liveFile);
        }
    }
}
