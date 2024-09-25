namespace DBHandlerLibrary
{
   public interface IProductRepository
   {
      int Create(IProduct product);
      int Delete(int productId);
      List<IProduct> Read();
      IProduct Read(int productId);
      List<IProduct> Read(string productDescription);
      int Update(IProduct product);
   }
}