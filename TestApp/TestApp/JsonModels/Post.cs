using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TestApp.JsonModels
{
    public class Post
    {
        [JsonProperty("from")]
        public From From { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("full_picture")]
        public string FullPicture { get; set; }
        [JsonProperty("updated_time")]
        public string UpdateTime { get; set; }
        [JsonProperty("story")]
        public string Story { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
