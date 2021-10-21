using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class PostForm
    {
        [Required]
        [Display(Name="ProductName",Description =" Product Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "ProductCategory", Description = " Product Category")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "ProductColor", Description = " Product Color")]
        public string Color { get; set; }

        [Required]
        [Display(Name = "ProductUnitPrice", Description = " Product UnitPrice")]
        public decimal? UnitPrice { get; set; }

        [Required]
        [Display(Name = "ProductQuantity", Description = " Product Quantity")]
        public int? Quantity { get; set; }
    }

    public class AddForm 
    {
        [Required]
        [Display(Name = "ProductId", Description = " Product ID")]
        public Guid ProductId { get; set; }

        [Required]
        [Display(Name = "ProductQuantity", Description = " Product Quantity")]
        public int? Quantity { get; set; }


    }
}
