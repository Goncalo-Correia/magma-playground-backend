using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using System;
using System.Net;

namespace MagmaPlayground_BackEnd.Services
{
    public class ProjectService
    {
        private ProjectDao projectDao;
        private DawResponseFactory dawResponseFactory;
        private DawResponse dawResponse;

        public ProjectService(MagmaDawDbContext magmaDbContext)
        {
            projectDao = new ProjectDao(magmaDbContext);
            dawResponseFactory = new DawResponseFactory();
        }

        public DawResponse GetProjectById(int id)
        {
            dawResponse = new DawResponse();

            if (id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: project.id id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.project = projectDao.GetProjectById(id);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            if (dawResponse.project == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: project not found", HttpStatusCode.NotFound);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse CreateProject(Project project)
        {
            dawResponse = new DawResponse();

            if (project == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: project.id is null", HttpStatusCode.BadRequest);
            }

            if (project.id != 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: project.id is not null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.project = projectDao.CreateProject(project);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse UpdateProject(Project project)
        {
            dawResponse = new DawResponse();

            if (project == null)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: project.id is null", HttpStatusCode.BadRequest);
            }

            if (project.id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: project.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                dawResponse.project = projectDao.UpdateProject(project);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }

        public DawResponse DeleteProject(int id)
        {
            dawResponse = new DawResponse();

            if (id == 0)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, "Error: project.id is null", HttpStatusCode.BadRequest);
            }

            try
            {
                projectDao.DeleteProject(GetProjectById(id).project);
            }
            catch (Exception exception)
            {
                return dawResponseFactory.CreateDawResponse(dawResponse, exception.Message, HttpStatusCode.BadRequest);
            }

            return dawResponseFactory.CreateDawResponse(dawResponse, "", HttpStatusCode.OK);
        }
    }
}
