using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;

namespace MagmaPlayground_BackEnd.Services
{
    public class UserService
    {
        private UserDao userDao;
        private DawResponseFactory responseFactory;
        private DawResponse response;

        public UserService(MagmaDawDbContext magmaDbContext)
        {
            userDao = new UserDao(magmaDbContext);
            responseFactory = new DawResponseFactory();
        }

        public DawResponse GetUserById(int userId)
        {
            if (userId == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = userDao.GetUserById(userId);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            if (response.user == null)
            {
                return responseFactory.CreateResponse("Error: user not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public DawResponse GetUserByEmail(string email)
        {
            if (email == null)
            {
                return responseFactory.CreateResponse("Error: input parameter email is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = userDao.GetUserByEmail(email);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            if (response.user == null)
            {
                return responseFactory.CreateResponse("Error: user not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public DawResponse CreateUser(User user)
        {
            if (user == null)
            {
                return responseFactory.CreateResponse("Error: input parameter user is null", ResponseStatus.BADREQUEST);
            }

            if (user.id != 0)
            {
                return responseFactory.CreateResponse("Error: user already exists, id must be null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = userDao.CreateUser(user);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public DawResponse UpdateUser(User user)
        {
            if (user == null)
            {
                return responseFactory.CreateResponse("Error: input parameter user is null", ResponseStatus.BADREQUEST);
            }

            if (user.id == 0)
            {
                return responseFactory.CreateResponse("Error: user id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = userDao.UpdateUser(user);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public DawResponse DeleteUser(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: user id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = userDao.DeleteUser(id);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }
    }
}
