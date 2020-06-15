using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
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
                return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response.audioEffect = magmaDbContext.Find<AudioEffect>(id);
            response.message = "Success: audio effect found";
            response.responseStatus = ResponseStatus.OK;

            if (response.audioEffect == null)
            {
                return responseFactory.BuildResponse("Error: audio effect not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetAudioEffectsByPluginId(int pluginId)
        {
            try
            {
                if (pluginId == 0)
                {
                    return responseFactory.BuildResponse("Error: id cannot be null", ResponseStatus.BADREQUEST);
                }

                response.audioEffects = magmaDbContext.AudioEffects.Where<AudioEffect>(prop => prop.plugin.id == pluginId).ToList();
                response.message = "Success: audio effects found";
                response.responseStatus = ResponseStatus.OK;

                if (response.audioEffects == null)
                {
                    return responseFactory.BuildResponse("Error: audio effects not found for this plugin", ResponseStatus.NOTFOUND);
                }

            }
            catch (ArgumentNullException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;

        }

        public Response CreateAudioEffect(AudioEffect audioEffect)
        {
            try
            {
                if (audioEffect == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }
                if (audioEffect.id != 0)
                {
                    return responseFactory.BuildResponse("Error: audio effect already exists, id must be null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Add<AudioEffect>(audioEffect);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return responseFactory.BuildResponse("Success: created audio effect", ResponseStatus.OK);
        }

        public Response UpdateAudioEffect(AudioEffect audioEffect)
        {
            try
            {
                if (audioEffect == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }
                if (audioEffect.id == 0)
                {
                    return responseFactory.BuildResponse("Error: audio effect id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Update<AudioEffect>(audioEffect);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return responseFactory.BuildResponse("Success: updated audio effect", ResponseStatus.OK);
        }

        public Response DeleteAudioEffect(AudioEffect audioEffect)
        {
            try
            {
                if (audioEffect == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }
                if (audioEffect.id == 0)
                {
                    return responseFactory.BuildResponse("Error: audio effect id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Remove<AudioEffect>(audioEffect);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return responseFactory.BuildResponse("Success: removed audio effect", ResponseStatus.OK);
        } 
    }
}
