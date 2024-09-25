using Data;
using Moq;
using System.Data;

namespace DapperHomeTaskLibrary.Tests;

public class ProductServiceTests
{
   [Fact]
   public void Create_ProvideProductShouldExecuteSuccessfully()
   {
      var sampleProduct = GetSampleProduct();
      var repositoryMock = new Mock<IProductRepository>();
      var mockConnection = new Mock<IDbConnectionFactory>();
      repositoryMock.Setup(x => x.Create(sampleProduct));
      var unitOfWork = new UnitOfWork(repositoryMock.Object, new Mock<IOrderRepository>().Object);

      unitOfWork.ProductRepository.Create(sampleProduct);

      repositoryMock.Verify(x => x.Create(sampleProduct), Times.Once);
   }

   [Fact]
   public void Read_ProvideProductIdShouldReturnProduct()
   {
      var sampleProduct = GetSampleProduct();
      var repositoryMock = new Mock<IProductRepository>();
      var mockConnection = new Mock<IDbConnectionFactory>();

      repositoryMock.Setup(x => x.Read(sampleProduct.Id)).Returns(sampleProduct);
      var unitOfWork = new UnitOfWork(repositoryMock.Object, new Mock<IOrderRepository>().Object);

      var result = unitOfWork.ProductRepository.Read(sampleProduct.Id);

      Assert.Equal(sampleProduct, result);
   }

   [Fact]
   public void Read_ProvideProductDescriptionShouldReturnProductList()
   {
      var sampleProduct = GetSampleProduct();
      var sampleProducts = GetSampleProducts();
      var repositoryMock = new Mock<IProductRepository>();
      var mockConnection = new Mock<IDbConnectionFactory>();

      repositoryMock.Setup(x => x.Read(sampleProduct.Description)).Returns(sampleProducts);
      var unitOfWork = new UnitOfWork(repositoryMock.Object, new Mock<IOrderRepository>().Object);

      var result = unitOfWork.ProductRepository.Read(sampleProduct.Description);

      Assert.Equal(sampleProducts, result);
   }

   [Fact]
   public void Read_ShouldReturnProductList()
   {
      var sampleProducts = GetSampleProducts();
      var repositoryMock = new Mock<IProductRepository>();
      var mockConnection = new Mock<IDbConnectionFactory>();
      repositoryMock.Setup(x => x.Read()).Returns(sampleProducts);
      var unitOfWork = new UnitOfWork(repositoryMock.Object, new Mock<IOrderRepository>().Object);

      var result = unitOfWork.ProductRepository.Read();

      Assert.Equal(sampleProducts, result);
   }

   [Fact]
   public void Update_ProvideProductExecuteSuccessfully()
   {
      var sampleProduct = GetSampleProduct();
      var repositoryMock = new Mock<IProductRepository>();
      var mockConnection = new Mock<IDbConnectionFactory>();
      repositoryMock.Setup(x => x.Update(sampleProduct));
      var unitOfWork = new UnitOfWork(repositoryMock.Object, new Mock<IOrderRepository>().Object);

      unitOfWork.ProductRepository.Update(sampleProduct);

      repositoryMock.Verify(x => x.Update(sampleProduct), Times.Once);
   }

   [Fact]
   public void Delete_ProvideProductIdExecuteSuccessfully()
   {
      var sampleProduct = GetSampleProduct();
      var repositoryMock = new Mock<IProductRepository>();
      var mockConnection = new Mock<IDbConnectionFactory>();
      repositoryMock.Setup(x => x.Delete(sampleProduct.Id));
      var unitOfWork = new UnitOfWork(repositoryMock.Object, new Mock<IOrderRepository>().Object);

      unitOfWork.ProductRepository.Delete(sampleProduct.Id);

      repositoryMock.Verify(x => x.Delete(sampleProduct.Id), Times.Once);
   }

   private Product GetSampleProduct()
   {
      var sampleProduct = new Product();
      sampleProduct.Description = $"Sample Product";
      sampleProduct.Length = 10;
      sampleProduct.Height = 1.5M;
      sampleProduct.Weight = 0.8M;
      sampleProduct.Width = 1.2M;

      return sampleProduct;
   }

   private List<Product> GetSampleProducts()
   {
      List<Product> sampleProducts = new List<Product>();

      var sampleProduct1 = new Product();
      sampleProduct1.Description = $"Sample Product 1";
      sampleProduct1.Length = 10;
      sampleProduct1.Height = 1.5M;
      sampleProduct1.Weight = 0.8M;
      sampleProduct1.Width = 1.2M;
      sampleProducts.Add(sampleProduct1);

      var sampleProduct2 = new Product();
      sampleProduct2.Description = $"Sample Product 2";
      sampleProduct2.Length = 11;
      sampleProduct2.Height = 1.8M;
      sampleProduct2.Weight = 0.9M;
      sampleProduct2.Width = 1.3M;
      sampleProducts.Add(sampleProduct2);


      return sampleProducts;
   }
}