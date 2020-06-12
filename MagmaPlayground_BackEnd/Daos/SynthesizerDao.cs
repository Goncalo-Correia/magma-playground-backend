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
                return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            daoResponse.synthesizer = magmaDbContext.Find<Synthesizer>(id);
            daoResponse.message = "Success: synthesizer found";
            daoResponse.responseStatus = ResponseStatus.OK;

            if (daoResponse.synthesizer == null)
            {
                return daoResponseFactory.BuildDaoResponse("Error: synthesizer not found", ResponseStatus.NOTFOUND);
            }

            return daoResponse;
        }

        public DaoResponse CreateSynthesizer(Synthesizer synthesizer)
        {
            try
            {
                if (synthesizer == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (synthesizer.id != 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: synthesizer already exists, id must be null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Add<Synthesizer>(synthesizer);
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

            return daoResponseFactory.BuildDaoResponse("Success: created synthesizer", ResponseStatus.OK);
        }

        public DaoResponse UpdateSynthesizer(Synthesizer synthesizer)
        {
            try
            {
                if (synthesizer == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (synthesizer.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: synthesizer id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Update<Synthesizer>(synthesizer);
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

            return daoResponseFactory.BuildDaoResponse("Success: updated synthesizer", ResponseStatus.OK);
        }

        public DaoResponse DeleteSynthesizer(Synthesizer synthesizer)
        {
            try
            {
                if (synthesizer == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (synthesizer.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: synthesizer id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Remove<Synthesizer>(synthesizer);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return daoResponseFactory.BuildDaoResponse("Success: removed synthesizer", ResponseStatus.OK);
        }
    }
}
