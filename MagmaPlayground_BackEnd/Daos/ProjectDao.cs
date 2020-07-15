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
            int id;

            id = magmaDbContext.Add<Project>(project).Entity.id;
            magmaDbContext.SaveChanges();

            return responseFactory.BuildIdResponse("Success: created project", ResponseStatus.OK, id);
        }

        public Response UpdateProject(Project project)
        {
            int id;

            id = magmaDbContext.Update<Project>(project).Entity.id;
            magmaDbContext.SaveChanges();

            return responseFactory.BuildIdResponse("Success: updated project", ResponseStatus.OK, id);
        }

        public Response DeleteProject(Project project)
        {
            magmaDbContext.Remove<Project>(project);
            magmaDbContext.SaveChanges();

            return responseFactory.BuildResponse("Success: removed user", ResponseStatus.OK);
        }
    }
}