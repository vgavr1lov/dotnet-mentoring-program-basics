using System.Data.SqlClient;

namespace DBHandlerLibrary
{
   public class ProductRepository : IProductRepository
   {
      private string ConnectionString { get; set; }

      public ProductRepository(string connectionString)
      {
         ConnectionString = connectionString;
      }
      public int Create(IProduct product)
      {
         int newId;
         using (var connection = new SqlConnection(ConnectionString))
         {
            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
               var command = connection.CreateCommand();
               command.Transaction = transaction;
               command.CommandText = @"insert into dbo.Product(Description, Weight, Height, Width, Length)
                                       values(@Description, @Weight, @Height, @Width, @Length);
                                       select scope_identity();";
               command.Parameters.AddWithValue("@Description", product.Description);
               command.Parameters.AddWithValue("@Weight", product.Weight);
               command.Parameters.AddWithValue("@Height", product.Height);
               command.Parameters.AddWithValue("@Width", product.Width);
               command.Parameters.AddWithValue("@Length", product.Length);
               var result = command.ExecuteScalar();
               int.TryParse(result.ToString(), out newId);
               transaction.Commit();
            }
         }

         return newId;
      }

      public IProduct Read(int productId)
      {
         var product = new Product();

         using (var connection = new SqlConnection(ConnectionString))
         {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
               command.CommandText = "select * from dbo.Product where Id = @Id";
               command.Parameters.AddWithValue("@Id", productId);

               using (var reader = command.ExecuteReader())
               {
                  while (reader.Read())
                  {
                     product.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                     product.Description = reader.GetString(reader.GetOrdinal("Description"));
                     product.Weight = reader.GetDecimal(reader.GetOrdinal("Weight"));
                     product.Height = reader.GetDecimal(reader.GetOrdinal("Height"));
                     product.Width = reader.GetDecimal(reader.GetOrdinal("Width"));
                     product.Length = reader.GetDecimal(reader.GetOrdinal("Length"));
                  }
               }
            }
         }

         return product;
      }

      public List<IProduct> Read(string productDescription)
      {
         var products = new List<IProduct>();
         using (var connection = new SqlConnection(ConnectionString))
         {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
               command.CommandText = "select * from dbo.Product where Description like @Description";
               command.Parameters.AddWithValue("@Description", $"%{productDescription}%");

               using (var reader = command.ExecuteReader())
               {
                  while (reader.Read())
                  {
                     var product = new Product();
                     product.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                     product.Description = reader.GetString(reader.GetOrdinal("Description"));
                     product.Weight = reader.GetDecimal(reader.GetOrdinal("Weight"));
                     product.Height = reader.GetDecimal(reader.GetOrdinal("Height"));
                     product.Width = reader.GetDecimal(reader.GetOrdinal("Width"));
                     product.Length = reader.GetDecimal(reader.GetOrdinal("Length"));
                     products.Add(product);
                  }
               }
            }
         }

         return products;
      }


      public List<IProduct> Read()
      {
         var products = new List<IProduct>();

         using (var connection = new SqlConnection(ConnectionString))
         {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
               command.CommandText = "select * from dbo.Product";

               using (var reader = command.ExecuteReader())
               {
                  while (reader.Read())
                  {
                     var product = new Product();
                     product.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                     product.Description = reader.GetString(reader.GetOrdinal("Description"));
                     product.Weight = reader.GetDecimal(reader.GetOrdinal("Weight"));
                     product.Height = reader.GetDecimal(reader.GetOrdinal("Height"));
                     product.Width = reader.GetDecimal(reader.GetOrdinal("Width"));
                     product.Length = reader.GetDecimal(reader.GetOrdinal("Length"));
                     products.Add(product);
                  }
               }
            }
         }

         return products;
      }

      public int Update(IProduct product)
      {
         using (var connection = new SqlConnection(ConnectionString))
         {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
               command.CommandText = @"update dbo.Product
                                       set Description = @Description, Weight = @Weight, Height = @Height, Width = @Width, Length = @Length
                                       where Id = @Id";
               command.Parameters.AddWithValue("@Id", product.Id);
               command.Parameters.AddWithValue("@Description", product.Description);
               command.Parameters.AddWithValue("@Weight", product.Weight);
               command.Parameters.AddWithValue("@Height", product.Height);
               command.Parameters.AddWithValue("@Width", product.Width);
               command.Parameters.AddWithValue("@Length", product.Length);
               var rowsUpdated = command.ExecuteNonQuery();
               return rowsUpdated;
            }
         }
      }

      public int Delete(int productId)
      {
         try
         {
            using (var connection = new SqlConnection(ConnectionString))
            {
               connection.Open();
               var command = connection.CreateCommand();
               command.CommandText = @"delete dbo.Product
                                       where Id = @Id";
               command.Parameters.AddWithValue("@Id", productId);
               var rowsDeleted = command.ExecuteNonQuery();
               return rowsDeleted;
            }
         }
         catch (SqlException)
         {
            throw;
         }
      }

   }
}