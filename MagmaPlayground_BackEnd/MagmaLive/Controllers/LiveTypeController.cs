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

        public LiveTypeController(MagmaLiveDbContext magmaLiveDbContext)
        {
            liveTypeService = new LiveTypeService(magmaLiveDbContext);
        }

        [HttpGet("{id}")]
        public ActionResult<LiveResponse> GetLiveTypeById(int id)
        {
            return liveTypeService.GetLiveTypeById(id);
        }

        [HttpPost("create")]
        public ActionResult<LiveResponse> CreateLiveType(LiveType liveType)
        {
            return liveTypeService.CreateLiveType(liveType);
        }

        [HttpPost("update")]
        public ActionResult<LiveResponse> UpdateLiveType(LiveType liveType)
        {
            return liveTypeService.UpdateLiveType(liveType);
        }

        [HttpDelete("{id}")]
        public ActionResult<LiveResponse> DeleteLiveType(LiveType liveType)
        {
            return liveTypeService.DeleteLiveType(liveType);
        }
    }
}
