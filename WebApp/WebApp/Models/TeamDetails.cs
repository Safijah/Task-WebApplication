using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class TeamDetails
    {
        [JsonProperty("twitter")]
        public string Twitter { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("postcode")]
        public string Postcode { get; set; }
        [JsonProperty("ground")]
        public string Ground { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("capacity")]
        public int Capacity { get; set; }



    }
}
