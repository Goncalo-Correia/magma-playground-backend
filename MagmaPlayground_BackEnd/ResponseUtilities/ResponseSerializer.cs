using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.ResponseUtilities
{
    public class ResponseSerializer
    {
        private Response response;
        private string json;

        public ResponseSerializer()
        {
        }

        public string SerializeResponse(Response response)
        {
            json = JsonConvert.SerializeObject(
                            response, 
                            Newtonsoft.Json.Formatting.None,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });

            return json;
        }
    }
}
