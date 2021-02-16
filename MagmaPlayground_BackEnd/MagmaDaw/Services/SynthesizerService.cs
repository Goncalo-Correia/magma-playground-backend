using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;

namespace MagmaPlayground_BackEnd.Services
{
    public class SynthesizerService
    {
        private SynthesizerDao synthesizerDao;
        private DawResponseFactory responseFactory;
        private DawResponse response;

        public SynthesizerService(MagmaDawDbContext magmaDbContext)
        {
            synthesizerDao = new SynthesizerDao(magmaDbContext);
            responseFactory = new DawResponseFactory();
        }

        public DawResponse GetSynthesizerById(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = synthesizerDao.GetSynthesizerById(id);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            if (response.synthesizer == null)
            {
                return responseFactory.CreateResponse("Error: synthesizer not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public DawResponse GetSynthesizerByPluginId(int pluginId)
        {
            if (pluginId == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();
            
            try
            {
                response = synthesizerDao.GetSynthesizerByPluginId(pluginId);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            if (response.synthesizer == null)
            {
                return responseFactory.CreateResponse("Error: synthesizer not found for this plugin", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public DawResponse CreateSynthesizer(Synthesizer synthesizer)
        {
            if (synthesizer == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (synthesizer.id != 0)
            {
                return responseFactory.CreateResponse("Error: synthesizer already exists, id must be null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = synthesizerDao.CreateSynthesizer(synthesizer);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public DawResponse UpdateSynthesizer(Synthesizer synthesizer)
        {
            if (synthesizer == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (synthesizer.id == 0)
            {
                return responseFactory.CreateResponse("Error: synthesizer id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = synthesizerDao.UpdateSynthesizer(synthesizer);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public DawResponse DeleteSynthesizer(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: synthesizer id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = synthesizerDao.DeleteSynthesizer(id);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }
    }
}
