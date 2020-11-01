using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
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
            response = new Response();
        }

        public Response GetProjectById(int id)
        {
            response = responseFactory.CreateProjectResponse();

            response.project = magmaDbContext.Projects.Find(id);

            return responseFactory.UpdateResponse(response, "Success: found project", ResponseStatus.OK);
        }

        public Response GetProjectsByUserId(int userId)
        {
            response = responseFactory.CreateProjectResponse();

            response.projects = magmaDbContext.Projects.Where<Project>(prop => prop.userId == userId).ToList<Project>();

            return responseFactory.UpdateResponse(response, "Success: projects found", ResponseStatus.OK);
        }

        public Response CreateProject(Project project)
        {
            response = responseFactory.CreateProjectResponse();

            response.project.id = magmaDbContext.Add<Project>(project).Entity.id;

            magmaDbContext.SaveChanges();

            return responseFactory.UpdateResponse(response, "Success: created project", ResponseStatus.OK);
        }

        public Response UpdateProject(Project project)
        {
            response = responseFactory.CreateProjectResponse();

            response.project.id = magmaDbContext.Update<Project>(project).Entity.id;

            magmaDbContext.SaveChanges();

            return responseFactory.UpdateResponse(response, "Success: updated project", ResponseStatus.OK);
        }

        public Response DeleteProject(Project project)
        {
            magmaDbContext.Remove<Project>(project);

            magmaDbContext.SaveChanges();

            return responseFactory.CreateResponse("Success: removed project", ResponseStatus.OK);
        }
    }
}