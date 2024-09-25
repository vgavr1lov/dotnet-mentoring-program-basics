using Data;
using Microsoft.EntityFrameworkCore;

namespace EFHomeTaskLibrary.Tests;

public class OrderRepositoryTests
{
   [Fact]
   public void Create_ProvideOrderShouldSaveSuccessfully()
   {
      var options = new DbContextOptionsBuilder<EFDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

      var sampleOrder = GetSampleOrder();

      using (var context = new EFDbContext(options))
      {
         var unitOfWork = new UnitOfWork(context, new ProductRepository(context), new OrderRepository(context));

         unitOfWork.OrderRepository.Create(sampleOrder);
         var result = unitOfWork.Save();

         Assert.Equal(1, result);
      }
   }

   [Fact]
   public void Update_ProvideOrderShouldReturnNumberOfRowsUpdated()
   {
      var options = new DbContextOptionsBuilder<EFDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

      var sampleOrder = GetSampleOrder();

      using (var context = new EFDbContext(options))
      {
         var unitOfWork = new UnitOfWork(context, new ProductRepository(context), new OrderRepository(context));

         unitOfWork.OrderRepository.Create(sampleOrder);
         unitOfWork.Save();

         unitOfWork.OrderRepository.Update(sampleOrder);
         var result = unitOfWork.Save();

         Assert.Equal(1, result);
      }
   }

   [Fact]
   public void Delete_ProvideOrderIdShouldReturnNumberOfRowsDeleted()
   {
      var options = new DbContextOptionsBuilder<EFDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

      var sampleOrder = GetSampleOrder();

      using (var context = new EFDbContext(options))
      {
         var unitOfWork = new UnitOfWork(context, new ProductRepository(context), new OrderRepository(context));

         unitOfWork.OrderRepository.Create(sampleOrder);
         unitOfWork.Save();

         unitOfWork.OrderRepository.Delete(sampleOrder.Id);
         var result = unitOfWork.Save();

         Assert.Equal(1, result);
      }
   }

   [Fact]
   public void DeleteByProductId_ProvideProductIdShouldReturnNumberOfRowsDeleted()
   {
      var options = new DbContextOptionsBuilder<EFDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

      var sampleOrder = GetSampleOrder();

      using (var context = new EFDbContext(options))
      {
         var unitOfWork = new UnitOfWork(context, new ProductRepository(context), new OrderRepository(context));

         unitOfWork.OrderRepository.Create(sampleOrder);
         unitOfWork.Save();

         unitOfWork.OrderRepository.DeleteByProductId(sampleOrder.ProductId);
         var result = unitOfWork.Save();

         Assert.True(result > 0);
      }
   }

   [Fact]
   public void DeleteByCreationMonth_ProvideMonthShouldReturnNumberOfRowsDeleted()
   {
      var options = new DbContextOptionsBuilder<EFDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

      var sampleOrder = GetSampleOrder();

      using (var context = new EFDbContext(options))
      {
         var unitOfWork = new UnitOfWork(context, new ProductRepository(context), new OrderRepository(context));

         unitOfWork.OrderRepository.Create(sampleOrder);
         unitOfWork.Save();

         unitOfWork.OrderRepository.DeleteByCreationMonth(sampleOrder.CreateDate.Month);
         var result = unitOfWork.Save();

         Assert.True(result > 0);
      }
   }

   [Fact]
   public void DeleteByCreationYear_ProvideYearShouldReturnNumberOfRowsDeleted()
   {
      var options = new DbContextOptionsBuilder<EFDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

      var sampleOrder = GetSampleOrder();

      using (var context = new EFDbContext(options))
      {
         var unitOfWork = new UnitOfWork(context, new ProductRepository(context), new OrderRepository(context));

         unitOfWork.OrderRepository.Create(sampleOrder);
         unitOfWork.Save();

         unitOfWork.OrderRepository.DeleteByCreationYear(sampleOrder.CreateDate.Year);
         var result = unitOfWork.Save();

         Assert.True(result > 0);
      }
   }
   [Fact]
   public void DeleteByStatus_ProvideStatusShouldReturnNumberOfRowsDeleted()
   {
      var options = new DbContextOptionsBuilder<EFDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

      var sampleOrder = GetSampleOrder();

      using (var context = new EFDbContext(options))
      {
         var unitOfWork = new UnitOfWork(context, new ProductRepository(context), new OrderRepository(context));

         unitOfWork.OrderRepository.Create(sampleOrder);
         unitOfWork.Save();

         unitOfWork.OrderRepository.DeleteByStatus(sampleOrder.Status);
         var result = unitOfWork.Save();

         Assert.True(result > 0);
      }
      }

