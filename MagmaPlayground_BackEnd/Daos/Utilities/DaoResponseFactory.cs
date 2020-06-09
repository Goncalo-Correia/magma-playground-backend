using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.Daos.Utilities
{
    public class DaoResponseFactory
    {
        public DaoResponse daoResponse { get; set; }

        public DaoResponseFactory()
        {
        }

        public DaoResponse BuildDaoResponse(string message, bool isValid)
        {
            daoResponse = new DaoResponse();
            daoResponse.message = message;
            daoResponse.isValid = isValid;

            return daoResponse;
        }
    }
}
