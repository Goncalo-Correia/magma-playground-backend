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
        private int startingOrder;
        private int order;

        public TrackFactory (ProjectController projectController, TrackController trackController, RackController rackController)
        {
            this.projectController = projectController;
            this.trackController = trackController;
            this.rackController = rackController;
            this.tracks = new List<Track>();
        }

        public Track GetTrackForProject (int projectId, TrackType trackType)
        {
            project = projectController.GetProjectById(projectId).Value;

            tracksCount = trackController.GetTracksByProjectId(projectId).Value.ToList().Count;
            startingOrder = tracksCount + 1;
            order = startingOrder;

            return BuildTrack(projectId, trackType);
        }

        public List<Track> GetTracksForProject(int projectId, TrackType trackType, int numberOfTracks)
        {
            project = projectController.GetProjectById(projectId).Value;

            tracksCount = trackController.GetTracksByProjectId(projectId).Value.ToList().Count;
            startingOrder = tracksCount + 1;
            order = startingOrder;

            for (int i = 0; i < numberOfTracks; i++)
            {
                tracks.Add(BuildTrack(projectId, trackType));
            }

            return tracks;
        }

        private Track BuildTrack (int projectId, TrackType trackType)
        {
            track = new Track();
            track.name = trackType.ToString() + " " + order;
            track.order = order;
            track.pan = 0;
            track.volume = 0;

            track.Project = project;
            track.projectId = projectId;

            rack = new Rack();
            track.Rack = rack;
            track.rackId = rack.id;

            return track;
        }
    }
}
