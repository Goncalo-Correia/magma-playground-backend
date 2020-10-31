using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;

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
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            try
            {
                response = audioEffectDao.GetAudioEffectById(id);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            if (response.audioEffect == null)
            {
                return responseFactory.CreateResponse("Error: audio effect not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetAudioEffectByPluginId(int pluginId)
        {
            if (pluginId == 0)
            {
                return responseFactory.CreateResponse("Error: id cannot be null", ResponseStatus.BADREQUEST);
            }
            
            response = new Response();
            
            try
            {
                response = audioEffectDao.GetAudioEffectByPluginId(pluginId);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            if (response.audioEffects == null)
            {
                return responseFactory.CreateResponse("Error: audio effects not found for this plugin", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response CreateAudioEffect(AudioEffect audioEffect)
        {

            if (audioEffect == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }
            if (audioEffect.id != 0)
            {
                return responseFactory.CreateResponse("Error: audio effect already exists, id must be null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            try
            {
                response = audioEffectDao.CreateAudioEffect(audioEffect);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response UpdateAudioEffect(AudioEffect audioEffect)
        {
            if (audioEffect == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }
            if (audioEffect.id == 0)
            {
                return responseFactory.CreateResponse("Error: audio effect id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            try
            {
                response = audioEffectDao.UpdateAudioEffect(audioEffect);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response DeleteAudioEffect(AudioEffect audioEffect)
        {

            if (audioEffect == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }
            if (audioEffect.id == 0)
            {
                return responseFactory.CreateResponse("Error: audio effect id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            try
            {
                response = audioEffectDao.DeleteAudioEffect(audioEffect);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }
    }
}
