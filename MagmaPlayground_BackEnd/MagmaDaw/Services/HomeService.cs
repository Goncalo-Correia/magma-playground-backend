using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;

namespace MagmaPlayground_BackEnd.Services
{
    public class HomeService
    {
        private ResponseFactory responseFactory;
        private Response response;
        private UserDao userDao;

        public HomeService(MagmaDawDbContext magmaDbContext)
        {
            responseFactory = new ResponseFactory();
            userDao = new UserDao(magmaDbContext);
        }

        public Response Login(string email, string password)
        {
            if (email == null || password == null)
            {
                return responseFactory.CreateResponse("Error: invalid email or password", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            try
            {
                response = userDao.GetUserByEmail(email);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            if (response.responseStatus != ResponseStatus.OK)
            {
                return responseFactory.CreateResponse(response.message, ResponseStatus.NOTFOUND);
            }
            if (response.user.password != password)
            {
                return responseFactory.CreateResponse("Error: invalid password", ResponseStatus.BADREQUEST);
            }

            return response;
        }

        public Response Register(User user)
        {
            if (user.id != 0)
            {
                return responseFactory.CreateResponse("Error: invalid data", ResponseStatus.BADREQUEST);
            }

            if (user.name == null || user.lastName == null || user.password == null || user.email == null)
            {
                return responseFactory.CreateResponse("Error: missing data", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            try
            {
                response = userDao.GetUserByEmail(user.email);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            if (response.user != null)
            {
                return responseFactory.CreateResponse("Error: email alreay in use", ResponseStatus.BADREQUEST);
            }

            response = userDao.CreateUser(user);

            return response;
        }
    }
}
