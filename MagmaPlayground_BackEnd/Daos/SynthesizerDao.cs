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
    public class SynthesizerDao
    {
        private MagmaDbContext magmaDbContext;
        private DaoResponseFactory daoResponseFactory;
        private DaoResponse daoResponse;

        public SynthesizerDao(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            this.daoResponseFactory = new DaoResponseFactory();
        }

        public DaoResponse GetSynthesizer(int id)
        {
            daoResponse = new DaoResponse();

            if (id == 0)
            {
                return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
            }

            daoResponse.synthesizer = magmaDbContext.Find<Synthesizer>(id);
            daoResponse.message = "Success: synthesizer found";
            daoResponse.isValid = true;

            if (daoResponse.synthesizer == null)
            {
                return daoResponseFactory.BuildDaoResponse("Error: synthesizer not found", false);
            }

            return daoResponse;
        }

        public DaoResponse CreateSynthesizer(Synthesizer synthesizer)
        {
            try
            {
                if (synthesizer == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }

                if (synthesizer.id != 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: synthesizer already exists, id must be null", false);
                }

                magmaDbContext.Add<Synthesizer>(synthesizer);
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

            return daoResponseFactory.BuildDaoResponse("Success: created synthesizer", true);
        }

        public DaoResponse UpdateSynthesizer(Synthesizer synthesizer)
        {
            try
            {
                if (synthesizer == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }

                if (synthesizer.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: synthesizer id is null", false);
                }

                magmaDbContext.Update<Synthesizer>(synthesizer);
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

            return daoResponseFactory.BuildDaoResponse("Success: updated synthesizer", true);
        }

        public DaoResponse DeleteSynthesizer(Synthesizer synthesizer)
        {
            try
            {
                if (synthesizer == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }

                if (synthesizer.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: synthesizer id is null", false);
                }

                magmaDbContext.Remove<Synthesizer>(synthesizer);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("exception: " + ex.InnerException.Message, false);
            }

            return daoResponseFactory.BuildDaoResponse("Success: removed synthesizer", true);
        }
    }
}
