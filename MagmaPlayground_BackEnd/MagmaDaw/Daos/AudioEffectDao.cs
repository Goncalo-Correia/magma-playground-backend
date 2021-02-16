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
    public class AudioEffectDao
    {
        private MagmaDawDbContext magmaDbContext;

        public AudioEffectDao(MagmaDawDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        public AudioEffect GetAudioEffectById(int id)
        {
            return magmaDbContext.Find<AudioEffect>(id);
        }

        public AudioEffect GetAudioEffectByPluginId(int pluginId)
        {
            return magmaDbContext.AudioEffects.SingleOrDefault<AudioEffect>(prop => prop.pluginId == pluginId);
        }

        public AudioEffect CreateAudioEffect(AudioEffect audioEffect)
        {
            audioEffect.id = magmaDbContext.Add<AudioEffect>(audioEffect).Entity.id;

            magmaDbContext.SaveChanges();

            return audioEffect;
        }

        public AudioEffect UpdateAudioEffect(AudioEffect audioEffect)
        {
            audioEffect.id = magmaDbContext.Update<AudioEffect>(audioEffect).Entity.id;

            magmaDbContext.SaveChanges();

            return audioEffect;
        }

        public void DeleteAudioEffect(AudioEffect audioEffect)
        {
            magmaDbContext.Remove<AudioEffect>(audioEffect);

            magmaDbContext.SaveChanges();
        } 
    }
}
