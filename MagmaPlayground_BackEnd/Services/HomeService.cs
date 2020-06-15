using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Daos.Utilities;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Services
{
    public class HomeService
    {
        private ResponseFactory responseFactory;
        private Response response;
        private UserDao userDao;

        public HomeService(MagmaDbContext magmaDbContext)
        {
            this.response = new Response();
            this.userDao = new UserDao(magmaDbContext);
        }

        public Response Login(string email, string password)
        {
            if (email == null || password == null)
            {
                return responseFactory.BuildResponse("Error: invalid email or password", ResponseStatus.BADREQUEST);
            }

            response = userDao.GetUserByEmail(email);

            if (response.responseStatus != ResponseStatus.OK)
            {
                return responseFactory.BuildResponse(response.message, ResponseStatus.NOTFOUND);
            }
            if (response.user.password != password)
            {
                return responseFactory.BuildResponse("Error: invalid password", ResponseStatus.BADREQUEST);
            }

            return response;
        }

        public Response Register(User user)
        {
            if (user.name == null || user.lastName == null || user.password == null || user.email == null)
            {
                return responseFactory.BuildResponse("Error: missing data", ResponseStatus.BADREQUEST);
            }

            response = userDao.GetUserByEmail(user.email);

            if (response.user != null)
            {
                return responseFactory.BuildResponse("Error: email alreay in use", ResponseStatus.BADREQUEST);
            }

            response = userDao.CreateUser(user);

            return response;
        }
    }
}
