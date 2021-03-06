﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using MagmaPlayground_BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private ProjectService projectService;
        private Response response;
        private ResponseFactory responseFactory;

        public ProjectController(MagmaDawDbContext magmaDbContext)
        {
            projectService = new ProjectService(magmaDbContext);
            responseFactory = new ResponseFactory();
        }

        [HttpGet("{id}")]
        public ActionResult<Response> GetProjectById(int id)
        {
            response = new Response();

            response = projectService.GetProjectById(id);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpGet("user/{userId}")]
        public ActionResult<Response> GetProjectsByUserId(int userId)
        {
            response = new Response();

            response = projectService.GetProjectByUserId(userId);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<Response> CreateProject(Project project)
        {
            response = new Response();

            response = projectService.CreateProject(project);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<Response> UpdateProject(Project project)
        {
            response = new Response();

            response = projectService.UpdateProject(project);

            return responseFactory.CreateControllerResponse(response);
        }

        [HttpDelete("{id}")]
        public ActionResult<Response> DeleteProject(int id)
        {
            response = new Response();

            response = projectService.DeleteProject(id);

            return responseFactory.CreateControllerResponse(response);
        }
    }
}
