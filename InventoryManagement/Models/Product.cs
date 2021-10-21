using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Product :Resource
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public bool IsDeleted { get; set; }
    }
}
