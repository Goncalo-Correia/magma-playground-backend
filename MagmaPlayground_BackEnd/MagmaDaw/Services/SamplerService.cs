using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;
using System.Net;

namespace MagmaPlayground_BackEnd.Services
{
    public class SamplerService
    {
        private SamplerDao samplerDao;
        private DawResponseFactory dawResponseFactory;
        private DawResponse dawResponse;

        public SamplerService(MagmaDawDbContext magmaDbContext)
        {
            samplerDao = new SamplerDao(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }

        public DawResponse GetSamplerById(int id)
        {
            dawResponse = new DawResponse();

            if (id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: sampler.id is null", HttpStatusCode.BadRequest);
            }
            
            try
            {
                dawResponse.sampler = samplerDao.GetSamplerById(id);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.sampler == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: sampler not found", HttpStatusCode.NotFound);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse GetSamplerByPluginId(int pluginId)
        {
            dawResponse = new DawResponse();

            if (pluginId == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: pluginId is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.sampler = samplerDao.GetSamplerByPluginId(pluginId);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.sampler == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: sampler not found", HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse CreateSampler(Sampler sampler)
        {
            dawResponse = new DawResponse();

            if (sampler == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: sampler is null", HttpStatusCode.BadRequest);
            }

            if (sampler.id != 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: sampler.id must be null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.sampler = samplerDao.CreateSampler(sampler);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse UpdateSampler(Sampler sampler)
        {
            dawResponse = new DawResponse();

            if (sampler == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: sampler is null", HttpStatusCode.BadRequest);
            }

            if (sampler.id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: sampler.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.sampler = samplerDao.UpdateSampler(sampler);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse DeleteSampler(Sampler sampler)
        {
            dawResponse = new DawResponse();

            if (sampler.id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: sampler.id is null", HttpStatusCode.BadRequest);
            }
            
            try
            {
                samplerDao.DeleteSampler(sampler);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }
    }
}
