using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
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
            responseFactory = new ResponseFactory();
            response = new Response();
        }

        public Response GetSynthesizerById(int id)
        {
            response = responseFactory.CreateSynthesizerResponse();

            response.synthesizer = magmaDbContext.Find<Synthesizer>(id);

            return responseFactory.UpdateResponse(response, "Success: synthesizer found", ResponseStatus.OK);
        }

        public Response GetSynthesizerByPluginId(int pluginId)
        {
            response = responseFactory.CreateSynthesizerResponse();

            response.synthesizer = magmaDbContext.Synthesizers.SingleOrDefault<Synthesizer>(prop => prop.pluginId == pluginId);

            return responseFactory.UpdateResponse(response, "Success: synthesizer found", ResponseStatus.OK);
        }

        public Response CreateSynthesizer(Synthesizer synthesizer)
        {
            response = responseFactory.CreateSynthesizerResponse();

            response.synthesizer.id = magmaDbContext.Add<Synthesizer>(synthesizer).Entity.id;

            magmaDbContext.SaveChanges();

            return responseFactory.UpdateResponse(response, "Success: created synthesizer", ResponseStatus.OK);
        }

        public Response UpdateSynthesizer(Synthesizer synthesizer)
        {
            response = responseFactory.CreateSynthesizerResponse();

            response.synthesizer.id = magmaDbContext.Update<Synthesizer>(synthesizer).Entity.id;

            magmaDbContext.SaveChanges();

            return responseFactory.UpdateResponse(response, "Success: updated synthesizer", ResponseStatus.OK);
        }

        public Response DeleteSynthesizer(int id)
        {
                magmaDbContext.Remove<Synthesizer>(GetSynthesizerById(id).synthesizer);

                magmaDbContext.SaveChanges();

            return responseFactory.CreateResponse("Success: removed synthesizer", ResponseStatus.OK);
        }
    }
}
