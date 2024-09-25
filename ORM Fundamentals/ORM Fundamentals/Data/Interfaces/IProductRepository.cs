namespace Data
{
   public interface IProductRepository: IRepository<Product>
   { 
      List<Product> Read(string productDescription);
   }
}