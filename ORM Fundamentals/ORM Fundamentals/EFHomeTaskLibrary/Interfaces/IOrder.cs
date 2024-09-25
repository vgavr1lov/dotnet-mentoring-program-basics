namespace EFHomeTaskLibrary
{
   public interface IOrder
   {
      int Id { get; set; }
      Status Status { get; set; }
      DateOnly CreateDate { get; set; }
      DateOnly UpdateDate { get; set; }
      int ProductId { get; set; }
   }
}