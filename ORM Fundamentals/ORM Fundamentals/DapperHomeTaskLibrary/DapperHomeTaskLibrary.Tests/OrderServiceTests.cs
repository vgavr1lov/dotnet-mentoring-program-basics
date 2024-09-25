using Data;
using Moq;
using System.Data;

namespace DapperHomeTaskLibrary.Tests;

public class OrderServiceTests
{
   [Fact]
   public void Create_ProvideOrderExecuteSuccessfully()
   {
      var sampleOrder = GetSampleOrder();
      var repositoryMock = new Mock<IOrderRepository>();
      var mockConnection = new Mock<IDbConnectionFactory>();
      repositoryMock.Setup(x => x.Create(sampleOrder));
      var unitOfWork = new UnitOfWork(new Mock<IProductRepository>().Object, repositoryMock.Object);

      unitOfWork.OrderRepository.Create(sampleOrder);

      repositoryMock.Verify(x => x.Create(sampleOrder), Times.Once);
   }

   [Fact]
   public void Update_ProvideOrderExecuteSuccessfully()
   {
      var sampleOrder = GetSampleOrder();
      var repositoryMock = new Mock<IOrderRepository>();
      var mockConnection = new Mock<IDbConnectionFactory>();
      repositoryMock.Setup(x => x.Update(sampleOrder));
      var unitOfWork = new UnitOfWork(new Mock<IProductRepository>().Object, repositoryMock.Object);

      unitOfWork.OrderRepository.Update(sampleOrder);

      repositoryMock.Verify(x => x.Update(sampleOrder), Times.Once);
   }

   [Fact]
   public void DeleteOrder_ProvideOrderIdShouldExecuteSuccessfully()
   {
      var sampleOrder = GetSampleOrder();
      var repositoryMock = new Mock<IOrderRepository>();
      var mockConnection = new Mock<IDbConnectionFactory>();
      repositoryMock.Setup(x => x.Delete(sampleOrder.Id));
      var unitOfWork = new UnitOfWork(new Mock<IProductRepository>().Object, repositoryMock.Object);

      unitOfWork.OrderRepository.Delete(sampleOrder.Id);

      repositoryMock.Verify(x => x.Delete(sampleOrder.Id), Times.Once);
   }

   [Fact]
   public void DeleteByProductId_ProvideProductIdShouldExecuteSuccessfully()
   {
      var sampleOrder = GetSampleOrder();
      var repositoryMock = new Mock<IOrderRepository>();
      var mockConnection = new Mock<IDbConnectionFactory>();
      repositoryMock.Setup(x => x.DeleteByProductId(sampleOrder.ProductId));
      var unitOfWork = new UnitOfWork(new Mock<IProductRepository>().Object, repositoryMock.Object);

      unitOfWork.OrderRepository.DeleteByProductId(sampleOrder.ProductId);

      repositoryMock.Verify(x => x.DeleteByProductId(sampleOrder.ProductId), Times.Once);
   }

   [Fact]
   public void DeleteByCreationMonth_ProvideMonthShouldExecuteSuccessfully()
   {
      var sampleOrder = GetSampleOrder();
      var repositoryMock = new Mock<IOrderRepository>();
      var mockConnection = new Mock<IDbConnectionFactory>();
      repositoryMock.Setup(x => x.DeleteByCreationMonth(sampleOrder.CreateDate.Month));
      var unitOfWork = new UnitOfWork(new Mock<IProductRepository>().Object, repositoryMock.Object);

      unitOfWork.OrderRepository.DeleteByCreationMonth(sampleOrder.CreateDate.Month);

      repositoryMock.Verify(x => x.DeleteByCreationMonth(sampleOrder.CreateDate.Month), Times.Once);
   }

   [Fact]
   public void DeleteByCreationYear_ProvideYearShouldExecuteSuccessfully()
   {
      var sampleOrder = GetSampleOrder();
      var repositoryMock = new Mock<IOrderRepository>();
      var mockConnection = new Mock<IDbConnectionFactory>();
      repositoryMock.Setup(x => x.DeleteByCreationYear(sampleOrder.CreateDate.Year));
      var unitOfWork = new UnitOfWork(new Mock<IProductRepository>().Object, repositoryMock.Object);

      unitOfWork.OrderRepository.DeleteByCreationYear(sampleOrder.CreateDate.Year);

      repositoryMock.Verify(x => x.DeleteByCreationYear(sampleOrder.CreateDate.Year), Times.Once);
   }

