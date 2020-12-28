using MagmaPlayground_BackEnd.Models.MagmaLive.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Models.MagmaLive
{
    public class Live
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime uploadedOn { get; set; }

        public int liveTypeId { get; set; }
        public Enum_LiveType enum_LiveType { get; set; }
        public LiveType liveType { get; set; }

        public int liveFileId { get; set; }
        public LiveFile liveFile { get; set; }
    }
}
