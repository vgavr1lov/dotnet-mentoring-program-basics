using Autofac.Extras.Moq;
using Moq;

namespace DBHandlerLibrary.Tests
{
   public class ProductServiceTests
   {
      [Fact]
      public void CreateProduct_ProvideProductShouldReturnNewId()
      {
         // Arrange
         var repositoryMock = new Mock<IProductRepository>();
         var sampleProduct = GetSampleProduct();
         repositoryMock.Setup(x => x.Create(sampleProduct)).Returns(1);

         var productService = new ProductService(repositoryMock.Object);

         // Act
         var result = productService.CreateProduct(sampleProduct);

         // Assert
         Assert.Equal(1, result);
         repositoryMock.Verify(x => x.Create(sampleProduct), Times.Once);
      }

      [Fact]
      public void ReadProduct_ProvideProductIdShouldReturnProduct()
      {
         // Arrange
         var repositoryMock = new Mock<IProductRepository>();
         var sampleProduct = GetSampleProduct();
         repositoryMock.Setup(x => x.Read(1)).Returns(sampleProduct);

         var productService = new ProductService(repositoryMock.Object);

         // Act
         var result = productService.ReadProduct(1);

         // Assert
         Assert.Equal(sampleProduct, result);
         repositoryMock.Verify(x => x.Read(1), Times.Once);
      }

      [Fact]
      public void ReadProduct_ProvideProductDescriptionShouldReturnProductList()
      {
         // Arrange
         var repositoryMock = new Mock<IProductRepository>();
         var sampleProducts = GetSampleProducts();
         repositoryMock.Setup(x => x.Read("Sample")).Returns(sampleProducts);

         var productService = new ProductService(repositoryMock.Object);

         // Act
         var result = productService.ReadProduct("Sample");

         // Assert
         Assert.Equal(sampleProducts, result);
         repositoryMock.Verify(x => x.Read("Sample"), Times.Once);
      }

      [Fact]
      public void ReadProduct_ShouldReturnProductList()
      {
         // Arrange
         var repositoryMock = new Mock<IProductRepository>();
         var sampleProducts = GetSampleProducts();
         repositoryMock.Setup(x => x.Read()).Returns(sampleProducts);

         var productService = new ProductService(repositoryMock.Object);

         // Act
         var result = productService.ReadProduct();

         // Assert
         Assert.Equal(sampleProducts, result);
         repositoryMock.Verify(x => x.Read(), Times.Once);
      }

      [Fact]
      public void UpdateProduct_ProvideProductShouldReturnNumberOfRowsUpdated()
      {
         // Arrange
         var repositoryMock = new Mock<IProductRepository>();
         var sampleProduct = GetSampleProduct();
         repositoryMock.Setup(x => x.Update(sampleProduct)).Returns(1);

         var productService = new ProductService(repositoryMock.Object);

         // Act
         var result = productService.UpdateProduct(sampleProduct);

         // Assert
         Assert.Equal(1, result);
         repositoryMock.Verify(x => x.Update(sampleProduct), Times.Once);
      }

      [Fact]
      public void DeleteProduct_ProvideProductIdShouldReturnNumberOfRowsDeleted()
      {
         // Arrange
         var repositoryMock = new Mock<IProductRepository>();
         repositoryMock.Setup(x => x.Delete(1)).Returns(1);

         var productService = new ProductService(repositoryMock.Object);

         // Act
         var result = productService.DeleteProduct(1);

         // Assert
         Assert.Equal(1, result);
         repositoryMock.Verify(x => x.Delete(1), Times.Once);
      }

      private IProduct GetSampleProduct()
      {
         var sampleProduct = new Product();
         sampleProduct.Description = $"Sample Product";
         sampleProduct.Length = 10;
         sampleProduct.Height = 1.5M;
         sampleProduct.Weight = 0.8M;
         sampleProduct.Width = 1.2M;

         return sampleProduct;
      }

      private List<IProduct> GetSampleProducts()
      {
         var sampleProducts = new List<IProduct>();

         var sampleProduct = new Product();
         sampleProduct.Id = 1;
         sampleProduct.Description = $"Sample Product 1";
         sampleProduct.Length = 10;
         sampleProduct.Height = 1.5M;
         sampleProduct.Weight = 0.8M;
         sampleProduct.Width = 1.2M;
         sampleProducts.Add(sampleProduct);

         var sampleProduct2 = new Product();
         sampleProduct2.Id = 2;
         sampleProduct2.Description = $"Sample Product 2";
         sampleProduct2.Length = 3;
         sampleProduct2.Height = 0.5M;
         sampleProduct2.Weight = 0.3M;
         sampleProduct2.Width = 0.2M;
         sampleProducts.Add(sampleProduct2);

         var sampleProduct3 = new Product();
         sampleProduct3.Id = 3;
         sampleProduct3.Description = $"Sample Product 3";
         sampleProduct3.Length = 1;
         sampleProduct3.Height = 0.5M;
         sampleProduct.Weight = 0.8M;
         sampleProduct3.Width = 1M;
         sampleProducts.Add(sampleProduct3);

         return sampleProducts;
      }
   }
}