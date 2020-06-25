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

            response.sampler = magmaDbContext.Samplers.Single<Sampler>(prop => prop.plugin.id == pluginId);
            response.message = "Success: sampler found";
            response.responseStatus = ResponseStatus.OK;

            return response;
        }

        public Response CreateSampler(Sampler sampler)
        {
            magmaDbContext.Add<Sampler>(sampler);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: created sampler", ResponseStatus.OK);
        }

        public Response UpdateSampler(Sampler sampler)
        {
            magmaDbContext.Update<Sampler>(sampler);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: updated sampler", ResponseStatus.OK);
        }

        public Response DeleteSampler(Sampler sampler)
        {
            magmaDbContext.Remove<Sampler>(sampler);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: removed sampler", ResponseStatus.OK);
        }
    }
}
