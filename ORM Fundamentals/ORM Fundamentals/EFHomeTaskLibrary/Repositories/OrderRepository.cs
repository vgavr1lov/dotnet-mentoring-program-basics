using Microsoft.EntityFrameworkCore;
using System.Data;
using Data;

namespace EFHomeTaskLibrary
{
   public class OrderRepository : GenericRepository<Order>, IOrderRepository
   {
      public OrderRepository(EFDbContext context) : base(context) { }

      public List<Order> ReadByCreationMonth(int month)
      {
         return DbContext.Order
                  .Where(o => o.CreateDate.Month == month)
                  .ToList();
      }

      public List<Order> ReadByCreationYear(int year)
      {
         return DbContext.Order
                  .Where(o => o.CreateDate.Year == year)
                  .ToList();
      }

      public List<Order> ReadByProductId(int productId)
      {
         return DbContext.Order
                  .Where(o => o.ProductId == productId)
                  .ToList();
      }
      public List<Order> ReadByStatus(Status status)
      {
         return DbContext.Order
                  .Where(o => o.Status == status)
                  .ToList();
      }

      public void DeleteByCreationMonth(int month)
      {
         var ordersToDelete = DbContext.Order
                                 .Where(o => o.CreateDate.Month == month)
                                 .ToList();

         DbContext.Order.RemoveRange(ordersToDelete);
      }

      public void DeleteByCreationYear(int year)
      {
         var ordersToDelete = DbContext.Order
                                 .Where(o => o.CreateDate.Year == year)
                                 .ToList();

         DbContext.Order.RemoveRange(ordersToDelete);
      }

      public void DeleteByProductId(int productId)
      {
         var ordersToDelete = DbContext.Order
                                 .Where(o => o.ProductId == productId)
                                 .ToList();

         DbContext.Order.RemoveRange(ordersToDelete);
      }
      public void DeleteByStatus(Status status)
      {
         var ordersToDelete = DbContext.Order
                                 .Where(o => o.Status == status)
                                 .ToList();

         DbContext.Order.RemoveRange(ordersToDelete);
      }
   }
}
