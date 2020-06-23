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
        }

        public Response GetProjectById(int id)
        {
            response = new Response();

            response.project = magmaDbContext.Projects.Find(id);
            response.message = "Success: found project";
            response.responseStatus = ResponseStatus.OK;

            return response;
        }

        public Response GetProjectsByUserId(int userId)
        {
            response = new Response();

            response.projects = magmaDbContext.Projects.Where<Project>(prop => prop.userId == userId).ToList<Project>();
            response.message = "Success: projects found";
            response.responseStatus = ResponseStatus.OK;

            return response;
        }

        public Response CreateProject(Project project)
        {
            magmaDbContext.Add<Project>(project);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: created project", ResponseStatus.OK);
        }

        public Response UpdateProject(Project project)
        {
            magmaDbContext.Update<Project>(project);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: updated project", ResponseStatus.OK);
        }

        public Response DeleteProject(Project project)
        {
            magmaDbContext.Remove<Project>(project);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: removed user", ResponseStatus.OK);
        }
    }
}