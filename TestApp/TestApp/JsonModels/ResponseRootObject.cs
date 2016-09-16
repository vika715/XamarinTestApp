using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TestApp.JsonModels
{
    class ResponseRootObject
    {
        [JsonProperty("data")]
        public List<Post> Data { get; set; }
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
}
