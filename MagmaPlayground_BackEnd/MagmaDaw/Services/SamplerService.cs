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
        private DawResponseFactory responseFactory;
        private DawResponse response;

        public SamplerService(MagmaDawDbContext magmaDbContext)
        {
            samplerDao = new SamplerDao(magmaDbContext);
            responseFactory = new DawResponseFactory();
        }

        public DawResponse GetSamplerById(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();
            
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

        public DawResponse GetSamplerByPluginId(int pluginId)
        {
            if (pluginId == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

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

        public DawResponse CreateSampler(Sampler sampler)
        {
            if (sampler == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (sampler.id != 0)
            {
                return responseFactory.CreateResponse("Error: sampler already exists, id must be null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

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

        public DawResponse UpdateSampler(Sampler sampler)
        {
            if (sampler == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (sampler.id == 0)
            {
                return responseFactory.CreateResponse("Error: sampler id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

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

        public DawResponse DeleteSampler(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: sampler id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();
            
            try
            {
                response = samplerDao.DeleteSampler(id);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }
    }
}
