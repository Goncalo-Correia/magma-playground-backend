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
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = synthesizerDao.GetSynthesizerById(id);

            if (response.synthesizer == null)
            {
                return responseFactory.CreateResponse("Error: synthesizer not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetSynthesizerByPluginId(int pluginId)
        {
            if (pluginId == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();
            
            response = synthesizerDao.GetSynthesizerByPluginId(pluginId);

            if (response.synthesizer == null)
            {
                return responseFactory.CreateResponse("Error: synthesizer not found for this plugin", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response CreateSynthesizer(Synthesizer synthesizer)
        {
            if (synthesizer == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (synthesizer.id != 0)
            {
                return responseFactory.CreateResponse("Error: synthesizer already exists, id must be null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = synthesizerDao.CreateSynthesizer(synthesizer);

            return response;
        }

        public Response UpdateSynthesizer(Synthesizer synthesizer)
        {
            if (synthesizer == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (synthesizer.id == 0)
            {
                return responseFactory.CreateResponse("Error: synthesizer id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = synthesizerDao.UpdateSynthesizer(synthesizer);

            return response;
        }

        public Response DeleteSynthesizer(Synthesizer synthesizer)
        {
            if (synthesizer == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (synthesizer.id == 0)
            {
                return responseFactory.CreateResponse("Error: synthesizer id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = synthesizerDao.DeleteSynthesizer(synthesizer);

            return response;
        }
    }
}
