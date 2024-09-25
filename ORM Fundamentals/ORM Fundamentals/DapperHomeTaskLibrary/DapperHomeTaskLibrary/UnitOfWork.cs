using Data;
using System.Data;
using System.Data.Common;
using System.Transactions;

namespace DapperHomeTaskLibrary;

public class UnitOfWork : IUnitOfWork
{
   public IProductRepository ProductRepository { get; }
   public IOrderRepository OrderRepository { get; }

   public UnitOfWork(IProductRepository productRepository, IOrderRepository orderRepository)
   {
      ProductRepository =  productRepository; 
      OrderRepository = orderRepository;
   }

   public void Dispose()
   {

   }

   public int Save()
   {
      return 0;
   }
}
