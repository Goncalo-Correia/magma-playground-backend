using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.ResponseUtilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.ResponseUtilities
{
    public class ResponseFactory : ControllerBase
    {
        public Response response { get; set; }
        public ResponseSerializer responseSerializer;

        public ResponseFactory()
        {
            responseSerializer = new ResponseSerializer();
        }

        public Response CreateResponse(string message, ResponseStatus responseStatus)
        {
            response = new Response();
            response.message = message;
            response.responseStatus = responseStatus;

            return response;
        }

        public Response UpdateResponse(Response response, string message, ResponseStatus responseStatus)
        {
            response.message = message;
            response.responseStatus = responseStatus;

            return response;
        }

        public ActionResult<Response> CreateControllerResponse(Response response)
        {
            if (response.responseStatus == ResponseStatus.BADREQUEST)
            {
                return BadRequest(responseSerializer.SerializeResponse(response));
            }
            if (response.responseStatus == ResponseStatus.EXCEPTION)
            {
                return Conflict(responseSerializer.SerializeResponse(response));
            }
            if (response.responseStatus == ResponseStatus.NOTFOUND)
            {
                return NotFound(responseSerializer.SerializeResponse(response));
            }

            return Ok(responseSerializer.SerializeResponse(response));
        }

        public Response CreateUserResponse()
        {
            response = new Response();
            response.user = new User();

            return response;
        }

        public Response CreateProjectResponse()
        {
            response = new Response();
            response.project = new Project();

            return response;
        }

        public Response CreateTrackResponse()
        {
            response = new Response();
            response.track = new Track();

            return response;
        }

        public Response CreateRackResponse()
        {
            response = new Response();
            response.rack = new Rack();

            return response;
        }

        public Response CreatePluginResponse()
        {
            response = new Response();
            response.plugin = new Plugin();

            return response;
        }

        public Response CreateSamplerResponse()
        {
            response = new Response();
            response.sampler = new Sampler();

            return response;
        }

        public Response CreateSynthesizerResponse()
        {
            response = new Response();
            response.synthesizer = new Synthesizer();

            return response;
        }

        public Response CreateAudioEffectResponse()
        {
            response = new Response();
            response.audioEffect = new AudioEffect();

            return response;
        }

        public Response CreateUsersResponse()
        {
            response = new Response();
            response.users = new List<User>();

            return response;
        }

        public Response CreateProjectsResponse()
        {
            response = new Response();
            response.projects = new List<Project>();

            return response;
        }

        public Response CreateTracksResponse()
        {
            response = new Response();
            response.tracks = new List<Track>();

            return response;
        }

        public Response CreateRacskResponse()
        {
            response = new Response();
            response.racks = new List<Rack>();

            return response;
        }

        public Response CreatePluginsResponse()
        {
            response = new Response();
            response.plugins = new List<Plugin>();

            return response;
        }

        public Response CreateSamplersResponse()
        {
            response = new Response();
            response.samplers = new List<Sampler>();

            return response;
        }

        public Response CreateSynthesizersResponse()
        {
            response = new Response();
            response.synthesizers = new List<Synthesizer>();

            return response;
        }

        public Response CreateAudioEffectsResponse()
        {
            response = new Response();
            response.audioEffects = new List<AudioEffect>();

            return response;
        }
    }
}
