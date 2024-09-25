namespace DBHandlerLibrary
{
   public class Order : IOrder
   {
      public int Id { get; set; }
      public Status Status { get; set; }
      public DateOnly CreateDate { get; set; }
      public DateOnly UpdateDate { get; set; }
      public int ProductId { get; set; }

   }
}
