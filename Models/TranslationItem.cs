using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TranslationApi.Models
{
    public class TranslationItem
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "key")]
        public string key { get; set; }
        [JsonProperty(PropertyName = "language")]
        public string language { get; set; }
    }

}
