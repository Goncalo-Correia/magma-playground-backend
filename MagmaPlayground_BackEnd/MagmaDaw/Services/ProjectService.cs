using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;

namespace MagmaPlayground_BackEnd.Services
{
    public class ProjectService
    {
        private ProjectDao projectDao;
        private DawResponseFactory responseFactory;
        private DawResponse response;

        public ProjectService(MagmaDawDbContext magmaDbContext)
        {
            projectDao = new ProjectDao(magmaDbContext);
            responseFactory = new DawResponseFactory();
        }

        public DawResponse GetProjectById(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = projectDao.GetProjectById(id);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            if (response.project == null)
            {
                return responseFactory.CreateResponse("Error: project not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public DawResponse GetProjectByUserId(int userId)
        {
            if (userId == 0)
            {
                return responseFactory.CreateResponse("Error: input parameter userId is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = projectDao.GetProjectsByUserId(userId);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            if (response.projects == null)
            {
                return responseFactory.CreateResponse("Error: projects not found for this user", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public DawResponse CreateProject(Project project)
        {
            if (project == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (project.id != 0)
            {
                return responseFactory.CreateResponse("Error: project already exists, id must be null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = projectDao.CreateProject(project);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public DawResponse UpdateProject(Project project)
        {
            if (project == null)
            {
                return responseFactory.CreateResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
            }

            if (project.id == 0)
            {
                return responseFactory.CreateResponse("Error: project id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = projectDao.UpdateProject(project);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public DawResponse DeleteProject(int id)
        {
            if (id == 0)
            {
                return responseFactory.CreateResponse("Error: project id is null", ResponseStatus.BADREQUEST);
            }

            response = new DawResponse();

            try
            {
                response = projectDao.DeleteProject(id);
            }
            catch (Exception exception)
            {
                return responseFactory.CreateResponse(exception.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }
    }
}
