using MagmaPlayground_BackEnd.Daos.Utilities;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.Utilities;
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

        public Response GetSampler(int id)
        {
            response = new Response();
            
            if (id == 0)
            {
                return responseFactory.BuildResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
            }

            response.sampler = magmaDbContext.Find<Sampler>(id);
            response.message = "Success: sampler found";
            response.responseStatus = ResponseStatus.OK;

            if (response.sampler == null)
            {
                return responseFactory.BuildResponse("Error: track not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetSamplerByPluginId(int pluginId)
        {
            try
            {
                if (pluginId == 0)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                response.sampler = magmaDbContext.Samplers.Single<Sampler>(prop => prop.plugin.id == pluginId);
                response.message = "Success: sampler found";
                response.responseStatus = ResponseStatus.OK;

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

                magmaDbContext.Add<Sampler>(sampler);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return responseFactory.BuildResponse("Success: created sampler", ResponseStatus.OK);
        }

        public Response UpdateSampler(Sampler sampler)
        {
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

                magmaDbContext.Update<Sampler>(sampler);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return responseFactory.BuildResponse("Success: updated sampler", ResponseStatus.OK);
        }

        public Response DeleteSampler(Sampler sampler)
        {
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

                magmaDbContext.Remove<Sampler>(sampler);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return responseFactory.BuildResponse("Success: removed sampler", ResponseStatus.OK);
        }
    }
}
