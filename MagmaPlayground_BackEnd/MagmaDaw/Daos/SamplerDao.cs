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
        private MagmaDawDbContext magmaDbContext;
        private ResponseFactory responseFactory;
        private Response response;

        public SamplerDao(MagmaDawDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            responseFactory = new ResponseFactory();
            response = new Response();
        }

        public Response GetSamplerById(int id)
        {
            response = responseFactory.CreateSamplerResponse();
            
            response.sampler = magmaDbContext.Find<Sampler>(id);

            return responseFactory.UpdateResponse(response, "Success: sampler found", ResponseStatus.OK);
        }

        public Response GetSamplerByPluginId(int pluginId)
        {
            response = responseFactory.CreateSamplerResponse();

            response.sampler = magmaDbContext.Samplers.SingleOrDefault<Sampler>(prop => prop.pluginId == pluginId);

            return responseFactory.UpdateResponse(response, "Success: sampler found", ResponseStatus.OK);
        }

        public Response CreateSampler(Sampler sampler)
        {
            response = responseFactory.CreateSamplerResponse();

            response.plugin.id = magmaDbContext.Add<Sampler>(sampler).Entity.id;

            magmaDbContext.SaveChanges();

            return responseFactory.UpdateResponse(response, "Success: created sampler", ResponseStatus.OK);
        }

        public Response UpdateSampler(Sampler sampler)
        {
            response = responseFactory.CreateSamplerResponse();

            response.sampler.id = magmaDbContext.Update<Sampler>(sampler).Entity.id;

            magmaDbContext.SaveChanges();

            return responseFactory.UpdateResponse(response, "Success: updated sampler", ResponseStatus.OK);
        }

        public Response DeleteSampler(int id)
        {
            magmaDbContext.Remove<Sampler>(GetSamplerById(id).sampler);

            magmaDbContext.SaveChanges();

            return responseFactory.CreateResponse("Success: removed sampler", ResponseStatus.OK);
        }
    }
}
