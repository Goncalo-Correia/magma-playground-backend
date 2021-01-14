using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaLive.Response
{
    public class LiveResponseFactory
    {
        public LiveResponse CreateLiveResponse(LiveResponse liveResponse, string errorMessage, HttpStatusCode httpStatusCode)
        {
            liveResponse.errorMessage = errorMessage;
            liveResponse.httpStatusCode = httpStatusCode;

            return liveResponse;
        }
    }
}
