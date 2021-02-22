using MagmaPlayground_BackEnd.MagmaDaw.Models;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaDaw.Daos
{
    public class SynthesizerTypeDao
    {
        private MagmaDawDbContext magmaDawDbContext;

        public SynthesizerTypeDao(MagmaDawDbContext magmaDawDbContext)
        {
            this.magmaDawDbContext = magmaDawDbContext;
        }

        public SynthesizerType GetSynthesizerTypeById(int id)
        {
            return magmaDawDbContext.Find<SynthesizerType>(id);
        }

        public List<SynthesizerType> GetSynthesizerTypes()
        {
            return magmaDawDbContext.SynthesizerTypes.ToList<SynthesizerType>();
        }

        public SynthesizerType CreateSynthesizerType(SynthesizerType synthesizerType)
        {
            synthesizerType.id = magmaDawDbContext.Add<SynthesizerType>(synthesizerType).Entity.id;

            magmaDawDbContext.SaveChanges();

            return synthesizerType;
        }

        public SynthesizerType UpdateSynthesizerType(SynthesizerType synthesizerType)
        {
            synthesizerType.id = magmaDawDbContext.Update<SynthesizerType>(synthesizerType).Entity.id;

            magmaDawDbContext.SaveChanges();

            return synthesizerType;
        }

        public void DeleteSynthesizerType(SynthesizerType synthesizerType)
        {
            magmaDawDbContext.Remove<SynthesizerType>(synthesizerType);

            magmaDawDbContext.SaveChanges();
        }
    }
}
