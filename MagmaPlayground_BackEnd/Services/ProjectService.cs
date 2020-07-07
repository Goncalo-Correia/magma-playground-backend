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
            response = new Response();
            if (id == 0)
            {
                return responseFactory.BuildResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
            }

            response = projectDao.GetProjectById(id);

            if (response.project == null)
            {
                return responseFactory.BuildResponse("Error: project not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetProjectByUserId(int userId)
        {
            response = new Response();
            try
            {
                if (userId == 0)
                {
                    return responseFactory.BuildResponse("Error: input parameter userId is null", ResponseStatus.BADREQUEST);
                }

                response = projectDao.GetProjectsByUserId(userId);

                if (response.projects == null)
                {
                    return responseFactory.BuildResponse("Error: projects not found for this user", ResponseStatus.NOTFOUND);
                }
            }
            catch (ArgumentNullException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response CreateProject(Project project)
        {
            response = new Response();
            try
            {
                if (project == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (project.id != 0)
                {
                    return responseFactory.BuildResponse("Error: project already exists, id must be null", ResponseStatus.BADREQUEST);
                }

                response = projectDao.CreateProject(project);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response UpdateProject(Project project)
        {
            response = new Response();
            try
            {
                if (project == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (project.id == 0)
                {
                    return responseFactory.BuildResponse("Error: project id is null", ResponseStatus.BADREQUEST);
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response DeleteProject(Project project)
        {
            response = new Response();
            try
            {
                if (project == null)
                {
                    return responseFactory.BuildResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (project.id == 0)
                {
                    return responseFactory.BuildResponse("Error: project id is null", ResponseStatus.BADREQUEST);
                }

                response = projectDao.DeleteProject(project);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }
    }
}
