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
            responseFactory = new ResponseFactory();
            response = new Response();
        }

        public Response GetAudioEffectById(int id)
        {
            response = responseFactory.CreateAudioEffectResponse();

            response.audioEffect = magmaDbContext.Find<AudioEffect>(id);

            return responseFactory.UpdateResponse(response, "Success: audio effect found", ResponseStatus.OK);
        }

        public Response GetAudioEffectByPluginId(int pluginId)
        {
            response = responseFactory.CreateAudioEffectResponse();

            response.audioEffect = magmaDbContext.AudioEffects.SingleOrDefault<AudioEffect>(prop => prop.pluginId == pluginId);

            return responseFactory.UpdateResponse(response, "Success: audio effects found", ResponseStatus.OK);
        }

        public Response CreateAudioEffect(AudioEffect audioEffect)
        {
            response = responseFactory.CreateAudioEffectResponse();

            response.audioEffect.id = magmaDbContext.Add<AudioEffect>(audioEffect).Entity.id;

            magmaDbContext.SaveChanges();

            return responseFactory.UpdateResponse(response, "Success: created audio effect", ResponseStatus.OK);
        }

        public Response UpdateAudioEffect(AudioEffect audioEffect)
        {
            response = responseFactory.CreateAudioEffectResponse();

            response.audioEffect.id = magmaDbContext.Update<AudioEffect>(audioEffect).Entity.id;

            magmaDbContext.SaveChanges();

            return responseFactory.UpdateResponse(response, "Success: updated audio effect", ResponseStatus.OK);
        }

        public Response DeleteAudioEffect(int id)
        {
            magmaDbContext.Remove<AudioEffect>(GetAudioEffectById(id).audioEffect);

            magmaDbContext.SaveChanges();

            return responseFactory.CreateResponse("Success: removed audio effect", ResponseStatus.OK);
        } 
    }
}
