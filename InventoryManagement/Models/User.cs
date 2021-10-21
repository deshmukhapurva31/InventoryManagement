using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class User :Resource
    {
        public string FirstName { get; set; }
        public string  LastName { get; set; }

        public string Email { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
