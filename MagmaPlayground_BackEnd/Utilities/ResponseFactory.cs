using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Daos.Utilities
{
    public class ResponseFactory
    {
        public Response response { get; set; }

        public ResponseFactory()
        {
        }

        public Response BuildResponse(string message, ResponseStatus responseStatus)
        {
            response = new Response();
            response.message = message;
            response.responseStatus = responseStatus;

            return response;
        }
    }
}
