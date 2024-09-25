namespace DBHandlerLibrary
{
   public class ProductService
   {
      private IProductRepository Repository { get; set; }
      public ProductService(IProductRepository repository)
      {
         Repository = repository;
      }

      public int CreateProduct(IProduct product)
      {
         return Repository.Create(product);
      }

      public int DeleteProduct(int productId)
      {
         return Repository.Delete(productId);
      }

      public List<IProduct> ReadProduct()
      {
         return Repository.Read();
      }

      public IProduct ReadProduct(int productId)
      {
         return Repository.Read(productId);
      }

      public List<IProduct> ReadProduct(string productDescription)
      {
         return Repository.Read(productDescription);
      }

      public int UpdateProduct(IProduct product)
      {
         return Repository.Update(product);
      }

   }
}
