using MagmaPlayground_BackEnd.Controllers;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Factories
{
    public class TrackFactory
    {
        private ProjectController projectController;
        private TrackController trackController;
        private RackController rackController;

        private Track track;
        private List<Track> tracks;

        private Project project;

        private Rack rack;

        private int tracksCount;
        private int order;

        public TrackFactory (ProjectController projectController, TrackController trackController, RackController rackController)
        {
            this.projectController = projectController;
            this.trackController = trackController;
            this.rackController = rackController;
            this.tracks = new List<Track>();
        }

        public Track BuildTrackForProject (int projectId, TrackType trackType)
        {
            return BuildTrack(projectId, trackType);
        }

        public List<Track> BuildTracksForProject(int projectId, List<TrackType> trackTypes, int numberOfTracks)
        {
            for (int i = 0; i < numberOfTracks; i++)
            {
                tracks.Add(BuildTrack(projectId, trackTypes[i]));
            }

            return tracks;
        }

        private Track BuildTrack (int projectId, TrackType trackType)
        {
            project = projectController.GetProjectById(projectId).Value;

            tracksCount = trackController.GetTracksByProjectId(projectId).Value.ToList().Count;
            order = tracksCount + 1;

            track = new Track();
            track.name = trackType.ToString() + " " + order;
            track.order = order;
            track.pan = 0;
            track.volume = 0;
            track.trackType = trackType;

            track.Project = project;
            track.projectId = projectId;

            rack = new Rack();
            track.Rack = rack;
            track.rackId = rack.id;

            return track;
        }
    }
}
