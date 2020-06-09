using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.Daos.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagmaPlayground_BackEnd.Model;
using Microsoft.EntityFrameworkCore;

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
                return daoResponseFactory.BuildDaoResponse("Error: input parameter id is null", false);
            }

            daoResponse.user = magmaDbContext.Users.Find(id);
            daoResponse.message = "Success: found user";
            daoResponse.isValid = true;

            if (daoResponse.user == null)
            {
                return daoResponseFactory.BuildDaoResponse("Error: user not found", false);
            }

            return daoResponse;
        }

        public DaoResponse CreateUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter user is null", false);
                }

                if (user.id != 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: user already exists, id must be null", false);
                }

                magmaDbContext.Add<User>(user);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }

            return daoResponseFactory.BuildDaoResponse("Success: created user", true);
        }

        public DaoResponse UpdateUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter user is null", false);
                }

                if (user.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: user id is null", false);
                }

                magmaDbContext.Update<User>(user);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }

            return daoResponseFactory.BuildDaoResponse("Success: updated user", true);
        }

        public DaoResponse DeleteUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter user is null", false);
                }

                if (user.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: user id is null", false);
                }

                magmaDbContext.Remove<User>(user);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }

            return daoResponseFactory.BuildDaoResponse("Success: deleted user", true);
        }
    }
}
