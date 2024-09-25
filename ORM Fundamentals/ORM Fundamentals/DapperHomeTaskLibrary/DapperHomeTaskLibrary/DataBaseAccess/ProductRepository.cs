using Dapper;
using Data;
using System.Data;

namespace DapperHomeTaskLibrary;

public class ProductRepository : IProductRepository
{
   private readonly IDbConnectionFactory _connectionFactory;
   public ProductRepository(IDbConnectionFactory factory)
   {
      _connectionFactory = factory;
   }
   public void Create(Product product)
   {
      using var connection = _connectionFactory.Create();
      connection.QueryFirstOrDefault<int>("spProduct_Insert", product, commandType: CommandType.StoredProcedure);
   }

   public void Delete(int productId)
   {
      using var connection = _connectionFactory.Create();
      connection.Execute("spProduct_Delete", new { Id = productId }, commandType: CommandType.StoredProcedure);
   }

   public List<Product> Read()
   {
      using var connection = _connectionFactory.Create();
      return connection.Query<Product>("spProduct_GetAll", commandType: CommandType.StoredProcedure).ToList();
   }

   public Product? Read(int productId)
   {
      using var connection = _connectionFactory.Create();
      return connection.QueryFirstOrDefault<Product>("spProduct_Get", new { Id = productId }, commandType: CommandType.StoredProcedure);
   }

   public List<Product> Read(string productDescription)
   {
      using var connection = _connectionFactory.Create();
      return connection.Query<Product>("spProduct_GetUnderCondition", new { Description = productDescription }, commandType: CommandType.StoredProcedure).ToList();
   }

   public void Update(Product product)
   {
      using var connection = _connectionFactory.Create();
      connection.Execute("spProduct_Update", product, commandType: CommandType.StoredProcedure);
   }
}
