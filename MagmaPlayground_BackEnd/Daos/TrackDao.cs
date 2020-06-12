using MagmaPlayground_BackEnd.Daos.Utilities;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Daos
{
    public class TrackDao
    {
        private MagmaDbContext magmaDbContext;
        private DaoResponseFactory daoResponseFactory;
        private DaoResponse daoResponse;

        public TrackDao(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            this.daoResponseFactory = new DaoResponseFactory();
        }

        public DaoResponse GetTrack(int id)
        {
            daoResponse = new DaoResponse();

            try
            {
                if (id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
                }

                daoResponse.track = magmaDbContext.Find<Track>(id);
                daoResponse.message = "Success: track found";
                daoResponse.responseStatus = ResponseStatus.OK;

                if (daoResponse.track == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: track not found", ResponseStatus.NOTFOUND);
                }
            }
            catch (Npgsql.PostgresException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return daoResponse;
        }

        public DaoResponse CreateTrack(Track track)
        {
            try
            {
                if (track == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (track.id != 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: track already exists, id must be null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Add<Track>(track);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return daoResponseFactory.BuildDaoResponse("Success: created track", ResponseStatus.OK);
        }

        public DaoResponse UpdateTrack(Track track)
        {
            try
            {
                if (track == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (track.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: track id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Update<Track>(track);
                magmaDbContext.SaveChanges();

            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return daoResponseFactory.BuildDaoResponse("Success: updated track", ResponseStatus.OK);
        }

        public DaoResponse DeleteTrack(Track track)
        {
            try
            {
                if (track == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (track.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: track id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Remove<Track>(track);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return daoResponseFactory.BuildDaoResponse("Success: removed track", ResponseStatus.OK);
        }
    }
}