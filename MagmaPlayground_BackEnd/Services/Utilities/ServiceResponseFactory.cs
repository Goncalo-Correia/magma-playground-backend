using MagmaPlayground_BackEnd.Daos.Utilities;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Services.Utilities
{
    public class ServiceResponseFactory
    {
        private ServiceResponse serviceResponse;

        public ServiceResponseFactory()
        {

        }

        public ServiceResponse BuildServiceResponse(string message, ResponseStatus responseStatus)
        {
            serviceResponse = new ServiceResponse();

            serviceResponse.message = message;
            serviceResponse.responseStatus = responseStatus;


            return serviceResponse;
        }

        public ServiceResponse BuildServiceResponseFromDaoResponse(DaoResponse daoResponse, ResponseStatus responseStatus)
        {
            serviceResponse = new ServiceResponse();

            serviceResponse.message = daoResponse.message;
            serviceResponse.responseStatus = responseStatus;

            return serviceResponse;
        }

        public ServiceResponse BuildServiceResponseUser(User user, string message, ResponseStatus responseStatus)
        {
            serviceResponse = new ServiceResponse();

            serviceResponse.user = user;
            serviceResponse.message = message;
            serviceResponse.responseStatus = responseStatus;

            return serviceResponse;
        }
    }
}
