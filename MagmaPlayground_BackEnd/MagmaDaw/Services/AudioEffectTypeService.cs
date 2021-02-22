using MagmaPlayground_BackEnd.MagmaDaw.Daos;
using MagmaPlayground_BackEnd.MagmaDaw.Models;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaDaw.Services
{
    public class AudioEffectTypeService
    {
        private AudioEffectTypeDao audioEffectTypeDao;
        private DawResponseFactory dawResponseFactory;
        private DawResponse dawResponse;

        public AudioEffectTypeService(MagmaDawDbContext magmaDbContext)
        {
            audioEffectTypeDao = new AudioEffectTypeDao(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }


        public DawResponse GetAudioEffectTypeById(int id)
        {
            dawResponse = new DawResponse();

            if (id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: audioEffectType.id", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.audioEffectType = audioEffectTypeDao.GetAudioEffectTypeById(id);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.audioEffectType == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: audioEffectType not found", HttpStatusCode.NotFound);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse GetAudioEffectTypes()
        {
            dawResponse = new DawResponse();

            try
            {
                dawResponse.audioEffectTypes = audioEffectTypeDao.GetAudioEffectTypes();
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.audioEffectTypes == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: audioEffectTypes not found", HttpStatusCode.NotFound);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse CreateAudioEffectType(AudioEffectType audioEffectType)
        {
            dawResponse = new DawResponse();

            if (audioEffectType == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: audioEffectType is null", HttpStatusCode.BadRequest);
            }
            if (audioEffectType.id != 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: audioEffectType.id is not null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.audioEffectType = audioEffectTypeDao.CreateAudioEffectType(audioEffectType);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse UpdateAudioEffectType(AudioEffectType audioEffectType)
        {
            dawResponse = new DawResponse();

            if (audioEffectType == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: audioEffectType is nulll", HttpStatusCode.BadRequest);
            }
            if (audioEffectType.id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: audioEffectType.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.audioEffectType = audioEffectTypeDao.UpdateAudioEffectType(audioEffectType);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse DeleteAudioEffectType(int id)
        {
            dawResponse = new DawResponse();

            if (id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: audioEffectType.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                audioEffectTypeDao.DeleteAudioEffectType(GetAudioEffectTypeById(id).audioEffectType);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }
    }
}
