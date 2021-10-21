using InventoryManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly Inventory _inventory;

        public InfoController(IOptions<Inventory> inventoryInfoWrapper )
        {
            _inventory = inventoryInfoWrapper.Value;
        }

        [HttpGet(Name =nameof(GetInfo))]
        public ActionResult<Inventory> GetInfo()
        {
            _inventory.Href = Url.Link(nameof(GetInfo), null);
            return _inventory;
        }
    }
}
