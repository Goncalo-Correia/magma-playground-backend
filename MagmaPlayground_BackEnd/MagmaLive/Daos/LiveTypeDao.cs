using MagmaPlayground_BackEnd.Models.MagmaLive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaLive.Daos
{
    public class LiveTypeDao
    {
        public LiveTypeDao()
        {

        }

        public int CreateLiveFileType(LiveType liveType)
        {
            return liveType.id;
        }

        public int UpdateLiveType(LiveType liveType)
        {
            return liveType.id;
        }

        public int CreateOrUpdateLiveype(LiveType liveType)
        {
            return liveType.id;
        }

        public void DeleteLiveType(LiveType liveFileType)
        {

        }
    }
}
