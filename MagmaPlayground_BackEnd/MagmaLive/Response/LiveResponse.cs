using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Models.MagmaLive.Response
{
    public class LiveResponse
    {
        public Live live { get; set; }
        public List<Live> lives { get; set; }

        public LiveFile liveFile { get; set; }
        public List<LiveFile> liveFiles { get; set; }

        public bool isSuccess { get; set; }
        public string errorMessage { get; set; }
    }
}
