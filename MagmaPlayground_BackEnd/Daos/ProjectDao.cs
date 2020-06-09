using MagmaPlayground_BackEnd.Daos.Utilities;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
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
        private DaoResponseFactory daoResponseFactory;
        private DaoResponse daoResponse;

        public ProjectDao(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            this.daoResponseFactory = new DaoResponseFactory();
        }

        public DaoResponse GetProject(int id)
        {
            daoResponse = new DaoResponse();
            if (id == 0)
            {
                return daoResponseFactory.BuildDaoResponse("Error: input parameter id is null", false);
            }

            daoResponse.project = magmaDbContext.Projects.Find(id);
            daoResponse.message = "Success: found project";
            daoResponse.isValid = true;

            if (daoResponse.plugin == null)
            {
                return daoResponseFactory.BuildDaoResponse("Error: project not found", false);
            }

            return daoResponse;
        }

        public DaoResponse CreateProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }

                if (project.id != 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: project already exists, id must be null", false);
                }

                magmaDbContext.Add<Project>(project);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }

            return daoResponseFactory.BuildDaoResponse("Success: created project", true);
        }

        public DaoResponse UpdateProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }

                if (project.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: project id is null", false);
                }

                magmaDbContext.Update<Project>(project);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }

            return daoResponseFactory.BuildDaoResponse("Success: updated project", true);
        }

        public DaoResponse DeleteProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", false);
                }

                if (project.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: project id is null", false);
                }

                magmaDbContext.Remove<Project>(project);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, false);
            }

            return daoResponseFactory.BuildDaoResponse("Success: removed user", true);
        }
    }
}