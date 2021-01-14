using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagmaPlayground_BackEnd.MagmaLive.Response
{
    public class LiveResponseSerializer
    {
        private string json;

        public LiveResponseSerializer()
        {
        }

        public string SerializeResponse(LiveResponse liveResponse)
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
