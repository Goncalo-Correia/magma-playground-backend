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

        public Response GetAudioEffectById(int id)
        {
            response = new Response();

            response.audioEffect = magmaDbContext.Find<AudioEffect>(id);
            response.message = "Success: audio effect found";
            response.responseStatus = ResponseStatus.OK;

            return response;
        }

        public Response GetAudioEffectByPluginId(int pluginId)
        {
            response.audioEffect = magmaDbContext.AudioEffects.Single<AudioEffect>(prop => prop.pluginId == pluginId);
            response.message = "Success: audio effects found";
            response.responseStatus = ResponseStatus.OK;

            return response;
        }

        public Response CreateAudioEffect(AudioEffect audioEffect)
        {
            magmaDbContext.Add<AudioEffect>(audioEffect);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: created audio effect", ResponseStatus.OK);
        }

        public Response UpdateAudioEffect(AudioEffect audioEffect)
        {
            magmaDbContext.Update<AudioEffect>(audioEffect);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: updated audio effect", ResponseStatus.OK);
        }

        public Response DeleteAudioEffect(AudioEffect audioEffect)
        {
            magmaDbContext.Remove<AudioEffect>(audioEffect);
            magmaDbContext.SaveChanges();


            return responseFactory.BuildResponse("Success: removed audio effect", ResponseStatus.OK);
        } 
    }
}
