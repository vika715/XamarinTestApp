using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TestApp.JsonModels
{
    public class From
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
