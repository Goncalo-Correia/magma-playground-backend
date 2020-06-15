using MagmaPlayground_BackEnd.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Daos.Utilities
{
    public class ResponseFactory
    {
        public Response daoResponse { get; set; }

        public ResponseFactory()
        {
        }

        public Response BuildDaoResponse(string message, ResponseStatus responseStatus)
        {
            daoResponse = new Response();
            daoResponse.message = message;
            daoResponse.responseStatus = responseStatus;

            return daoResponse;
        }
    }
}
