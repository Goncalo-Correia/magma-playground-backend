using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.ResponseUtilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.ResponseUtilities
{
    public class DawResponseFactory : ControllerBase
    {
        public DawResponseSerializer dawResponseSerializer;

        public DawResponseFactory()
        {
            dawResponseSerializer = new DawResponseSerializer();
        }

        public DawResponse CreateDawResponse(DawResponse dawResponse, string errorMessage, HttpStatusCode httpStatusCode)
        {
            dawResponse.errorMessage = errorMessage;
            dawResponse.httpStatusCode = httpStatusCode;

            return dawResponse;
        }

        public ActionResult<DawResponse> CreateDawControllerResponse(DawResponse dawResponse)
        {
            string json = dawResponseSerializer.SerializeResponse(dawResponse);

            switch(dawResponse.httpStatusCode)
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
