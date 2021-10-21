using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class UserRoleEntity :IdentityRole<Guid>
    {
        public UserRoleEntity() : base(){

        }
        public override Guid Id { get => base.Id; set => base.Id = value; }
        public UserRoleEntity(string Name) : base(Name){

        }
    }
}
