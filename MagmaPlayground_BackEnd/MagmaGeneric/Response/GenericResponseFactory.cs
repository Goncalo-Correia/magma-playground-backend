using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaGeneric.Response
{
    public class GenericResponseFactory
    {
        public GenericResponse CreateLiveResponse(GenericResponse genericResponse, string errorMessage, HttpStatusCode httpStatusCode)
        {
            genericResponse.errorMessage = errorMessage;
            genericResponse.httpStatusCode = httpStatusCode;

            return genericResponse;
        }
    }
}
