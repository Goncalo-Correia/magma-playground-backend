using MagmaPlayground_BackEnd.Controllers;
using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using MagmaPlayground_BackEnd.ResponseUtilities;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Services
{
    public class PlaygroundService
    {
        private PlaygroundDao playgroundDao;
        private ResponseFactory responseFactory;
        private Response response;

        public PlaygroundService(MagmaDbContext magmaDbContext)
        {
            playgroundDao = new PlaygroundDao(magmaDbContext);
            responseFactory = new ResponseFactory();
        }

        public Response GetProjectById(int id)
        {
            response = new Response();
            response = playgroundDao.GetProjectById(id);

            return response;
        }
    }
}