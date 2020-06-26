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

namespace MagmaPlayground_BackEnd.Controllers
{
    [ApiController]
    [Route("magma_api/[controller]")]
    public class RackController : ControllerBase
    {
        private RackService rackService;
        private ControllerResponseFactory controllerResponseFactory;
        private Response response;


        public RackController(MagmaDbContext magmaDbContext)
        {
            rackService = new RackService(magmaDbContext);
            controllerResponseFactory = new ControllerResponseFactory();
        }
        
        [HttpGet("{id}")]
        public ActionResult<Response> GetRackById(int id)
        {
            response = new Response();
            response = rackService.GetRackById(id);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpGet("track/{id}")]
        public ActionResult<Response> GetRackByTrackId(int trackId)
        {
            response = new Response();
            response = rackService.GetRackByTrackId(trackId);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpPost]
        public ActionResult<Response> CreateRack(Rack rack)
        {
            response = new Response();
            response = rackService.CreateRack(rack);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpPost("update")]
        public ActionResult<Response> UpdateRack(Rack rack)
        {
            response = new Response();
            response = rackService.UpdateRack(rack);

            return controllerResponseFactory.BuildControllerResponse(response);
        }

        [HttpDelete]
        public ActionResult<Response> DeleteRack(Rack rack)
        {
            response = new Response();
            response = rackService.DeleteRack(rack);

            return controllerResponseFactory.BuildControllerResponse(response);
        }
    }
}