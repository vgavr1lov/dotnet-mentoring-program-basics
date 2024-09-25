using System.Data;

namespace DBHandlerLibrary
{
   public class OrderService
   {
      private IOrderRepository Repository { get; set; }
      public OrderService(IOrderRepository repository)
      {
         Repository = repository;
      }

      public int CreateOrder(IOrder order)
      {
         return Repository.Create(order);
      }

      public int DeleteOrder(int orderId)
      {
         return Repository.Delete(orderId);
      }

      public int DeleteOrderByCreationMonth(int month)
      {
         var dataSet = Repository.Read();
         dataSet.Order
                  .Where(row => row.CreateDate.Month == month)
                  .ToList()
                  .ForEach(row => row.Delete());

         var rowsDeleted = Repository.DeleteBulk(dataSet);

         return rowsDeleted;
      }

      public int DeleteOrderByCreationYear(int year)
      {
         var dataSet = Repository.Read();
         dataSet.Order
                  .Where(row => row.CreateDate.Year == year)
                  .ToList()
                  .ForEach(row => row.Delete());

         var rowsDeleted = Repository.DeleteBulk(dataSet);

         return rowsDeleted;
      }

      public int DeleteOrderByProductId(int productId)
      {
         return Repository.DeleteByProductId(productId);
      }

      public int DeleteOrderByStatus(Status status)
      {
         var dataSet = Repository.Read();
         dataSet.Order
                  .Where(row => row.Status == status.ToString())
                  .ToList()
                  .ForEach(row => row.Delete());

         var rowsDeleted = Repository.DeleteBulk(dataSet);

         return rowsDeleted;
      }

      public IOrder ReadOrder(int orderId)
      {
         return Repository.Read(orderId);
      }

      public List<Order> ReadOrderByCreationMonth(int month)
      {
         var dataSet = Repository.Read();
         var orders = dataSet.Order
               .Where(row => row.CreateDate.Month == month)
               .Select(row => new Order
               {
                  Id = row.Id,
                  Status = (Status)Enum.Parse(typeof(Status), row.Status),
                  CreateDate = DateOnly.FromDateTime(row.CreateDate),
                  UpdateDate = DateOnly.FromDateTime(row.UpdateDate),
                  ProductId = row.ProductId,
               })
               .ToList();

         return orders;
      }

      public List<Order> ReadOrderByCreationYear(int year)
      {
         var dataSet = Repository.Read();
         var orders = dataSet.Order
               .Where(row => row.CreateDate.Year == year)
               .Select(row => new Order
               {
                  Id = row.Id,
                  Status = (Status)Enum.Parse(typeof(Status), row.Status),
                  CreateDate = DateOnly.FromDateTime(row.CreateDate),
                  UpdateDate = DateOnly.FromDateTime(row.UpdateDate),
                  ProductId = row.ProductId,
               })
               .ToList();

         return orders;
      }

      public List<Order>? ReadOrderByProduct(int productId)
      {
         var ordersTable = Repository.ReadAsDataTable();
         var result = ordersTable?.Select($"ProductId = {productId}");

         if (result == null)
            return null;

         var orders = new List<Order>();
         foreach (var row in result)
         {
            var order = new Order();
            order.Id = (int)row["ID"];
            Enum.TryParse(row["Status"].ToString(), out Status status);
            order.Status = status;
            order.CreateDate = DateOnly.FromDateTime((DateTime)row["CreateDate"]);
            order.UpdateDate = DateOnly.FromDateTime((DateTime)row["UpdateDate"]);
            order.ProductId = (int)row["ProductId"];
            orders.Add(order);
         }

         return orders;
      }

      public List<Order> ReadOrderByStatus(Status status)
      {
         var dataSet = Repository.Read();
         var orders = dataSet.Order
               .Where(row => row.Status == status.ToString())
               .Select(row => new Order
               {
                  Id = row.Id,
                  Status = (Status)Enum.Parse(typeof(Status), row.Status),
                  CreateDate = DateOnly.FromDateTime(row.CreateDate),
                  UpdateDate = DateOnly.FromDateTime(row.UpdateDate),
                  ProductId = row.ProductId,
               })
               .ToList();

         return orders;
      }

      public int UpdateOrder(IOrder order)
      {
         return Repository.Update(order);
      }
   }
}
