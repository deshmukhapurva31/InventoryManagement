using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LandonApi.Models
{
    public class RootResponse : Resource
    {
        public string Info { get; set; }

        public string Products { get; set; }
    }
}
