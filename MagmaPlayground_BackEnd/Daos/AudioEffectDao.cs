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
        private ResponseFactory responseFactory;
        private Response response;

        public AudioEffectDao(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            this.responseFactory = new ResponseFactory();
        }

        public Response GetAudioEffect(int id)
        {
            response = new Response();

            if (id == 0)
            {
                return responseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response.audioEffect = magmaDbContext.Find<AudioEffect>(id);
            response.message = "Success: audio effect found";
            response.responseStatus = ResponseStatus.OK;

            if (response.audioEffect == null)
            {
                return responseFactory.BuildDaoResponse("Error: audio effect not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetAudioEffectsByPluginId(int pluginId)
        {
            try
            {
                if (pluginId == 0)
                {
                    return responseFactory.BuildDaoResponse("Error: id cannot be null", ResponseStatus.BADREQUEST);
                }

                response.audioEffects = magmaDbContext.AudioEffects.Where<AudioEffect>(prop => prop.plugin.id == pluginId).ToList();
                response.message = "Success: audio effects found";
                response.responseStatus = ResponseStatus.OK;

                if (response.audioEffects == null)
                {
                    return responseFactory.BuildDaoResponse("Error: audio effects not found for this plugin", ResponseStatus.NOTFOUND);
                }

            }
            catch (ArgumentNullException ex)
            {
                return responseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;

        }

        public Response CreateAudioEffect(AudioEffect audioEffect)
        {
            try
            {
                if (audioEffect == null)
                {
                    return responseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }
                if (audioEffect.id != 0)
                {
                    return responseFactory.BuildDaoResponse("Error: audio effect already exists, id must be null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Add<AudioEffect>(audioEffect);
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

            return responseFactory.BuildDaoResponse("Success: created audio effect", ResponseStatus.OK);
        }

        public Response UpdateAudioEffect(AudioEffect audioEffect)
        {
            try
            {
                if (audioEffect == null)
                {
                    return responseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }
                if (audioEffect.id == 0)
                {
                    return responseFactory.BuildDaoResponse("Error: audio effect id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Update<AudioEffect>(audioEffect);
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

            return responseFactory.BuildDaoResponse("Success: updated audio effect", ResponseStatus.OK);
        }

        public Response DeleteAudioEffect(AudioEffect audioEffect)
        {
            try
            {
                if (audioEffect == null)
                {
                    return responseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }
                if (audioEffect.id == 0)
                {
                    return responseFactory.BuildDaoResponse("Error: audio effect id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Remove<AudioEffect>(audioEffect);
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

            return responseFactory.BuildDaoResponse("Success: removed audio effect", ResponseStatus.OK);
        } 
    }
}
