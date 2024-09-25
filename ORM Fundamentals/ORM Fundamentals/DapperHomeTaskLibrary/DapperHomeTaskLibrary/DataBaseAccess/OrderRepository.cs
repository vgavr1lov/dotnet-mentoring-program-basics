using Dapper;
using Data;
using System.Data;

namespace DapperHomeTaskLibrary;

public class OrderRepository : IOrderRepository
{
   private readonly IDbConnectionFactory _connectionFactory;
   public OrderRepository(IDbConnectionFactory factory)
   {
      _connectionFactory = factory;
   }
   public void Create(Order order)
   {
      SqlMapper.AddTypeHandler(new StatusTypeHandler());
      using var connection = _connectionFactory.Create();
      connection.QueryFirstOrDefault<int>("spOrder_Insert", FillParameters(order), commandType: CommandType.StoredProcedure);

   }

   public void Delete(int id)
   {
      using var connection = _connectionFactory.Create();
      connection.Execute("spOrder_Delete", new { Id = id }, commandType: CommandType.StoredProcedure);
   }

   public void Update(Order order)
   {
      using var connection = _connectionFactory.Create();
      connection.Execute("spOrder_Update", FillParameters(order), commandType: CommandType.StoredProcedure);
   }
   public Order? Read(int orderId)
   {
      using var connection = _connectionFactory.Create();
      return connection.QueryFirstOrDefault<Order>("spOrder_Get", new { Id = orderId }, commandType: CommandType.StoredProcedure);
   }

   public List<Order> Read()
   {
      using var connection = _connectionFactory.Create();
      return connection.Query<Order>("spOrder_GetUnderCondition", commandType: CommandType.StoredProcedure).ToList();
   }

   public List<Order> ReadByCreationMonth(int month)
   {
      using var connection = _connectionFactory.Create();
      return connection.Query<Order>("spOrder_GetUnderCondition", new { CreateDateMonth = month }, commandType: CommandType.StoredProcedure).ToList();
   }

   public List<Order> ReadByCreationYear(int year)
   {
      using var connection = _connectionFactory.Create();
      return connection.Query<Order>("spOrder_GetUnderCondition", new { CreateDateYear = year }, commandType: CommandType.StoredProcedure).ToList();
   }

   public List<Order> ReadByProductId(int productId)
   {
      using var connection = _connectionFactory.Create();
      return connection.Query<Order>("spOrder_GetUnderCondition", new { ProductId = productId }, commandType: CommandType.StoredProcedure).ToList();
   }

   public List<Order> ReadByStatus(Status status)
   {
      using var connection = _connectionFactory.Create();
      return connection.Query<Order>("spOrder_GetUnderCondition", new { Status = status.ToString() }, commandType: CommandType.StoredProcedure).ToList();
   }

   public void DeleteByCreationMonth(int month)
   {
      using var connection = _connectionFactory.Create();
      var numberOfRows = connection.Execute("spOrder_DeleteUnderCondition", new { CreateDateMonth = month }, commandType: CommandType.StoredProcedure);
   }

   public void DeleteByCreationYear(int year)
   {
      using var connection = _connectionFactory.Create();
      var numberOfRows = connection.Execute("spOrder_DeleteUnderCondition", new { CreateDateYear = year }, commandType: CommandType.StoredProcedure);
   }

   public void DeleteByProductId(int productId)
   {
      using var connection = _connectionFactory.Create();
      var numberOfRows = connection.Execute("spOrder_DeleteUnderCondition", new { ProductId = productId }, commandType: CommandType.StoredProcedure);
   }

   public void DeleteByStatus(Status status)
   {
      using var connection = _connectionFactory.Create();
      var numberOfRows = connection.Execute("spOrder_DeleteUnderCondition", new { Status = status.ToString() }, commandType: CommandType.StoredProcedure);
   }

   private object FillParameters(Order order)
   {
      return new
      {
         order.Id,
         Status = order.Status.ToString(),
         order.CreateDate,
         order.UpdateDate,
         order.ProductId
      };
   }


}
