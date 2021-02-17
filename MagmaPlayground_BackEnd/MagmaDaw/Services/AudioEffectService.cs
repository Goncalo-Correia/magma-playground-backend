using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;
using System.Net;

namespace MagmaPlayground_BackEnd.Services
{
    public class AudioEffectService
    {
        private AudioEffectDao audioEffectDao;
        private DawResponseFactory dawResponseFactory;
        private DawResponse dawResponse;

        public AudioEffectService(MagmaDawDbContext magmaDbContext)
        {
            audioEffectDao = new AudioEffectDao(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }


        public DawResponse GetAudioEffectById(int id)
        {
            dawResponse = new DawResponse();

            if (id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: audioEffect.id", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.audioEffect = audioEffectDao.GetAudioEffectById(id);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.audioEffect == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: audioEffect not found", HttpStatusCode.NotFound);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse GetAudioEffectByPluginId(int pluginId)
        {
            dawResponse = new DawResponse();

            if (pluginId == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: pluginId cannot be null", HttpStatusCode.BadRequest);
            }
            
            try
            {
                dawResponse.audioEffect = audioEffectDao.GetAudioEffectByPluginId(pluginId);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.audioEffect == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: audioEffect not found", HttpStatusCode.NotFound);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse CreateAudioEffect(AudioEffect audioEffect)
        {
            dawResponse = new DawResponse();

            if (audioEffect == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: audioEffect is null", HttpStatusCode.BadRequest);
            }
            if (audioEffect.id != 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: audioEffect.id is not null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.audioEffect = audioEffectDao.CreateAudioEffect(audioEffect);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse UpdateAudioEffect(AudioEffect audioEffect)
        {
            dawResponse = new DawResponse();

            if (audioEffect == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: audioEffect is nulll", HttpStatusCode.BadRequest);
            }
            if (audioEffect.id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: audioEffect.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.audioEffect = audioEffectDao.UpdateAudioEffect(audioEffect);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse DeleteAudioEffect(AudioEffect audioEffect)
        {
            dawResponse = new DawResponse();

            if (audioEffect.id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: audioEffect.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                audioEffectDao.DeleteAudioEffect(audioEffect);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }
    }
}
