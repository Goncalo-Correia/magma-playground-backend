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
            int projectId;
            int trackId;
            int rackId;
            int pluginId;

            projectId = projectDao.CreateProject(project).id;

            foreach (Track track in project.tracks)
            {
                track.projectId = projectId;
                trackId = trackDao.CreateTrack(track).id;

                track.rack.trackId = trackId;
                rackId = rackDao.CreateRack(track.rack).id;

                foreach (Plugin plugin in track.rack.plugins)
                {
                    plugin.rackId = rackId;
                    pluginId = pluginDao.CreatePlugin(plugin).id;

                    switch (plugin.pluginType)
                    {
                        case PluginType.SAMPLER:
                            samplerDao.CreateSampler(plugin.sampler);
                            break;
                        case PluginType.SYNTHESIZER:
                            synthesizerDao.CreateSynthesizer(plugin.synthesizer);
                            break;
                        case PluginType.AUDIOEFFECT:
                            audioEffectDao.CreateAudioEffect(plugin.audioEffect);
                            break;
                    }
                }
            }

            return responseFactory.BuildResponse("Success: created project", ResponseStatus.OK); ;
        }

        public Response SaveProject(Project project)
        {


            return responseFactory.BuildResponse("Success: saved project", ResponseStatus.OK);
        }

        public Response DeleteProject(Project project)
        {


            return responseFactory.BuildResponse("Success: deleted project", ResponseStatus.OK);
        }
    }
}
