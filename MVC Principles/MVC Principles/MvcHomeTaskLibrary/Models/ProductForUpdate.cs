using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcHomeTaskLibrary.Models
{
    public class ProductForUpdate
    {
        public int ProductId { get; set; }

        [Display(Name = "Description")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(
            40,
            ErrorMessage = "Product Description cannot be more than 40 characters long!"
            )]
        public string ProductName { get; set; } = null!;
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }

        [Display(Name = "Quantity per Unit")]
        [DataType(DataType.Text)]
        [StringLength(
            20,
            ErrorMessage = "Quantity per Unit cannot be more than 20 characters long!"
            )]
        public string? QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        [Display(Name = "Units in Stock")]
        [Range(-32768, 32767, ErrorMessage = "Value should be between -32768 and 32767!")]
        public short? UnitsInStock { get; set; }

        [Display(Name = "Units on Order")]
        [Range(-32768, 32767, ErrorMessage = "Value should be between -32768 and 32767!")]
        public short? UnitsOnOrder { get; set; }

        [Display(Name = "Reorder Level")]
        [Range(-32768, 32767, ErrorMessage = "Value should be between -32768 and 32767!")]
        public short? ReorderLevel { get; set; }

        public string? Discontinued { get; set; }

        public List<Supplier> Suppliers;
        public List<Category> Categories;

    }
}
