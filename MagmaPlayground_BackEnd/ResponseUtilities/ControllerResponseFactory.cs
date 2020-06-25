using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.ResponseUtilities
{
    public class ControllerResponseFactory : ControllerBase
    {
        private Response response;

        public ControllerResponseFactory()
        {
            response = new Response();
        }

        public ActionResult<Response> BuildControllerResponse(Response response)
        {
            if (response.responseStatus == ResponseStatus.BADREQUEST)
            {
                return BadRequest(response);
            }
            if (response.responseStatus == ResponseStatus.EXCEPTION)
            {
                return Conflict(response);
            }
            if (response.responseStatus == ResponseStatus.NOTFOUND)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
