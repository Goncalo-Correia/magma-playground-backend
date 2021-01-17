using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaGeneric.Response
{
    public class GenericResponseSerializer
    {
        private string json;

        public GenericResponseSerializer()
        {
        }

        public string SerializeResponse(GenericResponse liveResponse)
        {
            json = JsonConvert.SerializeObject(
                                    liveResponse,
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
