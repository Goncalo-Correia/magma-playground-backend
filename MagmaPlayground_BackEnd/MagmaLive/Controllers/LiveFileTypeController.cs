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
    public class LiveFileTypeController : ControllerBase
    {
        private LiveFileTypeService liveFileTypeService;
        private LiveResponseFactory liveResponseFactory;

        public LiveFileTypeController(MagmaLiveDbContext magmaLiveDbContext)
        {
            liveFileTypeService = new LiveFileTypeService(magmaLiveDbContext);
            liveResponseFactory = new LiveResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetLiveFileTypeById(int id)
        {
            return liveResponseFactory.CreateLiveControllerResponse(liveFileTypeService.GetLiveFileTypeById(id));
        }

        [HttpPost("create")]
        public ActionResult<string> CreateLiveFileType(LiveFileType liveFileType)
        {
            return liveResponseFactory.CreateLiveControllerResponse(liveFileTypeService.CreateLiveFileType(liveFileType));
        }

        [HttpPost("update")]
        public ActionResult<string> UpdateLive(LiveFileType liveFileType)
        {
            return liveResponseFactory.CreateLiveControllerResponse(liveFileTypeService.UpdateLiveFileType(liveFileType));
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteLive(LiveFileType liveFileType)
        {
            return liveResponseFactory.CreateLiveControllerResponse(liveFileTypeService.DeleteLiveFileType(liveFileType));
        }
    }
}
