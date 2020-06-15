 using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.Daos.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagmaPlayground_BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using MagmaPlayground_BackEnd.Utilities;

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

        public Response GetUser(int id)
        {
            response = new Response();

            if (id == 0)
            {
                return responseFactory.BuildDaoResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
            }

            response.user = magmaDbContext.Users.Find(id);
            response.message = "Success: found user";
            response.responseStatus = ResponseStatus.OK;

            if (response.user == null)
            {
                return responseFactory.BuildDaoResponse("Error: user not found", ResponseStatus.NOTFOUND);
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
                    return responseFactory.BuildDaoResponse("Error: input parameter email is null", ResponseStatus.BADREQUEST);
                }

                response.user = magmaDbContext.Users.Single<User>(prop => prop.email == email);
                response.message = "Success: user found";
                response.responseStatus = ResponseStatus.OK;

                if (response.user == null)
                {
                    return responseFactory.BuildDaoResponse("Error: user not found", ResponseStatus.NOTFOUND);
                }
            }
            catch (ArgumentNullException ex)
            {
                return responseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);

            }
            catch (InvalidOperationException ex)
            {
                return responseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);

            }

            return response;
        }

        public Response CreateUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return responseFactory.BuildDaoResponse("Error: input parameter user is null", ResponseStatus.BADREQUEST);
                }

                if (user.id != 0)
                {
                    return responseFactory.BuildDaoResponse("Error: user already exists, id must be null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Add<User>(user);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return responseFactory.BuildDaoResponse("Success: created user", ResponseStatus.OK);
        }

        public Response UpdateUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return responseFactory.BuildDaoResponse("Error: input parameter user is null", ResponseStatus.BADREQUEST);
                }

                if (user.id == 0)
                {
                    return responseFactory.BuildDaoResponse("Error: user id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Update<User>(user);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return responseFactory.BuildDaoResponse("Success: updated user", ResponseStatus.OK);
        }

        public Response DeleteUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return responseFactory.BuildDaoResponse("Error: input parameter user is null", ResponseStatus.BADREQUEST);
                }

                if (user.id == 0)
                {
                    return responseFactory.BuildDaoResponse("Error: user id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Remove<User>(user);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return responseFactory.BuildDaoResponse("Success: deleted user", ResponseStatus.OK);
        }
    }
}
