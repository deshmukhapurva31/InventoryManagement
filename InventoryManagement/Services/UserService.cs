using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryManagement.Models;
using InventoryManagement.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IConfigurationProvider _mappingConfiguration;

        public UserService(
            UserManager<UserEntity> userManager,
            IConfigurationProvider mappingConfiguration)
        {
            _userManager = userManager;
            _mappingConfiguration = mappingConfiguration;
        }

        public async Task <Collection<User>> GetUsersAsync()
        {
            IQueryable<UserEntity> query = _userManager.Users;
            

            var size = await query.CountAsync();

            var items = await query
                .ProjectTo<User>(_mappingConfiguration).ToArrayAsync();

            var collection = new Collection<User>
            {
                Href = null,
                Value = items
            };

            return collection;
        }
    }
}
