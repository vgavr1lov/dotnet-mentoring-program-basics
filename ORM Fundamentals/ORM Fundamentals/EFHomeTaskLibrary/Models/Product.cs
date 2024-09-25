using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFHomeTaskLibrary
{
   public class Product : IProduct
   {
      public int Id { get; set; }
      [Required]
      [MaxLength(50)]
      public string Description { get; set; }
      [Required]
      [Column(TypeName = "numeric(18, 2)")]
      public decimal Weight { get; set; }
      [Required]
      [Column(TypeName = "numeric(18, 2)")]
      public decimal Height { get; set; }
      [Required]
      [Column(TypeName = "numeric(18, 2)")]
      public decimal Width { get; set; }
      [Required]
      [Column(TypeName = "numeric(18, 2)")]
      public decimal Length { get; set; }

   }
}
