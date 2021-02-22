using MagmaPlayground_BackEnd.MagmaDaw.Models;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaDaw.Daos
{
    public class AudioEffectTypeDao
    {
        private MagmaDawDbContext magmaDawDbContext;

        public AudioEffectTypeDao(MagmaDawDbContext magmaDawDbContext)
        {
            this.magmaDawDbContext = magmaDawDbContext;
        }

        public AudioEffectType GetAudioEffectTypeById(int id)
        {
            return magmaDawDbContext.Find<AudioEffectType>(id);
        }

        public List<AudioEffectType> GetAudioEffectTypes()
        {
            return magmaDawDbContext.AudioEffectTypes.ToList<AudioEffectType>();
        }

        public AudioEffectType CreateAudioEffectType(AudioEffectType audioEffectType)
        {
            audioEffectType.id = magmaDawDbContext.Add<AudioEffectType>(audioEffectType).Entity.id;

            magmaDawDbContext.SaveChanges();

            return audioEffectType;
        }

        public AudioEffectType UpdateAudioEffectType(AudioEffectType audioEffectType)
        {
            audioEffectType.id = magmaDawDbContext.Update<AudioEffectType>(audioEffectType).Entity.id;

            magmaDawDbContext.SaveChanges();

            return audioEffectType;
        }

        public void DeleteAudioEffectType(AudioEffectType audioEffectType)
        {
            magmaDawDbContext.Remove<PluginType>(audioEffectType);

            magmaDawDbContext.SaveChanges();
        }
    }
}
