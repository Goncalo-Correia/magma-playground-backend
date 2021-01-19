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
        private LiveResponseFactory liveResponseFactory;

        public LiveController(MagmaLiveDbContext magmaLiveDbContext)
        {
            liveService = new LiveService(magmaLiveDbContext);
            liveResponseFactory = new LiveResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetLiveById(int id)
        {
            var a = liveService.GetLiveById(id);

            return liveResponseFactory.CreateLiveControllerResponse(liveService.GetLiveById(id));
        }

        [HttpPost("create")]
        public ActionResult<string> CreateLive(Live live)
        {
            return liveResponseFactory.CreateLiveControllerResponse(liveService.CreateLive(live));
        }

        [HttpPost("update")]
        public ActionResult<string> UpdateLive(Live live)
        {
            return liveResponseFactory.CreateLiveControllerResponse(liveService.UpdateLive(live));
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteLive(Live live)
        { 
            return liveResponseFactory.CreateLiveControllerResponse(liveService.DeleteLive(live));
        }
    }
}
