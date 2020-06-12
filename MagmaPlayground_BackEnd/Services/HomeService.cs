using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Daos.Utilities;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Services
{
    public class HomeService
    {
        private ServiceResponseFactory serviceResponseFactory;
        private DaoResponse daoResponse;
        private UserDao userDao;

        public HomeService(MagmaDbContext magmaDbContext)
        {
            this.daoResponse = new DaoResponse();
            this.userDao = new UserDao(magmaDbContext);
        }

        public ServiceResponse Login(string email, string password)
        {
            if (email == null || password == null)
            {
                return serviceResponseFactory.BuildServiceResponse("Error: invalid email or password", ServiceResponseStatus.BAD_REQUEST);
            }

            daoResponse = userDao.GetUserByEmail(email);

            if (!daoResponse.isValid)
            {
                return serviceResponseFactory.BuildServiceResponseFromDaoResponse(daoResponse, ServiceResponseStatus.NOT_FOUND);
            }
            if (daoResponse.user.password != password)
            {
                return serviceResponseFactory.BuildServiceResponse("Error: password is invalid", ServiceResponseStatus.BAD_REQUEST);
            }

            return serviceResponseFactory.BuildServiceResponseUser(daoResponse.user, daoResponse.message, ServiceResponseStatus.OK);
        }

        public ServiceResponse Register(User user)
        {
            if (user.name == null || user.lastName == null || user.password == null || user.email == null)
            {
                return serviceResponseFactory.BuildServiceResponse("Error: missing data", ServiceResponseStatus.BAD_REQUEST);
            }

            daoResponse = userDao.GetUserByEmail(user.email);

            if (daoResponse.user != null)
            {
                return serviceResponseFactory.BuildServiceResponse("Error: email alreay in use", ServiceResponseStatus.BAD_REQUEST);
            }

            daoResponse = userDao.CreateUser(user);

            if (!daoResponse.isValid)
            {
                return serviceResponseFactory.BuildServiceResponseFromDaoResponse(daoResponse, ServiceResponseStatus.BAD_REQUEST);
            }

            return serviceResponseFactory.BuildServiceResponseFromDaoResponse(daoResponse, ServiceResponseStatus.OK);
        }
    }
}
