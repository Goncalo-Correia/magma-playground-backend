using MagmaPlayground_BackEnd.Daos.Utilities;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Daos
{
    public class SamplerDao
    {
        private MagmaDbContext magmaDbContext;
        private DaoResponseFactory daoResponseFactory;
        private DaoResponse daoResponse;

        public SamplerDao(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            daoResponseFactory = new DaoResponseFactory();
        }

        public DaoResponse GetSampler(int id)
        {
            daoResponse = new DaoResponse();
            
            if (id == 0)
            {
                return daoResponseFactory.BuildDaoResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
            }

            daoResponse.sampler = magmaDbContext.Find<Sampler>(id);
            daoResponse.message = "Success: sampler found";
            daoResponse.responseStatus = ResponseStatus.OK;

            if (daoResponse.sampler == null)
            {
                return daoResponseFactory.BuildDaoResponse("Error: track not found", ResponseStatus.NOTFOUND);
            }

            return daoResponse;
        }

        public DaoResponse CreateSampler(Sampler sampler)
        {
            try
            {
                if (sampler == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }
                if (sampler.id != 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: sampler already exists, id must be null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Add<Sampler>(sampler);
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

            return daoResponseFactory.BuildDaoResponse("Success: created sampler", ResponseStatus.OK);
        }

        public DaoResponse UpdateSampler(Sampler sampler)
        {
            try
            {
                if (sampler == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }
                if (sampler.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: sampler id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Update<Sampler>(sampler);
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

            return daoResponseFactory.BuildDaoResponse("Success: updated sampler", ResponseStatus.OK);
        }

        public DaoResponse DeleteSampler(Sampler sampler)
        {
            try
            {
                if (sampler == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }
                if (sampler.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: sampler id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Remove<Sampler>(sampler);
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

            return daoResponseFactory.BuildDaoResponse("Success: removed sampler", ResponseStatus.OK);
        }
    }
}
