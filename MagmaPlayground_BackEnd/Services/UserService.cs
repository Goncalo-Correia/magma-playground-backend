using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Services
{
    public class UserService
    {
        private UserDao userDao;
        private ResponseFactory responseFactory;
        private Response response;

        public UserService(MagmaDbContext magmaDbContext)
        {
            userDao = new UserDao(magmaDbContext);
            responseFactory = new ResponseFactory();
        }

        public Response GetUserById(int userId)
        {
            response = new Response();
            if (userId == 0)
            {
                return responseFactory.BuildResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
            }

            response = userDao.GetUserById(userId);

            if (response.user == null)
            {
                return responseFactory.BuildResponse("Error: user not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetUserByEmail(string email)
        {
            response = new Response();
            try
            {
                if (email == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter email is null", ResponseStatus.BADREQUEST);
                }

                response = userDao.GetUserByEmail(email);

                if (response.user == null)
                {
                    return responseFactory.BuildResponse("Error: user not found", ResponseStatus.NOTFOUND);
                }
            }
            catch (ArgumentNullException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (InvalidOperationException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response CreateUser(User user)
        {
            response = new Response();
            try
            {
                if (user == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter user is null", ResponseStatus.BADREQUEST);
                }

                if (user.id != 0)
                {
                    return responseFactory.BuildResponse("Error: user already exists, id must be null", ResponseStatus.BADREQUEST);
                }

                response = userDao.CreateUser(user);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response UpdateUser(User user)
        {
            response = new Response();
            try
            {
                if (user == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter user is null", ResponseStatus.BADREQUEST);
                }

                if (user.id == 0)
                {
                    return responseFactory.BuildResponse("Error: user id is null", ResponseStatus.BADREQUEST);
                }

                response = userDao.UpdateUser(user);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response DeleteUser(User user)
        {
            response = new Response();
            try
            {
                if (user == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter user is null", ResponseStatus.BADREQUEST);
                }

                if (user.id == 0)
                {
                    return responseFactory.BuildResponse("Error: user id is null", ResponseStatus.BADREQUEST);
                }

                response = userDao.DeleteUser(user);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }
    }
}
