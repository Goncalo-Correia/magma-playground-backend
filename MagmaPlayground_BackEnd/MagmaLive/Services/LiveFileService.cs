using MagmaPlayground_BackEnd.MagmaDB.MagmaLive.MagmaDbContext;
using MagmaPlayground_BackEnd.MagmaLive.Daos;
using MagmaPlayground_BackEnd.MagmaLive.Response;
using MagmaPlayground_BackEnd.Models.MagmaLive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaLive.Services
{
    public class LiveFileService
    {
        private LiveFileDao liveFileDao;
        private LiveResponseFactory liveResponseFactory;
        private LiveResponse liveResponse;

        public LiveFileService(MagmaLiveDbContext magmaLiveDbContext)
        {
            liveFileDao = new LiveFileDao(magmaLiveDbContext);
        }

        public LiveResponse GetLiveFileById(int id)
        {
            liveResponse = new LiveResponse();

            if (id == 0)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, "liveFile.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                liveResponse.liveFile = liveFileDao.GetLiveFileById(id);
            }
            catch (Exception ex)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return liveResponseFactory.CreateLiveResponse(liveResponse, "", HttpStatusCode.OK);
        }

        public LiveResponse CreateLiveFile(LiveFile liveFile)
        {
            liveResponse = new LiveResponse();

            if (liveFile.id != 0)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, "liveFile.id is not null", HttpStatusCode.BadRequest);
            }

            try
            {
                liveResponse.liveFile = liveFileDao.CreateLiveFile(liveFile);
            }
            catch (Exception ex)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return liveResponseFactory.CreateLiveResponse(liveResponse, "", HttpStatusCode.OK);
        }

        public LiveResponse UpdateLiveFile(LiveFile liveFile)
        {
            liveResponse = new LiveResponse();

            if (liveFile.id == 0)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, "liveFile.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                liveResponse.liveFile = liveFileDao.CreateLiveFile(liveFile);
            }
            catch (Exception ex)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return liveResponseFactory.CreateLiveResponse(liveResponse, "", HttpStatusCode.OK);
        }

        public LiveResponse DeleteLiveFile(LiveFile liveFile)
        {
            liveResponse = new LiveResponse();

            if (liveFile.id == 0)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, "liveFile.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                liveFileDao.DeleteLiveFile(liveFile);
            }
            catch (Exception ex)
            {
                return liveResponseFactory.CreateLiveResponse(liveResponse, ex.Message, HttpStatusCode.BadRequest);
            }

            return liveResponseFactory.CreateLiveResponse(liveResponse, "", HttpStatusCode.OK);
        }
    }
}
