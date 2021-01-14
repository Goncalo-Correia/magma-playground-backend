

using MagmaPlayground_BackEnd.Models.MagmaLive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaLive.Response
{
    public class LiveResponse
    {
        public Live live { get; set; }
        public LiveType liveType { get; set; }
        public LiveFile liveFile { get; set; }
        public LiveFileType liveFileType { get; set; }

        public HttpStatusCode httpStatusCode { get; set; }
        public string errorMessage { get; set; }
    }
}
