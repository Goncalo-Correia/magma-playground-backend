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
        private DawResponseFactory responseFactory;
        private DawResponse response;

        public AudioEffectService(MagmaDawDbContext magmaDbContext)
        {
            audioEffectDao = new AudioEffectDao(magmaDbContext);
            responseFactory = new DawResponseFactory();
        }

        public DawResponse GetAudioEffectById(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

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

        public DawResponse GetAudioEffectByPluginId(int pluginId)
        {
            if (pluginId == 0)
            {
                return responseFactory.CreateResponse("Error: id cannot be null", ResponseStatus.BADREQUEST);
            }
            
            response = new DawResponse();
            
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

        public DawResponse CreateAudioEffect(AudioEffect audioEffect)
        {

            if (audioEffect == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }
            if (audioEffect.id != 0)
            {
                return responseFactory.CreateResponse("Error: audio effect already exists, id must be null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

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

        public DawResponse UpdateAudioEffect(AudioEffect audioEffect)
        {
            if (audioEffect == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }
            if (audioEffect.id == 0)
            {
                return responseFactory.CreateResponse("Error: audio effect id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

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

        public DawResponse DeleteAudioEffect(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: audio effect id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = audioEffectDao.DeleteAudioEffect(id);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }
    }
}
