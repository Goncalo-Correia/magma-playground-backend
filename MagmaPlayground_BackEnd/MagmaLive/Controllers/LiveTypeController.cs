using MagmaPlayground_BackEnd.MagmaDB.MagmaLive.MagmaDbContext;
using MagmaPlayground_BackEnd.MagmaLive.Response;
using MagmaPlayground_BackEnd.MagmaLive.Services;
using MagmaPlayground_BackEnd.Models.MagmaLive;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaLive
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class LiveTypeController : ControllerBase
    {
        private LiveTypeService liveTypeService;
        private LiveResponseFactory liveResponseFactory;

        public LiveTypeController(MagmaLiveDbContext magmaLiveDbContext)
        {
            liveTypeService = new LiveTypeService(magmaLiveDbContext);
            liveResponseFactory = new LiveResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetLiveTypeById(int id)
        {
            return liveResponseFactory.CreateLiveControllerResponse(liveTypeService.GetLiveTypeById(id));
        }

        [HttpPost("create")]
        public ActionResult<string> CreateLiveType(LiveType liveType)
        {
            return liveResponseFactory.CreateLiveControllerResponse(liveTypeService.CreateLiveType(liveType));
        }

        [HttpPost("update")]
        public ActionResult<string> UpdateLiveType(LiveType liveType)
        {
            return liveResponseFactory.CreateLiveControllerResponse(liveTypeService.UpdateLiveType(liveType));
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteLiveType(LiveType liveType)
        {
            return liveResponseFactory.CreateLiveControllerResponse(liveTypeService.DeleteLiveType(liveType));
        }
    }
}
