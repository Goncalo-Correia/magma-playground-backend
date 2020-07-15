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

            response.project.tracks = trackDao.GetTracksByProjectId(id).tracks;

            foreach (Track track in response.project.tracks)
            {
                track.rack = rackDao.GetRackByTrackId(track.id).rack;

                track.rack.plugins = pluginDao.GetPluginsByRackId(track.rack.id).plugins;

                foreach (Plugin plugin in track.rack.plugins)
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

            return response;
        }

        public Response SaveNewProject(Project project)
        {
            response = new Response();

            project.id = projectDao.CreateProject(project).id;

            foreach (Track track in project.tracks)
            {
                track.projectId = project.id;
                track.id = trackDao.CreateTrack(track).id;

                track.rack.trackId = track.id;
                track.rack.id = rackDao.CreateRack(track.rack).id;

                foreach (Plugin plugin in track.rack.plugins)
                {
                    plugin.rackId = track.rack.id;
                    plugin.id = pluginDao.CreatePlugin(plugin).id;

                    switch (plugin.pluginType)
                    {
                        case PluginType.SAMPLER:
                            plugin.sampler.pluginId = plugin.id;
                            plugin.sampler.id = samplerDao.CreateSampler(plugin.sampler).id;
                            break;
                        case PluginType.SYNTHESIZER:
                            plugin.synthesizer.pluginId = plugin.id;
                            plugin.synthesizer.id = synthesizerDao.CreateSynthesizer(plugin.synthesizer).id;
                            break;
                        case PluginType.AUDIOEFFECT:
                            plugin.audioEffect.pluginId = plugin.id;
                            plugin.audioEffect.id = audioEffectDao.CreateAudioEffect(plugin.audioEffect).id;
                            break;
                    }
                }
            }
            response.message = "Success: created project";
            response.responseStatus = ResponseStatus.OK;
            response.project = project;

            return response;
        }

        public Response SaveProject(Project project)
        {
            response = new Response();

            project.id = projectDao.UpdateProject(project).id;

            foreach (Track track in project.tracks)
            {
                if (track.id == 0)
                {
                    track.projectId = project.id;
                    track.id = trackDao.CreateTrack(track).id;

                    track.rack.trackId = track.id;
                    track.rack.id = rackDao.CreateRack(track.rack).id;
                } 
                else
                {
                    track.id = trackDao.UpdateTrack(track).id;
                    track.rack.id = rackDao.UpdateRack(track.rack).id;
                }

                foreach (Plugin plugin in track.rack.plugins)
                {
                    if (plugin.id == 0)
                    {
                        plugin.rackId = track.rack.id;
                        plugin.id = pluginDao.CreatePlugin(plugin).id;
                    }
                    else
                    {
                        plugin.id = pluginDao.UpdatePlugin(plugin).id;
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

            response.message = "Success: saved project";
            response.responseStatus = ResponseStatus.OK;
            response.project = project;

            return response;
        }

        public Response DeleteProject(Project project)
        {


            return responseFactory.BuildResponse("Success: deleted project", ResponseStatus.OK);
        }
    }
}
