﻿using MagmaPlayground_BackEnd.Daos.Utilities;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
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
                return daoResponseFactory.BuildDaoResponse("Error: input parameter id is null", false);
            }

            daoResponse.sampler = magmaDbContext.Find<Sampler>(id);
            daoResponse.message = "Success: sampler found";
            daoResponse.isValid = true;

            if (daoResponse.sampler == null)
            {
                return daoResponseFactory.BuildDaoResponse("Error: track not found", false);
            }

            return daoResponse;
        }

        public DaoResponse CreateSampler(Sampler sampler)
        {
            try
            {
                if (sampler == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }
                if (sampler.id != 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: sampler already exists, id must be null", false);
                }

                magmaDbContext.Add<Sampler>(sampler);
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

            return daoResponseFactory.BuildDaoResponse("Success: created sampler", true);
        }

        public DaoResponse UpdateSampler(Sampler sampler)
        {
            try
            {
                if (sampler == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }
                if (sampler.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: sampler id is null", false);
                }

                magmaDbContext.Update<Sampler>(sampler);
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

            return daoResponseFactory.BuildDaoResponse("Success: updated sampler", true);
        }

        public DaoResponse DeleteSampler(Sampler sampler)
        {
            try
            {
                if (sampler == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }
                if (sampler.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: sampler id is null", false);
                }

                magmaDbContext.Remove<Sampler>(sampler);
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

            return daoResponseFactory.BuildDaoResponse("Success: removed sampler", true);
        }
    }
}
