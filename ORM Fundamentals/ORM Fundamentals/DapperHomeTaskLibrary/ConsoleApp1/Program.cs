using Dapper;
using DapperHomeTaskLibrary;

namespace ConsoleApp1
{
   public class Program
   {
      static void Main(string[] args)
      {
         SqlMapper.AddTypeHandler(new StatusTypeHandler());
         var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DapperHomeTaskDb;Integrated Security=True;";
         var productRepository = new ProductRepository(connectionString);
         var productService = new ProductService(productRepository);

         var newProduct = new Product();
         Random random = new Random();
         newProduct.Description = $"Test prod {random.Next(1, 20)}";
         newProduct.Length = random.Next(1, 20);
         newProduct.Height = random.Next(1, 20);
         newProduct.Weight = random.Next(1, 20);
         newProduct.Width = random.Next(1, 20);
         newProduct.Id = productService.CreateProduct(newProduct);

         Console.WriteLine($"Product wiht ID {newProduct.Id} is created");

         newProduct.Description = $"Test prod {newProduct.Id} updated";
         productService.UpdateProduct(newProduct);

         var productReadById = productService.ReadProduct(newProduct.Id);
         Console.WriteLine(productReadById!.Id);
         Console.WriteLine(productReadById.Description);
         Console.WriteLine(productReadById.Weight);
         Console.WriteLine(productReadById.Height);
         Console.WriteLine(productReadById.Width);
         Console.WriteLine(productReadById.Length);

         var allProducts = productService.ReadProducts();
         Console.WriteLine($"Number of Products is {allProducts.Count}");

         var productReadByDescList = productService.ReadProduct("Test prod 19");
         foreach (var product in productReadByDescList)
         {
            Console.WriteLine(product.Id);
            Console.WriteLine(product.Description);
            Console.WriteLine(product.Weight);
            Console.WriteLine(product.Height);
            Console.WriteLine(product.Width);
            Console.WriteLine(product.Length);
         }

         var newProduct2 = new Product();
         newProduct2.Description = $"Test prod {random.Next(1, 20)}";
         newProduct2.Length = random.Next(1, 20);
         newProduct2.Height = random.Next(1, 20);
         newProduct2.Weight = random.Next(1, 20);
         newProduct2.Width = random.Next(1, 20);
         var newId2 = productService.CreateProduct(newProduct2);

         Console.WriteLine($"Product wiht ID {newId2} is created");

         var numberOfRowsDeleted = productService.DeleteProduct(newId2);
         if (numberOfRowsDeleted > 0)
            Console.WriteLine($"Product wiht ID {newId2} was deleted");
         else
            Console.WriteLine($"Product wiht ID {newId2} was not deleted");

         var orderRepository = new OrderRepository(connectionString);
         var orderService = new OrderService(orderRepository);

         var order = new Order();
         order.Status = Status.NotStarted;
         order.CreateDate = new(random.Next(2020, 2024), random.Next(1, 12), random.Next(1, 28));
         order.UpdateDate = new(random.Next(2020, 2024), random.Next(1, 12), random.Next(1, 28));
         order.ProductId = newProduct.Id;
         order.Id = orderService.CreateOrder(order);
         Console.WriteLine($"Order wiht ID {order.Id} is created");


         order.Status = Status.Done;
         order.CreateDate = new(2024, random.Next(1, 12), random.Next(1, 28));
         orderService.UpdateOrder(order);

         var newOrder = orderService.ReadOrder(13);
         Console.WriteLine(newOrder.Id);
         Console.WriteLine(newOrder.Status);
         Console.WriteLine(newOrder.CreateDate);
         Console.WriteLine(newOrder.UpdateDate);
         Console.WriteLine(newOrder.ProductId);

         var idToDelete = 6;
         numberOfRowsDeleted = orderService.DeleteOrder(idToDelete);
         if (numberOfRowsDeleted > 0)
            Console.WriteLine($"Product wiht ID {idToDelete} was deleted");
         else
            Console.WriteLine($"Product wiht ID {idToDelete} was not deleted");

         var orders = orderService.ReadOrderByCreationMonth(2);
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

         orders = orderService.ReadOrderByProductId(43);
         Console.WriteLine($"Orders with Product ID 43:");
         foreach (var singleOrder in orders)
         {
            Console.WriteLine(singleOrder.Id);
            Console.WriteLine(singleOrder.Status);
            Console.WriteLine(singleOrder.CreateDate);
            Console.WriteLine(singleOrder.UpdateDate);
            Console.WriteLine(singleOrder.ProductId);
         }

         orders = orderService.ReadOrderByStatus(Status.Cancelled);
         Console.WriteLine($"Orders with Status Cancelled:");
         foreach (var singleOrder in orders)
         {
            Console.WriteLine(singleOrder.Id);
            Console.WriteLine(singleOrder.Status);
            Console.WriteLine(singleOrder.CreateDate);
            Console.WriteLine(singleOrder.UpdateDate);
            Console.WriteLine(singleOrder.ProductId);
         }

         //var numberOfRows = orderService.DeleteOrderByCreationMonth(7);
         //Console.WriteLine($"Deleted {numberOfRows} rows");

         //numberOfRows = orderService.DeleteOrderByCreationYear(2024);
         //Console.WriteLine($"Deleted {numberOfRows} rows");

         //var numberOfRows = orderService.DeleteOrderByProductId(51);
         //Console.WriteLine($"Deleted {numberOfRows} rows");

         //var numberOfRows = orderService.DeleteOrderByStatus(Status.Cancelled);
         //Console.WriteLine($"Deleted {numberOfRows} rows");
      }
   }
}
