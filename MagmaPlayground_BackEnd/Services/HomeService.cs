using MagmaPlayground_BackEnd.Daos;
using MagmaPlayground_BackEnd.Daos.Utilities;
using MagmaPlayground_BackEnd.Model;
using MagmaPlayground_BackEnd.Model.MagmaDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Services
{
    public class HomeService
    {
        private MagmaDbContext magmaDbContext;
        private DaoResponse daoResponse;
        private UserDao userDao;

        public HomeService(MagmaDbContext magmaDbContext)
        {
            this.magmaDbContext = magmaDbContext;
            this.daoResponse = new DaoResponse();
            this.userDao = new UserDao(magmaDbContext);
        }

        public void Login(string email, string password)
        {

        }

        public void Register(User user)
        {

        }
    }
}
