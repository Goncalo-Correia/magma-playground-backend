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
            if (userId == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = userDao.GetUserById(userId);

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

            response = userDao.GetUserByEmail(email);

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

            response = userDao.CreateUser(user);

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

            response = userDao.UpdateUser(user);

            return response;
        }

        public Response DeleteUser(User user)
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

            response = userDao.DeleteUser(user);

            return response;
        }
    }
}
