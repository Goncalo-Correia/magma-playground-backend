using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();
            response = playgroundDao.GetProjectById(id);

            if (response.project.id == 0)
            {
                return responseFactory.BuildResponse("Error: project not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response SaveNewProject(Project project)
        {
            if (project.id != 0)
            {
                return responseFactory.BuildResponse("Error: project id is not null", ResponseStatus.BADREQUEST);
            }

            response = new Response();
            response = playgroundDao.SaveNewProject(project);

            return response;
        }

        public Response SaveProject(Project project)
        {
            if (project.id == 0)
            {
                return responseFactory.BuildResponse("Error: project id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();
            response = playgroundDao.SaveProject(project);

            return response;
        }

        public Response DeleteProject(int id)
        {
            if (id == 0)
            {
                return responseFactory.BuildResponse("Error: project id is null", ResponseStatus.BADREQUEST);
            }
            response = new Response();
            response = playgroundDao.DeleteProject(id);

            return response;
        }
    }
}