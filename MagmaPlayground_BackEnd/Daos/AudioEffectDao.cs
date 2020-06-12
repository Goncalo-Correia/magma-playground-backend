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
    public class AudioEffectDao
    {
        private MagmaDbContext magmaDbContext;
        private DaoResponseFactory daoResponseFactory;
        private DaoResponse daoResponse;

        public AudioEffectDao(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            this.daoResponseFactory = new DaoResponseFactory();
        }

        public DaoResponse GetAudioEffect(int id)
        {
            daoResponse = new DaoResponse();

            if (id == 0)
            {
                return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            daoResponse.audioEffect = magmaDbContext.Find<AudioEffect>(id);
            daoResponse.message = "Success: audio effect found";
            daoResponse.responseStatus = ResponseStatus.OK;

            if (daoResponse.audioEffect == null)
            {
                return daoResponseFactory.BuildDaoResponse("Error: audio effect not found", ResponseStatus.NOTFOUND);
            }

            return daoResponse;
        }

        public DaoResponse CreateAudioEffect(AudioEffect audioEffect)
        {
            try
            {
                if (audioEffect == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }
                if (audioEffect.id != 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: audio effect already exists, id must be null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Add<AudioEffect>(audioEffect);
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

            return daoResponseFactory.BuildDaoResponse("Success: created audio effect", ResponseStatus.OK);
        }

        public DaoResponse UpdateAudioEffect(AudioEffect audioEffect)
        {
            try
            {
                if (audioEffect == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }
                if (audioEffect.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: audio effect id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Update<AudioEffect>(audioEffect);
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

            return daoResponseFactory.BuildDaoResponse("Success: updated audio effect", ResponseStatus.OK);
        }

        public DaoResponse DeleteAudioEffect(AudioEffect audioEffect)
        {
            try
            {
                if (audioEffect == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }
                if (audioEffect.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: audio effect id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Remove<AudioEffect>(audioEffect);
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

            return daoResponseFactory.BuildDaoResponse("Success: removed audio effect", ResponseStatus.OK);
        } 
    }
}
