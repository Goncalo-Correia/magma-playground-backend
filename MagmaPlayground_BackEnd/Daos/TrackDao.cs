using MagmaPlayground_BackEnd.Daos.Utilities;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
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
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter id is null", false);
                }

                daoResponse.track = magmaDbContext.Find<Track>(id);
                daoResponse.message = "Success: track found";
                daoResponse.isValid = true;

                if (daoResponse.track == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: track not found", false);
                }
            }
            catch (Npgsql.PostgresException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }

            return daoResponse;
        }

        public DaoResponse CreateTrack(Track track)
        {
            try
            {
                if (track == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }

                if (track.id != 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: track already exists, id must be null", false);
                }

                magmaDbContext.Add<Track>(track);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }

            return daoResponseFactory.BuildDaoResponse("Success: created track", true);
        }

        public DaoResponse UpdateTrack(Track track)
        {
            try
            {
                if (track == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }

                if (track.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: track id is null", false);
                }

                magmaDbContext.Update<Track>(track);
                magmaDbContext.SaveChanges();

            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }

            return daoResponseFactory.BuildDaoResponse("Success: updated track", true);
        }

        public DaoResponse DeleteTrack(Track track)
        {
            try
            {
                if (track == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }

                if (track.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: track id is null", false);
                }

                magmaDbContext.Remove<Track>(track);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }

            return daoResponseFactory.BuildDaoResponse("Success: removed track", true);
        }
    }
}