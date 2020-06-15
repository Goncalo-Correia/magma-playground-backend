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
        private ResponseFactory responseFactory;
        private Response response;

        public TrackDao(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            this.responseFactory = new ResponseFactory();
        }

        public Response GetTrack(int id)
        {
            response = new Response();

            try
            {
                if (id == 0)
                {
                    return responseFactory.BuildResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
                }

                response.track = magmaDbContext.Find<Track>(id);
                response.message = "Success: track found";
                response.responseStatus = ResponseStatus.OK;

                if (response.track == null)
                {
                    return responseFactory.BuildResponse("Error: track not found", ResponseStatus.NOTFOUND);
                }
            }
            catch (Npgsql.PostgresException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response GetTracksByProjectId(int projectId)
        {
            try
            {
                if (projectId == 0)
                {
                    return responseFactory.BuildResponse("Error: input paramenter projectId is null", ResponseStatus.BADREQUEST);
                }

                response.tracks = magmaDbContext.Tracks.Where<Track>(prop => prop.projectId == projectId).ToList();
                response.message = "Success: tracks found";
                response.responseStatus = ResponseStatus.OK;

                if (response.tracks == null)
                {
                    return responseFactory.BuildResponse("Error: tracks not found for this project", ResponseStatus.NOTFOUND);
                }
            }
            catch (ArgumentNullException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response CreateTrack(Track track)
        {
            try
            {
                if (track == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (track.id != 0)
                {
                    return responseFactory.BuildResponse("Error: track already exists, id must be null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Add<Track>(track);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return responseFactory.BuildResponse("Success: created track", ResponseStatus.OK);
        }

        public Response UpdateTrack(Track track)
        {
            try
            {
                if (track == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (track.id == 0)
                {
                    return responseFactory.BuildResponse("Error: track id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Update<Track>(track);
                magmaDbContext.SaveChanges();

            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return responseFactory.BuildResponse("Success: updated track", ResponseStatus.OK);
        }

        public Response DeleteTrack(Track track)
        {
            try
            {
                if (track == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (track.id == 0)
                {
                    return responseFactory.BuildResponse("Error: track id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Remove<Track>(track);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return responseFactory.BuildResponse("Success: removed track", ResponseStatus.OK);
        }
    }
}