using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.ResponseUtilities
{
    public class ResponseSerializer
    {
        private string json;

        public ResponseSerializer()
        {
        }

        public string SerializeResponse(Response response)
        {
            json = JsonConvert.SerializeObject(
                                    response, 
                                    Newtonsoft.Json.Formatting.Indented,
                                    new JsonSerializerSettings()
                                    {
                                        NullValueHandling = NullValueHandling.Ignore,
                                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                    }
                            );

            return json;
        }
    }
}
 