using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public interface IUserService
    {
        Task<Collection<User>> GetUsersAsync();

        Task <(bool success,string ErrorMessage)> CreateUserAsync(RegisterForm form);
    }
}
