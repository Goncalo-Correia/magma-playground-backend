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
            this.responseFactory = new ResponseFactory();
        }

        public Response GetSynthesizerById(int id)
        {
            response = new Response();

            response.synthesizer = magmaDbContext.Find<Synthesizer>(id);
            response.message = "Success: synthesizer found";
            response.responseStatus = ResponseStatus.OK;

            return response;
        }

        public Response GetSynthesizerByPluginId(int pluginId)
        {
            response = new Response();

            response.synthesizer = magmaDbContext.Synthesizers.SingleOrDefault<Synthesizer>(prop => prop.pluginId == pluginId);
            response.message = "Success: synthesizer found";
            response.responseStatus = ResponseStatus.OK;

            return response;
        }

        public Response CreateSynthesizer(Synthesizer synthesizer)
        {
            int id;

            id = magmaDbContext.Add<Synthesizer>(synthesizer).Entity.id;
            magmaDbContext.SaveChanges();

            return responseFactory.BuildIdResponse("Success: created synthesizer", ResponseStatus.OK, id);
        }

        public Response UpdateSynthesizer(Synthesizer synthesizer)
        {
            int id;

            id = magmaDbContext.Update<Synthesizer>(synthesizer).Entity.id;
            magmaDbContext.SaveChanges();

            return responseFactory.BuildIdResponse("Success: updated synthesizer", ResponseStatus.OK, id);
        }

        public Response DeleteSynthesizer(Synthesizer synthesizer)
        {
                magmaDbContext.Remove<Synthesizer>(synthesizer);
                magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: removed synthesizer", ResponseStatus.OK);
        }
    }
}
