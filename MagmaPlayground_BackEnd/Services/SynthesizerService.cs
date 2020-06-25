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
    public class SynthesizerService
    {
        private SynthesizerDao synthesizerDao;
        private ResponseFactory responseFactory;
        private Response response;

        public SynthesizerService(MagmaDbContext magmaDbContext)
        {
            synthesizerDao = new SynthesizerDao(magmaDbContext);
            responseFactory = new ResponseFactory();
        }

        public Response GetSynthesizerById(int id)
        {
            response = new Response();

            if (id == 0)
            {
                return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = synthesizerDao.GetSynthesizerById(id);

            if (response.synthesizer == null)
            {
                return responseFactory.BuildResponse("Error: synthesizer not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetSynthesizerByPluginId(int pluginId)
        {
            response = new Response();
            try
            {
                if (pluginId == 0)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                response = synthesizerDao.GetSynthesizerByPluginId(pluginId);

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
            response = new Response();
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

                response = synthesizerDao.CreateSynthesizer(synthesizer);
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

        public Response UpdateSynthesizer(Synthesizer synthesizer)
        {
            response = new Response();
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

                response = synthesizerDao.UpdateSynthesizer(synthesizer);
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

        public Response DeleteSynthesizer(Synthesizer synthesizer)
        {
            response = new Response();
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

                response = synthesizerDao.DeleteSynthesizer(synthesizer);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }
    }
}
