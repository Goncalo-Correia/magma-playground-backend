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
    public class SynthesizerDao
    {
        private MagmaDbContext magmaDbContext;
        private ResponseFactory responseFactory;
        private Response response;

        public SynthesizerDao(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            this.responseFactory = new ResponseFactory();
        }

        public Response GetSynthesizer(int id)
        {
            response = new Response();

            if (id == 0)
            {
                return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response.synthesizer = magmaDbContext.Find<Synthesizer>(id);
            response.message = "Success: synthesizer found";
            response.responseStatus = ResponseStatus.OK;

            if (response.synthesizer == null)
            {
                return responseFactory.BuildResponse("Error: synthesizer not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetSynthesizerByPluginId(int pluginId)
        {
            try
            {
                if (pluginId == 0)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                response.synthesizer = magmaDbContext.Synthesizers.Single<Synthesizer>(prop => prop.plugin.id == pluginId);
                response.message = "Success: synthesizer found";
                response.responseStatus = ResponseStatus.OK;

                if (response.synthesizer == null)
                {
                    return responseFactory.BuildResponse("Error: synthesizer not found for this plugin", ResponseStatus.NOTFOUND);
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

        public Response CreateSynthesizer(Synthesizer synthesizer)
        {
            try
            {
                if (synthesizer == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (synthesizer.id != 0)
                {
                    return responseFactory.BuildResponse("Error: synthesizer already exists, id must be null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Add<Synthesizer>(synthesizer);
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

            return responseFactory.BuildResponse("Success: created synthesizer", ResponseStatus.OK);
        }

        public Response UpdateSynthesizer(Synthesizer synthesizer)
        {
            try
            {
                if (synthesizer == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (synthesizer.id == 0)
                {
                    return responseFactory.BuildResponse("Error: synthesizer id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Update<Synthesizer>(synthesizer);
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

            return responseFactory.BuildResponse("Success: updated synthesizer", ResponseStatus.OK);
        }

        public Response DeleteSynthesizer(Synthesizer synthesizer)
        {
            try
            {
                if (synthesizer == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (synthesizer.id == 0)
                {
                    return responseFactory.BuildResponse("Error: synthesizer id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Remove<Synthesizer>(synthesizer);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return responseFactory.BuildResponse("Success: removed synthesizer", ResponseStatus.OK);
        }
    }
}
