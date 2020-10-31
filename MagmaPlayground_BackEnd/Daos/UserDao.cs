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

            return responseFactory.UpdateResponse(response, "Success: found user", ResponseStatus.OK);
        }

        public Response GetUserByEmail(string email)
        {
            response = new Response();

            response.user = magmaDbContext.Users.Single<User>(prop => prop.email == email);

            return responseFactory.UpdateResponse(response, "Success: user found", ResponseStatus.OK);
        }

        public Response CreateUser(User user)
        {
            response = new Response();

            response.user.id = magmaDbContext.Add<User>(user).Entity.id;

            magmaDbContext.SaveChanges();

            return responseFactory.UpdateResponse(response, "Success: created user", ResponseStatus.OK);
        }

        public Response UpdateUser(User user)
        {
            response = new Response();

            response.user.id = magmaDbContext.Update<User>(user).Entity.id;

            magmaDbContext.SaveChanges();

            return responseFactory.UpdateResponse(response, "Success: updated user", ResponseStatus.OK);
        }

        public Response DeleteUser(User user)
        {
            magmaDbContext.Remove<User>(user);

            magmaDbContext.SaveChanges();

            return responseFactory.CreateResponse("Success: deleted user", ResponseStatus.OK);
        }
    }
}