   [Fact]
   public void Read_ProvideOrderIdShouldReturnOrder()
   {
      var options = new DbContextOptionsBuilder<EFDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

      var sampleOrder = GetSampleOrder();

      using (var context = new EFDbContext(options))
      {
         var unitOfWork = new UnitOfWork(context, new ProductRepository(context), new OrderRepository(context));

         unitOfWork.OrderRepository.Create(sampleOrder);
         unitOfWork.Save();

         var result = unitOfWork.OrderRepository.Read(sampleOrder.Id);

         Assert.Equal(sampleOrder, result);
      }
   }

   [Fact]
   public void ReadByCreationMonth_ProvideMonthShouldReturnOrders()
   {
      var options = new DbContextOptionsBuilder<EFDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

      var sampleOrders = GetSampleOrdersCreatedInJanuary();

      using (var context = new EFDbContext(options))
      {
         var unitOfWork = new UnitOfWork(context, new ProductRepository(context), new OrderRepository(context));

         ClearDatabase(context);
         foreach (var order in sampleOrders)
         {
            unitOfWork.OrderRepository.Create(order);
         }
         unitOfWork.Save();

         var result = unitOfWork.OrderRepository.ReadByCreationMonth(1);

         Assert.Equivalent(sampleOrders, result, strict: true);
      }
   }

   [Fact]
   public void ReadByCreationYear_ProvideYearShouldReturnOrders()
   {
      var options = new DbContextOptionsBuilder<EFDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

      var sampleOrders = GetSampleOrdersCreatedIn2023();

      using (var context = new EFDbContext(options))
      {
         var unitOfWork = new UnitOfWork(context, new ProductRepository(context), new OrderRepository(context));

         ClearDatabase(context);
         foreach (var order in sampleOrders)
         {
            unitOfWork.OrderRepository.Create(order);
         }
         unitOfWork.Save();

         var result = unitOfWork.OrderRepository.ReadByCreationYear(2023);

         Assert.Equivalent(sampleOrders, result, strict: true);
      }
   }


   [Fact]
   public void ReadByProductId_ProvideProductIdShouldReturnOrders()
   {
      var options = new DbContextOptionsBuilder<EFDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

      var sampleOrders = GetSampleOrdersWithProductId13();

      using (var context = new EFDbContext(options))
      {
         var unitOfWork = new UnitOfWork(context, new ProductRepository(context), new OrderRepository(context));

         ClearDatabase(context);
         foreach (var order in sampleOrders)
         {
            unitOfWork.OrderRepository.Create(order);
         }
         unitOfWork.Save();

         var result = unitOfWork.OrderRepository.ReadByProductId(13);

         Assert.Equivalent(sampleOrders, result, strict: true);
      }
   }

   [Fact]
   public void ReadByStatus_ProvideStatusShouldReturnOrders()
   {
      var options = new DbContextOptionsBuilder<EFDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

      var sampleOrders = GetSampleOrdersWithStatusCancelled();

      using (var context = new EFDbContext(options))
      {
         var unitOfWork = new UnitOfWork(context, new ProductRepository(context), new OrderRepository(context));

         ClearDatabase(context);
         foreach (var order in sampleOrders)
         {
            unitOfWork.OrderRepository.Create(order);
         }
         unitOfWork.Save();

         var result = unitOfWork.OrderRepository.ReadByStatus(Status.Cancelled);

         Assert.Equivalent(sampleOrders, result, strict: true);
      }
   }

   private void ClearDatabase(EFDbContext context)
   {
      context.Order.RemoveRange(context.Order);
      context.SaveChanges();
   }

   private Order GetSampleOrder()
   {
      var sampleOrder = new Order();
      sampleOrder.Status = Status.NotStarted;
      sampleOrder.CreateDate = new(2024, 1, 31);
      sampleOrder.UpdateDate = new(2024, 1, 31);
      sampleOrder.ProductId = 10;

      return sampleOrder;
   }

   private List<Order> GetSampleOrders()
   {
      var sampleOrders = new List<Order>();

      var sampleOrder1 = new Order();
      sampleOrder1.Id = 1;
      sampleOrder1.Status = Status.NotStarted;
      sampleOrder1.CreateDate = new(2022, 12, 31);
      sampleOrder1.UpdateDate = new(2022, 12, 31);
      sampleOrder1.ProductId = 10;
      sampleOrders.Add(sampleOrder1);

      var sampleOrder2 = new Order();
      sampleOrder2.Id = 2;
      sampleOrder2.Status = Status.Cancelled;
      sampleOrder2.CreateDate = new(2023, 1, 11);
      sampleOrder2.UpdateDate = new(2023, 1, 11);
      sampleOrder2.ProductId = 11;
      sampleOrders.Add(sampleOrder2);

      var sampleOrder3 = new Order();
      sampleOrder3.Id = 3;
      sampleOrder3.Status = Status.Arrived;
      sampleOrder3.CreateDate = new(2023, 4, 11);
      sampleOrder3.UpdateDate = new(2023, 4, 11);
      sampleOrder3.ProductId = 12;
      sampleOrders.Add(sampleOrder3);

      var sampleOrder4 = new Order();
      sampleOrder4.Id = 4;
      sampleOrder4.Status = Status.Cancelled;
      sampleOrder4.CreateDate = new(2023, 4, 15);
      sampleOrder4.UpdateDate = new(2023, 4, 15);
      sampleOrder4.ProductId = 13;
      sampleOrders.Add(sampleOrder4);

      var sampleOrder5 = new Order();
      sampleOrder5.Id = 5;
      sampleOrder5.Status = Status.InProgress;
      sampleOrder5.CreateDate = new(2024, 1, 05);
      sampleOrder5.UpdateDate = new(2024, 1, 05);
      sampleOrder5.ProductId = 13;
      sampleOrders.Add(sampleOrder5);

      return sampleOrders;
   }

