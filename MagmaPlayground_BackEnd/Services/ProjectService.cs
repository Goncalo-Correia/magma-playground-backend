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
    public class ProjectService
    {
        private ProjectDao projectDao;
        private ResponseFactory responseFactory;
        private Response response;

        public ProjectService(MagmaDbContext magmaDbContext)
        {
            projectDao = new ProjectDao(magmaDbContext);
            responseFactory = new ResponseFactory();
        }

        public Response GetProjectById(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = projectDao.GetProjectById(id);

            if (response.project == null)
            {
                return responseFactory.CreateResponse("Error: project not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetProjectByUserId(int userId)
        {
            if (userId == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter userId is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = projectDao.GetProjectsByUserId(userId);

            if (response.projects == null)
            {
                return responseFactory.CreateResponse("Error: projects not found for this user", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response CreateProject(Project project)
        {
            if (project == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (project.id != 0)
            {
                return responseFactory.CreateResponse("Error: project already exists, id must be null", ResponseStatus.BADREQUEST);
            }

            response = new Response()

            response = projectDao.CreateProject(project);

            return response;
        }

        public Response UpdateProject(Project project)
        {
            if (project == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (project.id == 0)
            {
                return responseFactory.CreateResponse("Error: project id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = projectDao.UpdateProject(project);

            return response;
        }

        public Response DeleteProject(Project project)
        {
            if (project == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (project.id == 0)
            {
                return responseFactory.CreateResponse("Error: project id is null", ResponseStatus.BADREQUEST);
            }

            response = new Response();

            response = projectDao.DeleteProject(project);

            return response;
        }
    }
}
