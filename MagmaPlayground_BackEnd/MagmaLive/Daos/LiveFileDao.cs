using MagmaPlayground_BackEnd.Models.MagmaLive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaLive.Daos
{
    public class LiveFileDao
    {
        public LiveFileDao()
        {

        }

        public int CreateLiveFile(LiveFile liveFile)
        {
            return liveFile.id;
        }

        public int UpdateLive(LiveFile liveFile)
        {
            return liveFile.id;
        }

        public int CreateOrUpdateLive(LiveFile liveFile)
        {
            return liveFile.id;
        }

        public void DeleteLive(LiveFile liveFile)
        {

        }
    }
}
