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
            responseFactory = new ResponseFactory();
            response = new Response();
        }

        public Response GetUserById(int id)
        {
            response = responseFactory.CreateUserResponse();

            response.user = magmaDbContext.Users.Find(id);

            return responseFactory.UpdateResponse(response, "Success: found user", ResponseStatus.OK);
        }

        public Response GetUserByEmail(string email)
        {
            response = responseFactory.CreateUserResponse();

            response.user = magmaDbContext.Users.Single<User>(prop => prop.email == email);

            return responseFactory.UpdateResponse(response, "Success: user found", ResponseStatus.OK);
        }

        public Response CreateUser(User user)
        {
            response = responseFactory.CreateUserResponse();

            response.user.id = magmaDbContext.Add<User>(user).Entity.id;

            magmaDbContext.SaveChanges();

            return responseFactory.UpdateResponse(response, "Success: created user", ResponseStatus.OK);
        }

        public Response UpdateUser(User user)
        {
            response = responseFactory.CreateUserResponse();

            response.user.id = magmaDbContext.Update<User>(user).Entity.id;

            magmaDbContext.SaveChanges();

            return responseFactory.UpdateResponse(response, "Success: updated user", ResponseStatus.OK);
        }

        public Response DeleteUser(int id)
        {
            magmaDbContext.Remove<User>(GetUserById(id).user);

            magmaDbContext.SaveChanges();

            return responseFactory.CreateResponse("Success: deleted user", ResponseStatus.OK);
        }
    }
}
