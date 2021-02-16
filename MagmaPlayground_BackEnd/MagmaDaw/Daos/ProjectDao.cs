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
        private MagmaDawDbContext magmaDbContext;

        public ProjectDao(MagmaDawDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
        }

        public Project GetProjectById(int id)
        {
            return magmaDbContext.Projects.Find(id);
        }

        public Project CreateProject(Project project)
        {
            project.id = magmaDbContext.Add<Project>(project).Entity.id;

            magmaDbContext.SaveChanges();

            return project;
        }

        public Project UpdateProject(Project project)
        {
            project.id = magmaDbContext.Update<Project>(project).Entity.id;

            magmaDbContext.SaveChanges();

            return project;
        }

        public void DeleteProject(Project project)
        {
            magmaDbContext.Remove<Project>(project);

            magmaDbContext.SaveChanges();
        }
    }
}