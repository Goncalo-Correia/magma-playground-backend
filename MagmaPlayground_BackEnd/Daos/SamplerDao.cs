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
    public class SamplerDao
    {
        private MagmaDbContext magmaDbContext;
        private ResponseFactory responseFactory;
        private Response response;

        public SamplerDao(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            responseFactory = new ResponseFactory();
        }

        public Response GetSamplerById(int id)
        {
            response = new Response();
            
            response.sampler = magmaDbContext.Find<Sampler>(id);
            response.message = "Success: sampler found";
            response.responseStatus = ResponseStatus.OK;

            return response;
        }

        public Response GetSamplerByPluginId(int pluginId)
        {
            response = new Response();

            response.sampler = magmaDbContext.Samplers.Single<Sampler>(prop => prop.pluginId == pluginId);
            response.message = "Success: sampler found";
            response.responseStatus = ResponseStatus.OK;

            return response;
        }

        public Response CreateSampler(Sampler sampler)
        {
            int id;

            id = magmaDbContext.Add<Sampler>(sampler).Entity.id;
            magmaDbContext.SaveChanges();

            return responseFactory.BuildIdResponse("Success: created sampler", ResponseStatus.OK, id);
        }

        public Response UpdateSampler(Sampler sampler)
        {
            int id;

            id = magmaDbContext.Update<Sampler>(sampler).Entity.id;
            magmaDbContext.SaveChanges();

            return responseFactory.BuildIdResponse("Success: updated sampler", ResponseStatus.OK, id);
        }

        public Response DeleteSampler(Sampler sampler)
        {
            magmaDbContext.Remove<Sampler>(sampler);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: removed sampler", ResponseStatus.OK);
        }
    }
}
