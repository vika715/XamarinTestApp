using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TestApp.JsonModels
{
    public class Paging
    {
        [JsonProperty("previous")]
        public string Previous { get; set; }
        [JsonProperty("next")]
        public string Next { get; set; }
    }
}
