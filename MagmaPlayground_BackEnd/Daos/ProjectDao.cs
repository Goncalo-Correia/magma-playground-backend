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
                return daoResponseFactory.BuildDaoResponse("Error: input parameter id is null", ResponseStatus.BADREQUEST);
            }

            daoResponse.project = magmaDbContext.Projects.Find(id);
            daoResponse.message = "Success: found project";
            daoResponse.responseStatus = ResponseStatus.OK;

            if (daoResponse.plugin == null)
            {
                return daoResponseFactory.BuildDaoResponse("Error: project not found", ResponseStatus.NOTFOUND);
            }

            return daoResponse;
        }

        public DaoResponse CreateProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (project.id != 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: project already exists, id must be null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Add<Project>(project);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return daoResponseFactory.BuildDaoResponse("Success: created project", ResponseStatus.OK);
        }

        public DaoResponse UpdateProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (project.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: project id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Update<Project>(project);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return daoResponseFactory.BuildDaoResponse("Success: updated project", ResponseStatus.OK);
        }

        public DaoResponse DeleteProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: input parameter is null", ResponseStatus.BADREQUEST);
                }

                if (project.id == 0)
                {
                    return daoResponseFactory.BuildDaoResponse("Error: project id is null", ResponseStatus.BADREQUEST);
                }

                magmaDbContext.Remove<Project>(project);
                magmaDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }
            catch (DbUpdateException ex)
            {
                return daoResponseFactory.BuildDaoResponse("Exception: " + ex.InnerException.Message, ResponseStatus.EXCEPTION);
            }

            return daoResponseFactory.BuildDaoResponse("Success: removed user", ResponseStatus.OK);
        }
    }
}