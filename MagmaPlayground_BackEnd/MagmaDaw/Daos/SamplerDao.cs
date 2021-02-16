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
    public class SamplerDao
    {
        private MagmaDawDbContext magmaDbContext;

        public SamplerDao(MagmaDawDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;;
        }

        public Sampler GetSamplerById(int id)
        {
            return magmaDbContext.Find<Sampler>(id);
        }

        public Sampler GetSamplerByPluginId(int pluginId)
        {
            return magmaDbContext.Samplers.SingleOrDefault<Sampler>(prop => prop.pluginId == pluginId);
        }

        public Sampler CreateSampler(Sampler sampler)
        {
            sampler.id = magmaDbContext.Add<Sampler>(sampler).Entity.id;

            magmaDbContext.SaveChanges();

            return sampler;
        }

        public Sampler UpdateSampler(Sampler sampler)
        {
            sampler.id = magmaDbContext.Update<Sampler>(sampler).Entity.id;

            magmaDbContext.SaveChanges();

            return sampler;
        }

        public void DeleteSampler(Sampler sampler)
        {
            magmaDbContext.Remove<Sampler>(sampler);

            magmaDbContext.SaveChanges();
        }
    }
}
