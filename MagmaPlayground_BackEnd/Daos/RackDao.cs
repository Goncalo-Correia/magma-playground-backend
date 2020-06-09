using MagmaPlayground_BackEnd.Daos.Utilities;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Daos
{
    public class RackDao
    {
        private MagmaDbContext magmaDbContext;
        private DaoResponseFactory daoResponseFactory;
        private DaoResponse daoResponse;

        public RackDao(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            this.daoResponseFactory = new DaoResponseFactory();
        }

        public DaoResponse GetRack(int id)
        {
            daoResponse = new DaoResponse();

            if (id == 0)
            {
                return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
            }

            daoResponse.rack = magmaDbContext.Find<Rack>(id);
            daoResponse.message = "Success: found track";
            daoResponse.isValid = true;

            if (daoResponse.rack == null)
            {
                return daoResponseFactory.BuildDaoResponse("Error: rack not found", false);
            }

            return daoResponse;
        }

        public DaoResponse CreateRack(Rack rack)
        {
            try
            {
                if (rack == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }

                if (rack.id != 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: rack already exists, id must be null", false);
                }

                magmaDbContext.Add<Rack>(rack);
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

            return daoResponseFactory.BuildDaoResponse("Success: created rack", false);
        }

        public DaoResponse UpdateRack(Rack rack)
        {
            try
            {
                if (rack == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }

                if (rack.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: rack id is null", false);
                }

                magmaDbContext.Update<Rack>(rack);
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

            return daoResponseFactory.BuildDaoResponse("Success: updated rack", true);
        }

        public DaoResponse DeleteRack(Rack rack)
        {
            try
            {
                if (rack == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }

                if (rack.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: rack id is null", false);
                }

                magmaDbContext.Remove<Rack>(rack);
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

            return daoResponseFactory.BuildDaoResponse("Success: removed rack", true);
        }
    }
}
