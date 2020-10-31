using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;

namespace MagmaPlayground_BackEnd.Services
{
    public class SamplerService
    {
        private SamplerDao samplerDao;
        private ResponseFactory responseFactory;
        private Response response;

        public SamplerService(MagmaDbContext magmaDbContext)
        {
            samplerDao = new SamplerDao(magmaDbContext);
            responseFactory = new ResponseFactory();
        }

        public Response GetSamplerById(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();
            
            try
            {
                response = samplerDao.GetSamplerById(id);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            if (response.sampler == null)
            {
                return responseFactory.CreateResponse("Error: track not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetSamplerByPluginId(int pluginId)
        {
            if (pluginId == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            try
            {
                response = samplerDao.GetSamplerByPluginId(pluginId);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            if (response.sampler == null)
            {
                return responseFactory.CreateResponse("Error: sampler not found for this plugin", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response CreateSampler(Sampler sampler)
        {
            if (sampler == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (sampler.id != 0)
            {
                return responseFactory.CreateResponse("Error: sampler already exists, id must be null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            try
            {
                response = samplerDao.CreateSampler(sampler);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response UpdateSampler(Sampler sampler)
        {
            if (sampler == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (sampler.id == 0)
            {
                return responseFactory.CreateResponse("Error: sampler id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            try
            {
                response = samplerDao.UpdateSampler(sampler);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response DeleteSampler(Sampler sampler)
        {
            if (sampler == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (sampler.id == 0)
            {
                return responseFactory.CreateResponse("Error: sampler id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();
            
            try
            {
                response = samplerDao.DeleteSampler(sampler);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }
    }
}
