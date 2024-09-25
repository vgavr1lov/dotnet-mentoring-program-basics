using Moq;
using System.Data;

namespace DBHandlerLibrary.Tests
{
   public class OrderServiceTests
   {
      [Fact]
      public void CreateOrder_ProvideOrderShouldReturnNewOrderId()
      {
         // Arrange
         var repositoryMock = new Mock<IOrderRepository>();
         var sampleOrder = GetSampleOrder();
         repositoryMock.Setup(x => x.Create(sampleOrder)).Returns(1);

         var orderService = new OrderService(repositoryMock.Object);

         // Act
         var result = orderService.CreateOrder(sampleOrder);

         // Assert
         Assert.Equal(1, result);
         repositoryMock.Verify(x => x.Create(sampleOrder), Times.Once);
      }

      [Fact]
      public void UpdateOrder_ProvideOrderShouldReturnNumberOfRowsUpdated()
      {
         // Arrange
         var repositoryMock = new Mock<IOrderRepository>();
         var sampleOrder = GetSampleOrder();
         repositoryMock.Setup(x => x.Update(sampleOrder)).Returns(1);

         var orderService = new OrderService(repositoryMock.Object);

         // Act
         var result = orderService.UpdateOrder(sampleOrder);

         // Assert
         Assert.Equal(1, result);
         repositoryMock.Verify(x => x.Update(sampleOrder), Times.Once);
      }

      [Fact]
      public void DeleteOrder_ProvideOrderIdShouldReturnNumberOfRowsDeleted()
      {
         // Arrange
         var repositoryMock = new Mock<IOrderRepository>();
         repositoryMock.Setup(x => x.Delete(1)).Returns(1);

         var orderService = new OrderService(repositoryMock.Object);

         // Act
         var result = orderService.DeleteOrder(1);

         // Assert
         Assert.Equal(1, result);
         repositoryMock.Verify(x => x.Delete(1), Times.Once);
      }

      [Fact]
      public void DeleteOrderByProductId_ProvideProductIdShouldReturnNumberOfRowsDeleted()
      {
         // Arrange
         var repositoryMock = new Mock<IOrderRepository>();
         repositoryMock.Setup(x => x.DeleteByProductId(11)).Returns(1);

         var orderService = new OrderService(repositoryMock.Object);

         // Act
         var result = orderService.DeleteOrderByProductId(11);

         // Assert
         Assert.Equal(1, result);
         repositoryMock.Verify(x => x.DeleteByProductId(11), Times.Once);
      }

      [Fact]
      public void DeleteOrderByCreationMonth_ProvideMonthShouldReturnNumberOfRowsDeleted()
      {
         // Arrange
         var dataSet = CreateOrderDataSet(GetSampleOrders());
         var repositoryMock = new Mock<IOrderRepository>();
         repositoryMock.Setup(x => x.Read()).Returns(dataSet);
         repositoryMock.Setup(x => x.DeleteBulk(It.IsAny<DataSetOrder>())).Returns((DataSetOrder ds) => ds.Order.Count(r => r.RowState == DataRowState.Deleted));

         var orderService = new OrderService(repositoryMock.Object);

         // Act
         var result = orderService.DeleteOrderByCreationMonth(1);

         // Assert
         Assert.Equal(2, result);
         repositoryMock.Verify(r => r.Read(), Times.Once);
         repositoryMock.Verify(r => r.DeleteBulk(It.IsAny<DataSetOrder>()), Times.Once);
      }

      [Fact]
      public void DeleteOrderByCreationYear_ProvideYearShouldReturnNumberOfRowsDeleted()
      {
         // Arrange
         var dataSet = CreateOrderDataSet(GetSampleOrders());
         var repositoryMock = new Mock<IOrderRepository>();
         repositoryMock.Setup(x => x.Read()).Returns(dataSet);
         repositoryMock.Setup(x => x.DeleteBulk(It.IsAny<DataSetOrder>())).Returns((DataSetOrder ds) => ds.Order.Count(r => r.RowState == DataRowState.Deleted));

         var orderService = new OrderService(repositoryMock.Object);

         // Act
         var result = orderService.DeleteOrderByCreationYear(2023);

         // Assert
         Assert.Equal(3, result);
         repositoryMock.Verify(r => r.Read(), Times.Once);
         repositoryMock.Verify(r => r.DeleteBulk(It.IsAny<DataSetOrder>()), Times.Once);
      }

      [Fact]
      public void DeleteOrderByStatus_ProvideStatusShouldReturnNumberOfRowsDeleted()
      {
         // Arrange
         var dataSet = CreateOrderDataSet(GetSampleOrders());
         var repositoryMock = new Mock<IOrderRepository>();
         repositoryMock.Setup(x => x.Read()).Returns(dataSet);
         repositoryMock.Setup(x => x.DeleteBulk(It.IsAny<DataSetOrder>())).Returns((DataSetOrder ds) => ds.Order.Count(r => r.RowState == DataRowState.Deleted));

         var orderService = new OrderService(repositoryMock.Object);

         // Act
         var result = orderService.DeleteOrderByStatus(Status.Cancelled);

         // Assert
         Assert.Equal(2, result);
         repositoryMock.Verify(r => r.Read(), Times.Once);
         repositoryMock.Verify(r => r.DeleteBulk(It.IsAny<DataSetOrder>()), Times.Once);
      }

