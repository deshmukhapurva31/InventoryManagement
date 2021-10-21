using InventoryManagement.Models;
using LandonApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Controllers
{
    [Route("/")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RootController : ControllerBase
    {
        [HttpGet(Name =nameof(GetRoot))]
        public IActionResult GetRoot()
        {


            var response = new RootResponse
            {
                Href = Url.Link(nameof(GetRoot), null),
                Products = Url.Link(nameof(ProductController.GetAllProducts), null),
                Info = Url.Link(nameof(InfoController.GetInfo), null)
            };

            return Ok(response);
        }
    }
}
