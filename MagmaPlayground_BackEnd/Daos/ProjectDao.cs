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
    public class ProjectDao
    {
        private MagmaDbContext magmaDbContext;
        private ResponseFactory responseFactory;
        private Response response;

        public ProjectDao(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            this.responseFactory = new ResponseFactory();
        }

        public Response GetProject(int id)
        {
            response = new Response();
            if (id == 0)
            {
                return responseFactory.BuildDaoResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
            }

            response.project = magmaDbContext.Projects.Find(id);
            response.message = "Success: found project";
            response.responseStatus = ResponseStatus.OK;

            if (response.plugin == null)
            {
                return responseFactory.BuildDaoResponse("Error: project not found", ResponseStatus.NOTFOUND);
            }

            return response;
        }

        public Response GetProjectsByUserId(int userId)
        {
            try
            {
                if (userId == 0)
                {
                    return responseFactory.BuildDaoResponse("Error: input parameter userId is null", ResponseStatus.BADREQUEST);
                }

                response.projects = magmaDbContext.Projects.Where<Project>(prop => prop.userId == userId).ToList<Project>();
                response.message = "Success: projects found";
                response.responseStatus = ResponseStatus.OK;

                if (response.projects == null)
                {
                    return responseFactory.BuildDaoResponse("Error: projects not found for this user", ResponseStatus.NOTFOUND);
                }
            }
            catch (ArgumentNullException ex)
            {
                return responseFactory.BuildDaoResponse("exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return response;
        }

        public Response CreateProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    return responseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (project.id != 0)
                {
                    return responseFactory.BuildDaoResponse("Error: project already exists, id must be null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Add<Project>(project);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return responseFactory.BuildDaoResponse("Success: created project", ResponseStatus.OK);
        }

        public Response UpdateProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    return responseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (project.id == 0)
                {
                    return responseFactory.BuildDaoResponse("Error: project id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Update<Project>(project);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return responseFactory.BuildDaoResponse("Success: updated project", ResponseStatus.OK);
        }

        public Response DeleteProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    return responseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (project.id == 0)
                {
                    return responseFactory.BuildDaoResponse("Error: project id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Remove<Project>(project);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return responseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return responseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return responseFactory.BuildDaoResponse("Success: removed user", ResponseStatus.OK);
        }
    }
}