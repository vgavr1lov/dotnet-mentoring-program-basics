using DBHandlerLibrary.DataSetOrderTableAdapters;
using System.Data;
using System.Data.SqlClient;

namespace DBHandlerLibrary
{
   public class OrderRepository : IOrderRepository
   {
      private string ConnectionString { get; set; }

      public OrderRepository(string connectionString)
      {
         ConnectionString = connectionString;
      }
      public int Create(IOrder order)
      {
         int newId;
         using (var connection = new SqlConnection(ConnectionString))
         {
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
               var command = connection.CreateCommand();

               command.Transaction = transaction;

               command.CommandText = @"insert into dbo.[Order](Status, CreateDate, UpdateDate, ProductId)
                                       values(@Status, @CreateDate, @UpdateDate, @ProductId);
                                       select scope_identity();";
               command.Parameters.AddWithValue("@Status", order.Status.ToString());
               command.Parameters.AddWithValue("@CreateDate", order.CreateDate.ToDateTime(TimeOnly.MinValue));
               command.Parameters.AddWithValue("@UpdateDate", order.UpdateDate.ToDateTime(TimeOnly.MinValue));
               command.Parameters.AddWithValue("@ProductId", order.ProductId);
               var result = command.ExecuteScalar();
               int.TryParse(result.ToString(), out newId);
               transaction.Commit();
            }
         }

         return newId;
      }

      public IOrder Read(int orderId)
      {
         var order = new Order();

         using (var connection = new SqlConnection(ConnectionString))
         {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
               command.CommandText = "select * from dbo.[Order] where Id = @Id";
               command.Parameters.AddWithValue("@Id", orderId);

               using (var reader = command.ExecuteReader())
               {
                  while (reader.Read())
                  {
                     order.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                     Enum.TryParse(reader.GetString(reader.GetOrdinal("Status")), out Status status);
                     order.Status = status;
                     order.CreateDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("CreateDate")));
                     order.UpdateDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("UpdateDate")));
                     order.ProductId = reader.GetInt32(reader.GetOrdinal("ProductId"));
                  }
               }
            }
         }

         return order;
      }

      public DataSetOrder Read()
      {
         using (var connection = new SqlConnection(ConnectionString))
         {
            connection.Open();
            var adapterManager = new DataSetOrderTableAdapters.TableAdapterManager();
            adapterManager.OrderTableAdapter = new OrderTableAdapter() { Connection = connection };
            var dataSet = new DataSetOrder();
            adapterManager.OrderTableAdapter.Fill(dataSet.Order);

            return dataSet;
         }
      }

      public DataTable? ReadAsDataTable()
      {
         using (var connection = new SqlConnection(ConnectionString))
         {
            connection.Open();
            var query = "exec dbo.spOrder_GetAll;";
            var dataAdapter = new SqlDataAdapter(query, connection);
            var dataSet = new DataSet();
            dataAdapter.Fill(dataSet, "Order");

            return dataSet.Tables["Order"];
         }
      }

      public int Update(IOrder order)
      {
         using (var connection = new SqlConnection(ConnectionString))
         {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
               command.CommandText = @"update dbo.[Order]
                                       set Status = @Status, CreateDate = @CreateDate, UpdateDate = @UpdateDate, ProductId = @ProductId
                                       where Id = @Id";
               command.Parameters.AddWithValue("@Id", order.Id);
               command.Parameters.AddWithValue("@Status", order.Status.ToString());
               command.Parameters.AddWithValue("@CreateDate", order.CreateDate.ToDateTime(TimeOnly.MinValue));
               command.Parameters.AddWithValue("@UpdateDate", order.UpdateDate.ToDateTime(TimeOnly.MinValue));
               command.Parameters.AddWithValue("@ProductId", order.ProductId);
               var rowsUpdated = command.ExecuteNonQuery();

               return rowsUpdated;
            }
         }
      }

      public int Delete(int orderId)
      {
         int rowsDeleted;
         using (var connection = new SqlConnection(ConnectionString))
         {
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
               var command = connection.CreateCommand();

               command.Transaction = transaction;

               command.CommandText = @"delete dbo.[Order]
                                       where Id = @Id";
               command.Parameters.AddWithValue("@Id", orderId);

               rowsDeleted = command.ExecuteNonQuery();

               transaction.Commit();
            }
         }

         return rowsDeleted;
      }

      public int DeleteByProductId(int productId)
      {
         int rowsDeleted;

         using (var connection = new SqlConnection(ConnectionString))
         {
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
               var command = connection.CreateCommand();

               command.Transaction = transaction;

               command.CommandText = "exec dbo.spOrder_DeleteUnderCondition @ProductId = @productId";

               command.Parameters.AddWithValue("@productId", productId);

               rowsDeleted = command.ExecuteNonQuery();

               transaction.Commit();
            }
         }

         return rowsDeleted;
      }


      public int DeleteBulk(DataSetOrder dataSet)
      {
         int rowsBeforeDeletion = dataSet.Order.Count();
         using (var connection = new SqlConnection(ConnectionString))
         {
            connection.Open();
            using (var transaction = connection.BeginTransaction())
            {
               var adapterManager = new DataSetOrderTableAdapters.TableAdapterManager();
               adapterManager.OrderTableAdapter = new OrderTableAdapter();
               adapterManager.OrderTableAdapter.Connection = connection;
               adapterManager.OrderTableAdapter.Transaction = transaction;
               adapterManager.OrderTableAdapter.Update(dataSet.Order);
               transaction.Commit();
            }
         }
         int rowsAfterDeletion = dataSet.Order.Count();

         return rowsBeforeDeletion - rowsAfterDeletion;
      }

   }
}
