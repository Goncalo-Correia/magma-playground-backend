using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaLive.Response
{
    public class LiveResponseFactory : ControllerBase
    {
        private LiveResponseSerializer liveResponseSerializer;

        public LiveResponseFactory()
        {
            liveResponseSerializer = new LiveResponseSerializer();
        }

        public LiveResponse CreateLiveResponse(LiveResponse liveResponse, string errorMessage, HttpStatusCode httpStatusCode)
        {
            liveResponse.errorMessage = errorMessage;
            liveResponse.httpStatusCode = httpStatusCode;

            return liveResponse;
        }

        public ActionResult<string> CreateLiveControllerResponse(LiveResponse liveResponse)
        {
            string json = liveResponseSerializer.SerializeResponse(liveResponse);

            switch(liveResponse.httpStatusCode)
            {
                case HttpStatusCode.BadRequest:
                    return BadRequest(json);

                case HttpStatusCode.NotFound:
                    return NotFound(json);

                default:
                    return Ok(json);
            }
        }
    }
}