      [Fact]
      public void ReadOrder_ProvideOrderIdShouldReturnOrder()
      {
         // Arrange
         var repositoryMock = new Mock<IOrderRepository>();
         var sampleOrder = GetSampleOrder();
         repositoryMock.Setup(x => x.Read(1)).Returns(sampleOrder);

         var orderService = new OrderService(repositoryMock.Object);

         // Act
         var result = orderService.ReadOrder(1);

         // Assert
         Assert.Equal(sampleOrder, result);
         repositoryMock.Verify(x => x.Read(1), Times.Once);
      }

      [Fact]
      public void ReadOrderByCreationMonth_ProvideMonthShouldReturnOrders()
      {
         // Arrange
         var dataSet = CreateOrderDataSet(GetSampleOrders());
         var repositoryMock = new Mock<IOrderRepository>();
         repositoryMock.Setup(x => x.Read()).Returns(dataSet);

         var orderService = new OrderService(repositoryMock.Object);
         var expectedResult = GetSampleOrders().Where(o => o.CreateDate.Month == 1).ToList();   

         // Act
         var result = orderService.ReadOrderByCreationMonth(1);

         // Assert
         Assert.Equivalent(expectedResult, result, strict: true);
         repositoryMock.Verify(x => x.Read(), Times.Once);
      }

      [Fact]
      public void ReadOrderByCreationYear_ProvideYearShouldReturnOrders()
      {
         // Arrange
         var dataSet = CreateOrderDataSet(GetSampleOrders());
         var repositoryMock = new Mock<IOrderRepository>();
         repositoryMock.Setup(x => x.Read()).Returns(dataSet);

         var orderService = new OrderService(repositoryMock.Object);
         var expectedResult = GetSampleOrders().Where(o => o.CreateDate.Year == 2023).ToList();

         // Act
         var result = orderService.ReadOrderByCreationYear(2023);

         // Assert
         Assert.Equivalent(expectedResult, result, strict: true);
         repositoryMock.Verify(x => x.Read(), Times.Once);
      }


      [Fact]
      public void ReadOrderByProduct_ProvideProductIdShouldReturnOrders()
      {
         // Arrange
         var dataSetTable = CreateOrderDataSetTable(GetSampleOrders());
         var repositoryMock = new Mock<IOrderRepository>();
         repositoryMock.Setup(x => x.ReadAsDataTable()).Returns(dataSetTable);

         var orderService = new OrderService(repositoryMock.Object);
         var expectedResult = GetSampleOrders().Where(o => o.ProductId == 13).ToList();

         // Act
         var result = orderService.ReadOrderByProduct(13);

         // Assert
         Assert.Equivalent(expectedResult, result, strict: true);
         repositoryMock.Verify(x => x.ReadAsDataTable(), Times.Once);
      }

      [Fact]
      public void ReadOrderByStatus_ProvideStatusShouldReturnOrders()
      {
         // Arrange
         var dataSet = CreateOrderDataSet(GetSampleOrders());
         var repositoryMock = new Mock<IOrderRepository>();
         repositoryMock.Setup(x => x.Read()).Returns(dataSet);

         var orderService = new OrderService(repositoryMock.Object);
         var expectedResult = GetSampleOrders().Where(o => o.Status == Status.Cancelled).ToList();

         // Act
         var result = orderService.ReadOrderByStatus(Status.Cancelled);

         // Assert
         Assert.Equivalent(expectedResult, result, strict: true);
         repositoryMock.Verify(x => x.Read(), Times.Once);
      }

      private DataSetOrder CreateOrderDataSet(List<Order> orders)
      {
         var dataSet = new DataSetOrder();
         var orderTable = dataSet.Order;
         orders.ForEach(o => dataSet.Order.Rows.Add(o.Id,
                                                    o.Status.ToString(),
                                                    o.CreateDate.ToDateTime(TimeOnly.MinValue),
                                                    o.UpdateDate.ToDateTime(TimeOnly.MinValue),
                                                    o.ProductId));
         dataSet.AcceptChanges();

         return dataSet;
      }

      private DataTable CreateOrderDataSetTable(List<Order> orders)
      {
         var dataSet = new DataSetOrder();
         var orderTable = dataSet.Order;
         orders.ForEach(o => dataSet.Order.Rows.Add(o.Id,
                                                    o.Status.ToString(),
                                                    o.CreateDate.ToDateTime(TimeOnly.MinValue),
                                                    o.UpdateDate.ToDateTime(TimeOnly.MinValue),
                                                    o.ProductId));
         dataSet.AcceptChanges();

         return dataSet.Order;
      }

      private IOrder GetSampleOrder()
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
   }
}
