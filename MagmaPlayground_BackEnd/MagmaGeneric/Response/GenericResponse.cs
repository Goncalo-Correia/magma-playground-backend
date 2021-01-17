using MagmaPlayground_BackEnd.Models.MagmaGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaGeneric.Response
{
    public class GenericResponse
    {
        public File file { get; set; }
        public FileType fileType { get; set; }
        public FileContent fileContent { get; set; }

        public HttpStatusCode httpStatusCode { get; set; }
        public string errorMessage { get; set; }
    }
}
