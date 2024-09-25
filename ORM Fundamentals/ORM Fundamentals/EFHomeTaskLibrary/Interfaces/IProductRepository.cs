namespace EFHomeTaskLibrary
{
   public interface IProductRepository: IRepository<Product>
   { 
      List<Product> Read(string productDescription);
   }
}