using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Services
{
    public class AudioEffectService
    {
        private AudioEffectDao audioEffectDao;
        private ResponseFactory responseFactory;
        private Response response;

        public AudioEffectService(MagmaDbContext magmaDbContext)
        {
            audioEffectDao = new AudioEffectDao(magmaDbContext);
            responseFactory = new ResponseFactory();
        }

        public Response GetAudioEffectById(int id)
        {
            response = new Response();

            if (id == 0)
            {
                return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = audioEffectDao.GetAudioEffectById(id);

            if (response.audioEffect == null)
            {
                return responseFactory.BuildResponse("Error: audio effect not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetAudioEffectsByPluginId(int pluginId)
        {
            response = new Response();
            try
            {
                if (pluginId == 0)
                {
                    return responseFactory.BuildResponse("Error: id cannot be null", ResponseStatus.BADREQUEST);
                }

                response = audioEffectDao.GetAudioEffectsByPluginId(pluginId);

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
            response = new Response();
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


            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response UpdateAudioEffect(AudioEffect audioEffect)
        {
            response = new Response();
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

                response = audioEffectDao.UpdateAudioEffect(audioEffect);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response DeleteAudioEffect(AudioEffect audioEffect)
        {
            response = new Response();
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

                response = audioEffectDao.DeleteAudioEffect(audioEffect);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }
    }
}
