namespace Data
{
   public interface IUnitOfWork: IDisposable
   {
      IProductRepository ProductRepository { get; }
      IOrderRepository OrderRepository { get; }
      int Save();
   }
}
