using Data;

namespace EFHomeTaskLibrary
{
   public class UnitOfWork : IUnitOfWork
   {
      private EFDbContext DbContext { get; }
      public IProductRepository ProductRepository { get; }
      public IOrderRepository OrderRepository { get; }

      public UnitOfWork(EFDbContext context, IProductRepository productRepository, IOrderRepository orderRepository)
      {
         DbContext = context;
         ProductRepository = productRepository;
         OrderRepository = orderRepository;
      }

      public void Dispose()
      {
         DbContext.Dispose();
      }

      public int Save()
      {
         return DbContext.SaveChanges();
      }
   }
}
