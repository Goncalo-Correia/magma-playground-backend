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
        private ResponseFactory responseFactory;
        private Response response;

        public UserService(MagmaDawDbContext magmaDbContext)
        {
            userDao = new UserDao(magmaDbContext);
            responseFactory = new ResponseFactory();
        }

        public Response GetUserById(int userId)
        {
            if (userId == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

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

        public Response GetUserByEmail(string email)
        {
            if (email == null)
            {
                return responseFactory.CreateResponse("Error: input parameter email is null", ResponseStatus.BADREQUEST);
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

            if (response.user == null)
            {
                return responseFactory.CreateResponse("Error: user not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response CreateUser(User user)
        {
            if (user == null)
            {
                return responseFactory.CreateResponse("Error: input parameter user is null", ResponseStatus.BADREQUEST);
            }

            if (user.id != 0)
            {
                return responseFactory.CreateResponse("Error: user already exists, id must be null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

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

        public Response UpdateUser(User user)
        {
            if (user == null)
            {
                return responseFactory.CreateResponse("Error: input parameter user is null", ResponseStatus.BADREQUEST);
            }

            if (user.id == 0)
            {
                return responseFactory.CreateResponse("Error: user id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

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

        public Response DeleteUser(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: user id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

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
