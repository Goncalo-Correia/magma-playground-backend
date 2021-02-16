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
        private DawResponseFactory responseFactory;
        private DawResponse response;

        public PlaygroundService(MagmaDawDbContext magmaDbContext)
        {
            playgroundDao = new PlaygroundDao(magmaDbContext);
            responseFactory = new DawResponseFactory();
        }

        public DawResponse GetProjectById(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

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

        public DawResponse SaveNewProject(Project project)
        {
            if (project.id != 0)
            {
                return responseFactory.CreateResponse("Error: project id is not null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

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

        public DawResponse SaveProject(Project project)
        {
            if (project.id == 0)
            {
                return responseFactory.CreateResponse("Error: project id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

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