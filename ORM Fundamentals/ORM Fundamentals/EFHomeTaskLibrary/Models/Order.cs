using System.ComponentModel.DataAnnotations;

namespace EFHomeTaskLibrary
{
   public class Order : IOrder
   {
      public int Id { get; set; }
      [Required]
      [MaxLength(10)]
      public Status Status { get; set; }
      [Required]
      public DateOnly CreateDate { get; set; }
      [Required]
      public DateOnly UpdateDate { get; set; }
      public int ProductId { get; set; }
      public Product Product { get; set; }
   }
}
