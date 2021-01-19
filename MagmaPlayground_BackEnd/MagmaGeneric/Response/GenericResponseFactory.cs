using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaGeneric.Response
{
    public class GenericResponseFactory : ControllerBase
    {
        private GenericResponseSerializer genericResponseSerializer;

        public GenericResponseFactory()
        {
            genericResponseSerializer = new GenericResponseSerializer();
        }

        public GenericResponse CreateGenericResponse(GenericResponse genericResponse, string errorMessage, HttpStatusCode httpStatusCode)
        {
            genericResponse.errorMessage = errorMessage;
            genericResponse.httpStatusCode = httpStatusCode;

            return genericResponse;
        }

        public ActionResult<string> CreateGenericControllerResponse(GenericResponse genericResponse)
        {
            string json = genericResponseSerializer.SerializeResponse(genericResponse);

            switch (genericResponse.httpStatusCode)
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
