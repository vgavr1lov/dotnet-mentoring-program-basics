using Data;

namespace EFHomeTaskLibrary
{
   public class ProductRepository : GenericRepository<Product>, IProductRepository
   {
      public ProductRepository(EFDbContext context) : base(context) { }

      public List<Product> Read(string productDescription)
      {
         return DbContext.Product
                  .Where(p => p.Description == productDescription)
                  .ToList();
      }
   }
}