   [Fact]
   public void DeleteByStatus_ProvideStatusShouldExecuteSuccessfully()
   {
      var sampleOrder = GetSampleOrder();
      var repositoryMock = new Mock<IOrderRepository>();
      var mockConnection = new Mock<IDbConnectionFactory>();
      repositoryMock.Setup(x => x.DeleteByStatus(sampleOrder.Status));
      var unitOfWork = new UnitOfWork(new Mock<IProductRepository>().Object, repositoryMock.Object);

      unitOfWork.OrderRepository.DeleteByStatus(sampleOrder.Status);

      repositoryMock.Verify(x => x.DeleteByStatus(sampleOrder.Status), Times.Once);
   }

   [Fact]
   public void Read_ProvideOrderIdShouldReturnOrder()
   {
      var sampleOrder = GetSampleOrder();
      var repositoryMock = new Mock<IOrderRepository>();
      var mockConnection = new Mock<IDbConnectionFactory>();
      repositoryMock.Setup(x => x.Read(sampleOrder.Id)).Returns(sampleOrder);
      var unitOfWork = new UnitOfWork(new Mock<IProductRepository>().Object, repositoryMock.Object);

      var result = unitOfWork.OrderRepository.Read(sampleOrder.Id);

      Assert.Equal(sampleOrder, result);
   }

   [Fact]
   public void ReadByCreationMonth_ProvideMonthShouldReturnOrders()
   {
      var sampleOrders = GetSampleOrdersCreatedInJanuary();
      var repositoryMock = new Mock<IOrderRepository>();
      var mockConnection = new Mock<IDbConnectionFactory>();
      repositoryMock.Setup(x => x.ReadByCreationMonth(1)).Returns(sampleOrders);
      var unitOfWork = new UnitOfWork(new Mock<IProductRepository>().Object, repositoryMock.Object);

      var result = unitOfWork.OrderRepository.ReadByCreationMonth(1);

      Assert.Equal(sampleOrders, result);
   }

   [Fact]
   public void ReadByCreationYear_ProvideYearShouldReturnOrders()
   {
      var sampleOrders = GetSampleOrdersCreatedIn2023();
      var repositoryMock = new Mock<IOrderRepository>();
      var mockConnection = new Mock<IDbConnectionFactory>();
      repositoryMock.Setup(x => x.ReadByCreationYear(2023)).Returns(sampleOrders);
      var unitOfWork = new UnitOfWork(new Mock<IProductRepository>().Object, repositoryMock.Object);

      var result = unitOfWork.OrderRepository.ReadByCreationYear(2023);

      Assert.Equal(sampleOrders, result);
   }


   [Fact]
   public void ReadByProductId_ProvideProductIdShouldReturnOrders()
   {
      var sampleOrders = GetSampleOrdersWithProductId13();
      var repositoryMock = new Mock<IOrderRepository>();
      var mockConnection = new Mock<IDbConnectionFactory>();
      repositoryMock.Setup(x => x.ReadByProductId(13)).Returns(sampleOrders);
      var unitOfWork = new UnitOfWork(new Mock<IProductRepository>().Object, repositoryMock.Object);

      var result = unitOfWork.OrderRepository.ReadByProductId(13);

      Assert.Equal(sampleOrders, result);
   }

   [Fact]
   public void ReadByStatus_ProvideStatusShouldReturnOrders()
   {
      var sampleOrders = GetSampleOrdersWithStatusCancelled();
      var repositoryMock = new Mock<IOrderRepository>();
      var mockConnection = new Mock<IDbConnectionFactory>();
      repositoryMock.Setup(x => x.ReadByStatus(Status.Cancelled)).Returns(sampleOrders);
      var unitOfWork = new UnitOfWork(new Mock<IProductRepository>().Object, repositoryMock.Object);

      var result = unitOfWork.OrderRepository.ReadByStatus(Status.Cancelled);

      Assert.Equal(sampleOrders, result);
   }

   private Order GetSampleOrder()
   {
      var sampleOrder = new Order();
      sampleOrder.Id = 1;
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

