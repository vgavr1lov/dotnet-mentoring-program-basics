using Data;
using EFHomeTaskLibrary;

namespace ConsoleApp2;

public class Application
{
   private IUnitOfWork UnitOfWork { get; set; }
   public Application(IUnitOfWork unitOfWork)
   {
      UnitOfWork = unitOfWork;
   }

   public void Run()
   {
      var newProduct = new Product();
      Random random = new Random();
      newProduct.Description = $"Test prod {random.Next(1, 20)}";
      newProduct.Length = random.Next(1, 20);
      newProduct.Height = random.Next(1, 20);
      newProduct.Weight = random.Next(1, 20);
      newProduct.Width = random.Next(1, 20);

      UnitOfWork.ProductRepository.Create(newProduct);
      UnitOfWork.Save();
      Console.WriteLine($"Product wiht ID {newProduct.Id} is created");

      newProduct.Description = $"Test prod {newProduct.Id}";
      UnitOfWork.ProductRepository.Update(newProduct);
      UnitOfWork.Save();

      var productReadById = UnitOfWork.ProductRepository.Read(newProduct.Id);
      Console.WriteLine(productReadById!.Id);
      Console.WriteLine(productReadById.Description);
      Console.WriteLine(productReadById.Weight);
      Console.WriteLine(productReadById.Height);
      Console.WriteLine(productReadById.Width);
      Console.WriteLine(productReadById.Length);

      var productReadByDescList = UnitOfWork.ProductRepository.Read("Test prod 19");
      foreach (var product in productReadByDescList)
      {
         Console.WriteLine(product.Id);
         Console.WriteLine(product.Description);
         Console.WriteLine(product.Weight);
         Console.WriteLine(product.Height);
         Console.WriteLine(product.Width);
         Console.WriteLine(product.Length);
      }

      var allProducts = UnitOfWork.ProductRepository.Read();
      Console.WriteLine($"Number of Products is {allProducts.Count}");

      var newProduct2 = new Product();
      newProduct2.Description = $"Test prod {random.Next(1, 20)}";
      newProduct2.Length = random.Next(1, 20);
      newProduct2.Height = random.Next(1, 20);
      newProduct2.Weight = random.Next(1, 20);
      newProduct2.Width = random.Next(1, 20);
      UnitOfWork.ProductRepository.Create(newProduct2);
      UnitOfWork.Save();

      Console.WriteLine($"Product wiht ID {newProduct2.Id} is created");

      UnitOfWork.ProductRepository.Delete(newProduct2.Id);
      var numberOfRowsDeleted = UnitOfWork.Save();
      if (numberOfRowsDeleted > 0)
         Console.WriteLine($"Product wiht ID {newProduct2.Id} was deleted");
      else
         Console.WriteLine($"Product wiht ID {newProduct2.Id} was not deleted");


      var order = new Order();
      order.Status = Status.NotStarted;
      order.CreateDate = new(random.Next(2020, 2024), random.Next(1, 12), random.Next(1, 28));
      order.UpdateDate = new(random.Next(2020, 2024), random.Next(1, 12), random.Next(1, 28));
      order.ProductId = newProduct.Id;

      UnitOfWork.OrderRepository.Create(order);
      UnitOfWork.Save();
      Console.WriteLine($"Order wiht ID {order.Id} is created");

      order.Status = Status.Cancelled;
      order.UpdateDate = new(random.Next(2020, 2024), random.Next(1, 12), random.Next(1, 28));
      UnitOfWork.OrderRepository.Update(order);
      var numberOfRows = UnitOfWork.Save();

      Console.WriteLine($"Updated {numberOfRows} rows");

      var orderReadById = UnitOfWork.OrderRepository.Read(order.Id);
      Console.WriteLine(orderReadById?.Id);
      Console.WriteLine(orderReadById?.Status);
      Console.WriteLine(orderReadById?.CreateDate);
      Console.WriteLine(orderReadById?.UpdateDate);
      Console.WriteLine(orderReadById?.ProductId);

      UnitOfWork.OrderRepository.Delete(11);
      numberOfRows = UnitOfWork.Save();
      Console.WriteLine($"Deleted {numberOfRows} rows");

      var orders = UnitOfWork.OrderRepository.ReadByCreationMonth(2);
      Console.WriteLine($"Orders created in Feb:");
      foreach (var singleOrder in orders)
      {
         Console.WriteLine(singleOrder.Id);
         Console.WriteLine(singleOrder.Status);
         Console.WriteLine(singleOrder.CreateDate);
         Console.WriteLine(singleOrder.UpdateDate);
         Console.WriteLine(singleOrder.ProductId);
      }

      orders = UnitOfWork.OrderRepository.ReadByCreationYear(2022);
      Console.WriteLine($"Orders created in 2022:");
      foreach (var singleOrder in orders)
      {
         Console.WriteLine(singleOrder.Id);
         Console.WriteLine(singleOrder.Status);
         Console.WriteLine(singleOrder.CreateDate);
         Console.WriteLine(singleOrder.UpdateDate);
         Console.WriteLine(singleOrder.ProductId);
      }

      orders = UnitOfWork.OrderRepository.ReadByProductId(1);
      Console.WriteLine($"Orders with Product ID 1:");
      foreach (var singleOrder in orders)
      {
         Console.WriteLine(singleOrder.Id);
         Console.WriteLine(singleOrder.Status);
         Console.WriteLine(singleOrder.CreateDate);
         Console.WriteLine(singleOrder.UpdateDate);
         Console.WriteLine(singleOrder.ProductId);
      }

      var orders = UnitOfWork.OrderRepository.ReadByStatus(Status.Cancelled);
      Console.WriteLine($"Orders with Status Cancelled:");
      foreach (var singleOrder in orders)
      {
         Console.WriteLine(singleOrder.Id);
         Console.WriteLine(singleOrder.Status);
         Console.WriteLine(singleOrder.CreateDate);
         Console.WriteLine(singleOrder.UpdateDate);
         Console.WriteLine(singleOrder.ProductId);
      }

      UnitOfWork.OrderRepository.DeleteByProductId(11);
      var numberOfRows = UnitOfWork.Save();
      Console.WriteLine($"Deleted {numberOfRows} rows");

      UnitOfWork.OrderRepository.DeleteByCreationMonth(3);
      numberOfRows = UnitOfWork.Save();
      Console.WriteLine($"Deleted {numberOfRows} rows");
   }
}