using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;
using System.Net;

namespace MagmaPlayground_BackEnd.Services
{
    public class SynthesizerService
    {
        private SynthesizerDao synthesizerDao;
        private DawResponseFactory dawResponseFactory;
        private DawResponse dawResponse;

        public SynthesizerService(MagmaDawDbContext magmaDbContext)
        {
            synthesizerDao = new SynthesizerDao(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }

        public DawResponse GetSynthesizerById(int id)
        {
            dawResponse = new DawResponse();

            if (id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: synthesizer.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.synthesizer = synthesizerDao.GetSynthesizerById(id);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.synthesizer == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: synthesizer not found", HttpStatusCode.NotFound);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse GetSynthesizerByPluginId(int pluginId)
        {
            dawResponse = new DawResponse();

            if (pluginId == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: pluginId is null", HttpStatusCode.BadRequest);
            }
            
            try
            {
                dawResponse.synthesizer = synthesizerDao.GetSynthesizerByPluginId(pluginId);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.synthesizer == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: synthesizer not found", HttpStatusCode.NotFound);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse CreateSynthesizer(Synthesizer synthesizer)
        {
            dawResponse = new DawResponse();

            if (synthesizer == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: synthesizer is null", HttpStatusCode.BadRequest);
            }

            if (synthesizer.id != 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: synthesizer.id must be null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.synthesizer = synthesizerDao.CreateSynthesizer(synthesizer);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse UpdateSynthesizer(Synthesizer synthesizer)
        {
            dawResponse = new DawResponse();

            if (synthesizer == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: synthesizer is null", HttpStatusCode.BadRequest);
            }

            if (synthesizer.id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: synthesizer.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.synthesizer = synthesizerDao.UpdateSynthesizer(synthesizer);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse DeleteSynthesizer(Synthesizer synthesizer)
        {
            dawResponse = new DawResponse();

            if (synthesizer.id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: synthesizer.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                synthesizerDao.DeleteSynthesizer(synthesizer);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }
    }
}
