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
    public class PlaygroundDao
    {
        private MagmaDbContext magmaDbContext;
        private ResponseFactory responseFactory;
        private Response response;
        private ProjectDao projectDao;
        private TrackDao trackDao;
        private RackDao rackDao;
        private PluginDao pluginDao;
        private SamplerDao samplerDao;
        private SynthesizerDao synthesizerDao;
        private AudioEffectDao audioEffectDao;

        public PlaygroundDao(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            responseFactory = new ResponseFactory();
            projectDao = new ProjectDao(magmaDbContext);
            trackDao = new TrackDao(magmaDbContext);
            rackDao = new RackDao(magmaDbContext);
            pluginDao = new PluginDao(magmaDbContext);
            samplerDao = new SamplerDao(magmaDbContext);
            synthesizerDao = new SynthesizerDao(magmaDbContext);
            audioEffectDao = new AudioEffectDao(magmaDbContext);
        }

        public Response GetProjectById(int id)
        {
            response = new Response();

            response = projectDao.GetProjectById(id);

            if (response.project.id != 0)
            {
                response.project.tracks = trackDao.GetTracksByProjectId(id).tracks;

                foreach (Track track in response.project.tracks)
                {
                    if (track.id != 0)
                    {
                        track.rack = rackDao.GetRackByTrackId(track.id).rack;

                        if (track.rack.id != 0)
                        {
                            track.rack.plugins = pluginDao.GetPluginsByRackId(track.rack.id).plugins;

                            foreach (Plugin plugin in track.rack.plugins)
                            {
                                if (plugin.id != 0)
                                {
                                    switch (plugin.pluginType)
                                    {
                                        case PluginType.SAMPLER:
                                            plugin.sampler = samplerDao.GetSamplerByPluginId(plugin.id).sampler;
                                            break;
                                        case PluginType.SYNTHESIZER:
                                            plugin.synthesizer = synthesizerDao.GetSynthesizerByPluginId(plugin.id).synthesizer;
                                            break;
                                        case PluginType.AUDIOEFFECT:
                                            plugin.audioEffect = audioEffectDao.GetAudioEffectByPluginId(plugin.id).audioEffect;
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return responseFactory.UpdateResponse(response, "Success: found project", ResponseStatus.OK);
        }
        /*
        public Response GetProjectForDelete(int id)
        {
            response = new Response();

            response = projectDao.GetProjectById(id);

            return response;
        }
        */
        public Response SaveNewProject(Project project)
        {
            response = new Response();

            project.id = projectDao.CreateProject(project).project.id;

            foreach (Track track in project.tracks)
            {
                track.projectId = project.id;
                track.id = trackDao.CreateTrack(track).track.id;

                track.rack.trackId = track.id;
                track.rack.id = rackDao.CreateRack(track.rack).rack.id;

                foreach (Plugin plugin in track.rack.plugins)
                {
                    plugin.rackId = track.rack.id;
                    plugin.id = pluginDao.CreatePlugin(plugin).plugin.id;

                    switch (plugin.pluginType)
                    {
                        case PluginType.SAMPLER:
                            plugin.sampler.pluginId = plugin.id;
                            plugin.sampler.id = samplerDao.CreateSampler(plugin.sampler).sampler.id;
                            break;
                        case PluginType.SYNTHESIZER:
                            plugin.synthesizer.pluginId = plugin.id;
                            plugin.synthesizer.id = synthesizerDao.CreateSynthesizer(plugin.synthesizer).synthesizer.id;
                            break;
                        case PluginType.AUDIOEFFECT:
                            plugin.audioEffect.pluginId = plugin.id;
                            plugin.audioEffect.id = audioEffectDao.CreateAudioEffect(plugin.audioEffect).audioEffect.id;
                            break;
                    }
                }
            }
            response.project = project;

            return responseFactory.UpdateResponse(response, "Success: saved new project", ResponseStatus.OK);
        }

        public Response SaveProject(Project project)
        {
            response = new Response();

            project.id = projectDao.UpdateProject(project).project.id;

            foreach (Track track in project.tracks)
            {
                if (track.id == 0)
                {
                    track.projectId = project.id;
                    track.id = trackDao.CreateTrack(track).track.id;

                    track.rack.trackId = track.id;
                    track.rack.id = rackDao.CreateRack(track.rack).rack.id;
                } 
                else
                {
                    track.id = trackDao.UpdateTrack(track).track.id;
                    track.rack.id = rackDao.UpdateRack(track.rack).rack.id;
                }

                foreach (Plugin plugin in track.rack.plugins)
                {
                    if (plugin.id == 0)
                    {
                        plugin.rackId = track.rack.id;
                        plugin.id = pluginDao.CreatePlugin(plugin).plugin.id;
                    }
                    else
                    {
                        plugin.id = pluginDao.UpdatePlugin(plugin).plugin.id;
                    }

                    switch (plugin.pluginType)
                    {
                        case PluginType.SAMPLER:
                            if (plugin.sampler.id == 0)
                            {
                                plugin.sampler.pluginId = plugin.id;
                                samplerDao.CreateSampler(plugin.sampler);
                            }
                            else
                            {
                                samplerDao.UpdateSampler(plugin.sampler);
                            }
                            break;
                        case PluginType.SYNTHESIZER:
                            if (plugin.synthesizer.id == 0)
                            {
                                plugin.synthesizer.pluginId = plugin.id;
                                synthesizerDao.CreateSynthesizer(plugin.synthesizer);
                            }
                            else
                            {
                                synthesizerDao.UpdateSynthesizer(plugin.synthesizer);
                            }
                            break;
                        case PluginType.AUDIOEFFECT:
                            if (plugin.audioEffect.id == 0)
                            {
                                plugin.audioEffect.pluginId = plugin.id;
                                audioEffectDao.CreateAudioEffect(plugin.audioEffect);
                            }
                            else
                            {
                                audioEffectDao.UpdateAudioEffect(plugin.audioEffect);
                            }
                            break;
                    }
                }
            }
            response.project = project;

            return responseFactory.UpdateResponse(response, "Success: saved project", ResponseStatus.OK);
        }

        public Response DeleteProject(int id)
        {
            response = new Response();

            Response projectForDeleteResponse = projectDao.GetProjectById(id);

            response = projectDao.DeleteProject(projectForDeleteResponse.project);

            return response;
        }
    }
}
