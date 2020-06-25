using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            response = new Response();

            if (id == 0)
            {
                return responseFactory.BuildResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
            }

            response = samplerDao.GetSamplerById(id);

            if (response.sampler == null)
            {
                return responseFactory.BuildResponse("Error: track not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetSamplerByPluginId(int pluginId)
        {
            response = new Response();
            try
            {
                if (pluginId == 0)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                response = samplerDao.GetSamplerByPluginId(pluginId);

                if (response.sampler == null)
                {
                    return responseFactory.BuildResponse("Error: sampler not found for this plugin", ResponseStatus.NOTFOUND);
                }
            }
            catch (ArgumentNullException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (InvalidOperationException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response CreateSampler(Sampler sampler)
        {
            response = new Response();
            try
            {
                if (sampler == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }
                if (sampler.id != 0)
                {
                    return responseFactory.BuildResponse("Error: sampler already exists, id must be null", ResponseStatus.BADREQUEST);
                }

                response = samplerDao.CreateSampler(sampler);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response UpdateSampler(Sampler sampler)
        {
            response = new Response();
            try
            {
                if (sampler == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }
                if (sampler.id == 0)
                {
                    return responseFactory.BuildResponse("Error: sampler id is null", ResponseStatus.BADREQUEST);
                }

                response = samplerDao.UpdateSampler(sampler);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response DeleteSampler(Sampler sampler)
        {
            response = new Response();
            try
            {
                if (sampler == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }
                if (sampler.id == 0)
                {
                    return responseFactory.BuildResponse("Error: sampler id is null", ResponseStatus.BADREQUEST);
                }

                response = samplerDao.DeleteSampler(sampler);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }
    }
}
