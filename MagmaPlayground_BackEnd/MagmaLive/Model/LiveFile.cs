using MagmaPlayground_BackEnd.Models.MagmaGeneric;
using MagmaPlayground_BackEnd.Models.MagmaLive.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Models.MagmaLive
{
    public class LiveFile
    {
        public int id { get; set; }
        public string url { get; set; }

        public int liveFileTypeId { get; set; }
        public Enum_LiveFileType enum_LiveFileType { get; set; }
        public LiveFileType liveFileType { get; set; }

        public int previewFileId { get; set; }
        public File previewFile { get; set; }

        public int fileId { get; set; }
        public File file { get; set; }
    }
}
