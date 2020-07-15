 using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagmaPlayground_BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using MagmaPlayground_BackEnd.ResponseUtilities;

namespace MagmaPlayground_BackEnd.Daos
{
    public class UserDao
    {
        private MagmaDbContext magmaDbContext;
        private ResponseFactory responseFactory;
        private Response response;

        public UserDao(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            this.responseFactory = new ResponseFactory();
        }

        public Response GetUserById(int id)
        {
            response = new Response();

            response.user = magmaDbContext.Users.Find(id);
            response.message = "Success: found user";
            response.responseStatus = ResponseStatus.OK;

            return response;
        }

        public Response GetUserByEmail(string email)
        {
            response = new Response();

            response.user = magmaDbContext.Users.Single<User>(prop => prop.email == email);
            response.message = "Success: user found";
            response.responseStatus = ResponseStatus.OK;

            return response;
        }

        public Response CreateUser(User user)
        {
            int id;

            id = magmaDbContext.Add<User>(user).Entity.id;
            magmaDbContext.SaveChanges();

            return responseFactory.BuildIdResponse("Success: created user", ResponseStatus.OK, id);
        }

        public Response UpdateUser(User user)
        {
            int id;

            id = magmaDbContext.Update<User>(user).Entity.id;
            magmaDbContext.SaveChanges();

            return responseFactory.BuildIdResponse("Success: updated user", ResponseStatus.OK, id);
        }

        public Response DeleteUser(User user)
        {
            magmaDbContext.Remove<User>(user);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: deleted user", ResponseStatus.OK);
        }
    }
}
