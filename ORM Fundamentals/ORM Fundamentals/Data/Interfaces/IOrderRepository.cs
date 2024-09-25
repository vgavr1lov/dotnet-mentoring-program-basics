namespace Data
{
   public interface IOrderRepository: IRepository<Order>
   {
      List<Order> ReadByCreationMonth(int month);
      List<Order> ReadByCreationYear(int year);
      List<Order> ReadByProductId(int productId);
      List<Order> ReadByStatus(Status status);
      void DeleteByCreationMonth(int month);
      void DeleteByCreationYear(int year);
      void DeleteByProductId(int productId);
      void DeleteByStatus(Status status);
   }
}