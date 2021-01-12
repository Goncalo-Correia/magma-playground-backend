using MagmaPlayground_BackEnd.Models.MagmaLive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaLive.Daos
{
    public class LiveFileTypeDao
    {
        public LiveFileTypeDao()
        {

        }

        public int CreateLiveFileType(LiveFileType liveFileType)
        {
            return liveFileType.id;
        }

        public int UpdateLiveType(LiveFileType liveFileType)
        {
            return liveFileType.id;
        }

        public int CreateOrUpdateLiveype(LiveFileType liveFileType)
        {
            return liveFileType.id;
        }

        public void DeleteLiveType(LiveFileType liveFileType)
        {

        }
    }
}
