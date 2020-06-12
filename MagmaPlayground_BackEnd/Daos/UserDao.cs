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
        private DaoResponseFactory daoResponseFactory;
        private DaoResponse daoResponse;

        public UserDao(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            this.daoResponseFactory = new DaoResponseFactory();
        }

        public DaoResponse GetUser(int id)
        {
            daoResponse = new DaoResponse();

            if (id == 0)
            {
                return daoResponseFactory.BuildDaoResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
            }

            daoResponse.user = magmaDbContext.Users.Find(id);
            daoResponse.message = "Success: found user";
            daoResponse.responseStatus = ResponseStatus.OK;

            if (daoResponse.user == null)
            {
                return daoResponseFactory.BuildDaoResponse("Error: user not found", ResponseStatus.NOTFOUND);
            }

            return daoResponse;
        }

        public DaoResponse GetUserByEmail(string email)
        {
            daoResponse = new DaoResponse();

            try
            {
                if (email == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter email is null", ResponseStatus.BADREQUEST);
                }

                daoResponse.user = magmaDbContext.Users.Single<User>(prop => prop.email == email);
                daoResponse.message = "Success: user found";
                daoResponse.responseStatus = ResponseStatus.OK;

                if (daoResponse.user == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: user not found", ResponseStatus.NOTFOUND);
                }
            }
            catch (ArgumentNullException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);

            }
            catch (InvalidOperationException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);

            }

            return daoResponse;
        }

        public DaoResponse CreateUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter user is null", ResponseStatus.BADREQUEST);
                }

                if (user.id != 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: user already exists, id must be null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Add<User>(user);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return daoResponseFactory.BuildDaoResponse("Success: created user", ResponseStatus.OK);
        }

        public DaoResponse UpdateUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter user is null", ResponseStatus.BADREQUEST);
                }

                if (user.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: user id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Update<User>(user);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return daoResponseFactory.BuildDaoResponse("Success: updated user", ResponseStatus.OK);
        }

        public DaoResponse DeleteUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter user is null", ResponseStatus.BADREQUEST);
                }

                if (user.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: user id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Remove<User>(user);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return daoResponseFactory.BuildDaoResponse("Success: deleted user", ResponseStatus.OK);
        }
    }
}