   private List<Order> GetSampleOrdersCreatedInJanuary()
   {
      var sampleOrders = new List<Order>();

      var sampleOrder2 = new Order();
      sampleOrder2.Id = 2;
      sampleOrder2.Status = Status.Cancelled;
      sampleOrder2.CreateDate = new(2023, 1, 11);
      sampleOrder2.UpdateDate = new(2023, 1, 11);
      sampleOrder2.ProductId = 11;
      sampleOrders.Add(sampleOrder2);

      var sampleOrder5 = new Order();
      sampleOrder5.Id = 5;
      sampleOrder5.Status = Status.InProgress;
      sampleOrder5.CreateDate = new(2024, 1, 05);
      sampleOrder5.UpdateDate = new(2024, 1, 05);
      sampleOrder5.ProductId = 13;
      sampleOrders.Add(sampleOrder5);

      return sampleOrders;
   }

   private List<Order> GetSampleOrdersCreatedIn2023()
   {
      var sampleOrders = new List<Order>();

      var sampleOrder2 = new Order();
      sampleOrder2.Id = 2;
      sampleOrder2.Status = Status.Cancelled;
      sampleOrder2.CreateDate = new(2023, 1, 11);
      sampleOrder2.UpdateDate = new(2023, 1, 11);
      sampleOrder2.ProductId = 11;
      sampleOrders.Add(sampleOrder2);

      var sampleOrder3 = new Order();
      sampleOrder3.Id = 3;
      sampleOrder3.Status = Status.Arrived;
      sampleOrder3.CreateDate = new(2023, 4, 11);
      sampleOrder3.UpdateDate = new(2023, 4, 11);
      sampleOrder3.ProductId = 12;
      sampleOrders.Add(sampleOrder3);

      var sampleOrder4 = new Order();
      sampleOrder4.Id = 4;
      sampleOrder4.Status = Status.Cancelled;
      sampleOrder4.CreateDate = new(2023, 4, 15);
      sampleOrder4.UpdateDate = new(2023, 4, 15);
      sampleOrder4.ProductId = 13;
      sampleOrders.Add(sampleOrder4);

      return sampleOrders;
   }

   private List<Order> GetSampleOrdersWithProductId13()
   {
      var sampleOrders = new List<Order>();

      var sampleOrder4 = new Order();
      sampleOrder4.Id = 4;
      sampleOrder4.Status = Status.Cancelled;
      sampleOrder4.CreateDate = new(2023, 4, 15);
      sampleOrder4.UpdateDate = new(2023, 4, 15);
      sampleOrder4.ProductId = 13;
      sampleOrders.Add(sampleOrder4);

      var sampleOrder5 = new Order();
      sampleOrder5.Id = 5;
      sampleOrder5.Status = Status.InProgress;
      sampleOrder5.CreateDate = new(2024, 1, 05);
      sampleOrder5.UpdateDate = new(2024, 1, 05);
      sampleOrder5.ProductId = 13;
      sampleOrders.Add(sampleOrder5);

      return sampleOrders;
   }

   private List<Order> GetSampleOrdersWithStatusCancelled()
   {
      var sampleOrders = new List<Order>();

      var sampleOrder2 = new Order();
      sampleOrder2.Id = 2;
      sampleOrder2.Status = Status.Cancelled;
      sampleOrder2.CreateDate = new(2023, 1, 11);
      sampleOrder2.UpdateDate = new(2023, 1, 11);
      sampleOrder2.ProductId = 11;
      sampleOrders.Add(sampleOrder2);

      var sampleOrder4 = new Order();
      sampleOrder4.Id = 4;
      sampleOrder4.Status = Status.Cancelled;
      sampleOrder4.CreateDate = new(2023, 4, 15);
      sampleOrder4.UpdateDate = new(2023, 4, 15);
      sampleOrder4.ProductId = 13;
      sampleOrders.Add(sampleOrder4);

      return sampleOrders;
   }
}

