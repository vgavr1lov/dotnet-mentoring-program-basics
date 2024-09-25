using DBHandlerLibrary;

namespace ConsoleApp1
{
   public class Program
   {
      static void Main(string[] args)
      {
         var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ADODotNetFundamentalsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False";
         //var productHandler = new ProductRepository(connectionString);

         //var newProduct = new Product();
         //newProduct.Description = "Test prod";
         //newProduct.Length = 1.2M;
         //newProduct.Height = 2.3M;
         //newProduct.Weight = 5.8M;
         //newProduct.Width = 0.8M;
         //var newId = productHandler.Create(newProduct);

         //Console.WriteLine($"Product wiht ID {newId} is created");


         //newProduct.Id = newId;
         //newProduct.Description = $"Test prod {newId}";
         //Random random = new Random();
         //newProduct.Length = random.Next(1, 10) * 0.99M;
         //newProduct.Height = random.Next(1, 10) * 0.99M;
         //newProduct.Weight = random.Next(1, 10) * 0.99M;
         //newProduct.Width = random.Next(1, 10) * 0.99M;

         //var numberOfRows = productHandler.Update(newProduct);
         //Console.WriteLine($"Updated {numberOfRows} rows");

         //numberOfRows = productHandler.Delete(57);
         //Console.WriteLine($"Deleted {numberOfRows} rows");

         //var productReadById = productHandler.Read(newId);
         //Console.WriteLine(productReadById.Id);
         //Console.WriteLine(productReadById.Description);
         //Console.WriteLine(productReadById.Weight);
         //Console.WriteLine(productReadById.Height);
         //Console.WriteLine(productReadById.Width);
         //Console.WriteLine(productReadById.Length);

         ////var productReadByDescList = productHandler.Read("Test prod 4");
         ////var productReadByDescList = productHandler.Read();
         ////foreach (var product in productReadByDescList)
         ////{
         ////   Console.WriteLine(product.Id);
         ////   Console.WriteLine(product.Description);
         ////   Console.WriteLine(product.Weight);
         ////   Console.WriteLine(product.Height);
         ////   Console.WriteLine(product.Width);
         ////   Console.WriteLine(product.Length);
         ////}


         //var orderDbStorage = new OrderRepository(connectionString);

         //var order = new Order();
         //order.Status = Status.NotStarted;
         //order.CreateDate = new(2024, 1, 31);
         //order.UpdateDate = new(2024, 1, 31);
         //order.ProductId = random.Next(1, 20);
         //newId = orderDbStorage.Create(order);
         //Console.WriteLine($"Order wiht ID {newId} is created");

         //order.Id = newId;
         //order.Status = Status.Cancelled;
         //order.CreateDate = new(random.Next(2020, 2024), random.Next(1, 12), random.Next(1, 28));
         //order.UpdateDate = new(random.Next(2020, 2024), random.Next(1, 12), random.Next(1, 28));
         //order.ProductId = random.Next(30, 40);
         //numberOfRows = orderDbStorage.Update(order);
         //Console.WriteLine($"Updated {numberOfRows} rows");

         //numberOfRows = orderDbStorage.DeleteByProductId(33);
         //Console.WriteLine($"Deleted {numberOfRows} rows");

         //numberOfRows = orderDbStorage.DeleteByCreationYear(2020);
         //Console.WriteLine($"Deleted {numberOfRows} rows");
         //var orderReadById = orderDbStorage.Read(newId);
         //Console.WriteLine(orderReadById.Id);
         //Console.WriteLine(orderReadById.Status);
         //Console.WriteLine(orderReadById.CreateDate);
         //Console.WriteLine(orderReadById.UpdateDate);
         //Console.WriteLine(orderReadById.ProductId);


         //numberOfRows = orderDbStorage.Delete(2);
         //Console.WriteLine($"Deleted {numberOfRows} rows");

         //var orders = orderDbStorage.ReadByCreationMonth(2);
         //Console.WriteLine($"Orders created in Febriary:");
         //foreach (var singleOrder in orders)
         //{
         //   Console.WriteLine(singleOrder.Id);
         //   Console.WriteLine(singleOrder.Status);
         //   Console.WriteLine(singleOrder.CreateDate);
         //   Console.WriteLine(singleOrder.UpdateDate);
         //   Console.WriteLine(singleOrder.ProductId);
         //}

         //orders = orderDbStorage.ReadByCreationYear(2024);
         //Console.WriteLine($"Orders created in 2024:");
         //foreach (var singleOrder in orders)
         //{
         //   Console.WriteLine(singleOrder.Id);
         //   Console.WriteLine(singleOrder.Status);
         //   Console.WriteLine(singleOrder.CreateDate);
         //   Console.WriteLine(singleOrder.UpdateDate);
         //   Console.WriteLine(singleOrder.ProductId);
         //}

         //orders = orderDbStorage.ReadByStatus(Status.Loading);
         //Console.WriteLine($"Orders with status Loading:");
         //foreach (var singleOrder in orders)
         //{
         //   Console.WriteLine(singleOrder.Id);
         //   Console.WriteLine(singleOrder.Status);
         //   Console.WriteLine(singleOrder.CreateDate);
         //   Console.WriteLine(singleOrder.UpdateDate);
         //   Console.WriteLine(singleOrder.ProductId);
         //}

         //orders = orderDbStorage.ReadByProduct(11);
         //Console.WriteLine($"Orders with Product ID 11:");
         //foreach (var singleOrder in orders)
         //{
         //   Console.WriteLine(singleOrder.Id);
         //   Console.WriteLine(singleOrder.Status);
         //   Console.WriteLine(singleOrder.CreateDate);
         //   Console.WriteLine(singleOrder.UpdateDate);
         //   Console.WriteLine(singleOrder.ProductId);
         //}

         var repository = new OrderRepository(connectionString);
         var orderService = new OrderService(repository);

         var orders = orderService.ReadOrderByStatus(Status.Cancelled);
         Console.WriteLine($"Orders with status Cancelled:");
         foreach (var singleOrder in orders)
         {
            Console.WriteLine(singleOrder.Id);
            Console.WriteLine(singleOrder.Status);
            Console.WriteLine(singleOrder.CreateDate);
            Console.WriteLine(singleOrder.UpdateDate);
            Console.WriteLine(singleOrder.ProductId);
         }


         orders = orderService.ReadOrderByCreationMonth(2);
         Console.WriteLine($"Orders created in Feb:");
         foreach (var singleOrder in orders)
         {
            Console.WriteLine(singleOrder.Id);
            Console.WriteLine(singleOrder.Status);
            Console.WriteLine(singleOrder.CreateDate);
            Console.WriteLine(singleOrder.UpdateDate);
            Console.WriteLine(singleOrder.ProductId);
         }

         orders = orderService.ReadOrderByCreationYear(2022);
         Console.WriteLine($"Orders created in 2022:");
         foreach (var singleOrder in orders)
         {
            Console.WriteLine(singleOrder.Id);
            Console.WriteLine(singleOrder.Status);
            Console.WriteLine(singleOrder.CreateDate);
            Console.WriteLine(singleOrder.UpdateDate);
            Console.WriteLine(singleOrder.ProductId);
         }


         orders = orderService.ReadOrderByProduct(11);
         Console.WriteLine($"Orders with Product ID 11:");
         foreach (var singleOrder in orders)
         {
            Console.WriteLine(singleOrder.Id);
            Console.WriteLine(singleOrder.Status);
            Console.WriteLine(singleOrder.CreateDate);
            Console.WriteLine(singleOrder.UpdateDate);
            Console.WriteLine(singleOrder.ProductId);
         }

         var numberOfRows = orderService.DeleteOrderByCreationMonth(2);
         Console.WriteLine($"Deleted {numberOfRows} rows");

      }
   }
}
