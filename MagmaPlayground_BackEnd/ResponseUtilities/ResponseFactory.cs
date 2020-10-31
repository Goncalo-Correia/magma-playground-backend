using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.ResponseUtilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.ResponseUtilities
{
    public class ResponseFactory : ControllerBase
    {
        public Response response { get; set; }
        public ResponseSerializer responseSerializer;

        public ResponseFactory()
        {
            responseSerializer = new ResponseSerializer();
        }

        public Response CreateResponse(string message, ResponseStatus responseStatus)
        {
            response = new Response();
            response.message = message;
            response.responseStatus = responseStatus;

            return response;
        }

        public Response UpdateResponse(Response response, string message, ResponseStatus responseStatus)
        {
            response.message = message;
            response.responseStatus = responseStatus;

            return response;
        }

        public ActionResult<Response> CreateControllerResponse(Response response)
        {
            if (response.responseStatus == ResponseStatus.BADREQUEST)
            {
                return BadRequest(responseSerializer.SerializeResponse(response));
            }
            if (response.responseStatus == ResponseStatus.EXCEPTION)
            {
                return Conflict(responseSerializer.SerializeResponse(response));
            }
            if (response.responseStatus == ResponseStatus.NOTFOUND)
            {
                return NotFound(responseSerializer.SerializeResponse(response));
            }

            return Ok(responseSerializer.SerializeResponse(response));
        }
    }
}
