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
                return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
            }

            daoResponse.audioEffect = magmaDbContext.Find<AudioEffect>(id);
            daoResponse.message = "Success: audio effect found";
            daoResponse.isValid = true;

            if (daoResponse.audioEffect == null)
            {
                return daoResponseFactory.BuildDaoResponse("Error: audio effect not found", false);
            }

            return daoResponse;
        }

        public DaoResponse CreateAudioEffect(AudioEffect audioEffect)
        {
            try
            {
                if (audioEffect == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }
                if (audioEffect.id != 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: audio effect already exists, id must be null", false);
                }

                magmaDbContext.Add<AudioEffect>(audioEffect);
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

            return daoResponseFactory.BuildDaoResponse("Success: created audio effect", true);
        }

        public DaoResponse UpdateAudioEffect(AudioEffect audioEffect)
        {
            try
            {
                if (audioEffect == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }
                if (audioEffect.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: audio effect id is null", false);
                }

                magmaDbContext.Update<AudioEffect>(audioEffect);
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

            return daoResponseFactory.BuildDaoResponse("Success: updated audio effect", true);
        }

        public DaoResponse DeleteAudioEffect(AudioEffect audioEffect)
        {
            try
            {
                if (audioEffect == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }
                if (audioEffect.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: audio effect id is null", false);
                }

                magmaDbContext.Remove<AudioEffect>(audioEffect);
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

            return daoResponseFactory.BuildDaoResponse("Success: removed audio effect", true);
        } 
    }
}
