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
    public class LiveFileTypeController : ControllerBase
    {
        private LiveFileTypeService liveFileTypeService;

        public LiveFileTypeController(MagmaLiveDbContext magmaLiveDbContext)
        {
            liveFileTypeService = new LiveFileTypeService(magmaLiveDbContext);
        }

        [HttpGet("{id}")]
        public ActionResult<LiveResponse> GetLiveFileTypeById(int id)
        {
            return liveFileTypeService.GetLiveFileTypeById(id);
        }

        [HttpGet("create")]
        public ActionResult<LiveResponse> CreateLiveFileType(LiveFileType liveFileType)
        {
            return liveFileTypeService.CreateLiveFileType(liveFileType);
        }

        [HttpPost("update")]
        public ActionResult<LiveResponse> UpdateLive(LiveFileType liveFileType)
        {
            return liveFileTypeService.UpdateLiveFileType(liveFileType);
        }

        [HttpDelete("{id}")]
        public ActionResult<LiveResponse> DeleteLive(LiveFileType liveFileType)
        {
            return liveFileTypeService.DeleteLiveFileType(liveFileType);
        }
    }
}
