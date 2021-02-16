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
        private MagmaDawDbContext magmaDbContext;

        public SynthesizerDao(MagmaDawDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        public Synthesizer GetSynthesizerById(int id)
        {
            return magmaDbContext.Find<Synthesizer>(id);
        }

        public Synthesizer GetSynthesizerByPluginId(int pluginId)
        {
            return magmaDbContext.Synthesizers.SingleOrDefault<Synthesizer>(prop => prop.pluginId == pluginId);
        }

        public Synthesizer CreateSynthesizer(Synthesizer synthesizer)
        {
            synthesizer.id = magmaDbContext.Add<Synthesizer>(synthesizer).Entity.id;

            magmaDbContext.SaveChanges();

            return synthesizer;
        }

        public Synthesizer UpdateSynthesizer(Synthesizer synthesizer)
        {
            synthesizer.id = magmaDbContext.Update<Synthesizer>(synthesizer).Entity.id;

            magmaDbContext.SaveChanges();

            return synthesizer;
        }

        public void DeleteSynthesizer(Synthesizer synthesizer)
        {
                magmaDbContext.Remove<Synthesizer>(synthesizer);

                magmaDbContext.SaveChanges();
        }
    }
}
