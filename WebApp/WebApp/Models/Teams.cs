using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Teams
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("full-name")]
        public string fullname { get; set; }
        [JsonProperty("short-name")]
        public string shortname { get; set; }
        public bool Edited { get; set; }
        public bool IsDeleted { get; set; }
    }

    
}
