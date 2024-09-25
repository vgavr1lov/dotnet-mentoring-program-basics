namespace DBHandlerLibrary
{
   public class Product : IProduct
   {
      public int Id { get; set; }
      public string Description { get; set; }
      public decimal Weight { get; set; }
      public decimal Height { get; set; }
      public decimal Width { get; set; }
      public decimal Length { get; set; }

   }
}
