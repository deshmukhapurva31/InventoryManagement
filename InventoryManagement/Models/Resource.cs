using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public abstract class Resource
    {
        [JsonProperty]
        public string Href { get; set; }
    }
}
