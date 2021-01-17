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
    public class LiveController : ControllerBase
    {
        private LiveService liveService;

        public LiveController(MagmaLiveDbContext magmaLiveDbContext)
        {
            liveService = new LiveService(magmaLiveDbContext);
        }

        [HttpGet("{id}")]
        public ActionResult<LiveResponse> GetLiveById(int id)
        {
            return liveService.GetLiveById(id);
        }

        [HttpPost("create")]
        public ActionResult<LiveResponse> CreateLive(Live live)
        {
            return liveService.CreateLive(live);
        }

        [HttpPost("update")]
        public ActionResult<LiveResponse> UpdateLive(Live live)
        {
            return liveService.UpdateLive(live);
        }

        [HttpDelete("{id}")]
        public ActionResult<LiveResponse> DeleteLive(Live live)
        { 
            return liveService.DeleteLive(live);
        }
    }
}
