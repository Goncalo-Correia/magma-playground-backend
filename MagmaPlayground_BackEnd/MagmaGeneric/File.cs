using MagmaPlayground_BackEnd.Models.MagmaGeneric.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Models.MagmaGeneric
{
    public class File
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime updatedOn { get; set; }

        public int fileTypeId { get; set; }
        public Enum_FileType enum_FileType { get; set; }
        public FileType fileType { get; set; }

        public int fileContentId { get; set; }
        public FileContent fileContent { get; set; }
    }
}
