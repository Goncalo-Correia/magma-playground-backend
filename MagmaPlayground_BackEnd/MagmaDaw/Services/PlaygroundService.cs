using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;

namespace MagmaPlayground_BackEnd.Services
{
    public class PlaygroundService
    {
        private PlaygroundDao playgroundDao;
        private ResponseFactory responseFactory;
        private Response response;

        public PlaygroundService(MagmaDbContext magmaDbContext)
        {
            playgroundDao = new PlaygroundDao(magmaDbContext);
            responseFactory = new ResponseFactory();
        }

        public Response GetProjectById(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            try
            {
                response = playgroundDao.GetProjectById(id);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            if (response.project.id == 0)
            {
                return responseFactory.CreateResponse("Error: project not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response SaveNewProject(Project project)
        {
            if (project.id != 0)
            {
                return responseFactory.CreateResponse("Error: project id is not null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            try
            {
                response = playgroundDao.SaveNewProject(project);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response SaveProject(Project project)
        {
            if (project.id == 0)
            {
                return responseFactory.CreateResponse("Error: project id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            try
            {
                response = playgroundDao.SaveProject(project);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }
    }
}