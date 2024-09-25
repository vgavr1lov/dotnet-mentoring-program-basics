using Data;
using Microsoft.EntityFrameworkCore;

namespace EFHomeTaskLibrary.Tests;

public class ProductRepositoryTests
{

   [Fact]
   public void Create_ProvideProductShouldSaveSuccessfully()
   {
      var options = new DbContextOptionsBuilder<EFDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

      var sampleProduct = GetSampleProduct();

      using (var context = new EFDbContext(options))
      {
         var unitOfWork = new UnitOfWork(context, new ProductRepository(context), new OrderRepository(context));

         unitOfWork.ProductRepository.Create(sampleProduct);
         var result = unitOfWork.Save();

         Assert.Equal(1, result);
         Assert.NotNull(context.Product.FirstOrDefault(p => p.Description == sampleProduct.Description));
      }
   }

   [Fact]
   public void Read_ProvideProductIdShouldReturnProduct()
   {
      var options = new DbContextOptionsBuilder<EFDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

      var sampleProduct = GetSampleProduct();

      using (var context = new EFDbContext(options))
      {
         var unitOfWork = new UnitOfWork(context, new ProductRepository(context), new OrderRepository(context));

         unitOfWork.ProductRepository.Create(sampleProduct);
         unitOfWork.Save();
         var result = unitOfWork.ProductRepository.Read(sampleProduct.Id);

         Assert.Equal(sampleProduct, result);
      }
   }

   [Fact]
   public void Read_ProvideProductDescriptionShouldReturnProductList()
   {
      var options = new DbContextOptionsBuilder<EFDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

      var sampleProduct = GetSampleProduct();

      using (var context = new EFDbContext(options))
      {
         var unitOfWork = new UnitOfWork(context, new ProductRepository(context), new OrderRepository(context));

         unitOfWork.ProductRepository.Create(sampleProduct);
         unitOfWork.Save();
         var result = unitOfWork.ProductRepository.Read(sampleProduct.Description);

         Assert.True(result.Count > 0);
      }
   }

   [Fact]
   public void Read_ShouldReturnProductList()
   {
      var options = new DbContextOptionsBuilder<EFDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

      var sampleProduct = GetSampleProduct();

      using (var context = new EFDbContext(options))
      {
         var unitOfWork = new UnitOfWork(context, new ProductRepository(context), new OrderRepository(context));

         unitOfWork.ProductRepository.Create(sampleProduct);
         unitOfWork.Save();
         var result = unitOfWork.ProductRepository.Read();

         Assert.True(result.Count > 0);
      }
   }

   [Fact]
   public void Update_ProvideProductShouldReturnNumberOfRowsUpdated()
   {
      var options = new DbContextOptionsBuilder<EFDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

      var sampleProduct = GetSampleProduct();

      using (var context = new EFDbContext(options))
      {
         var unitOfWork = new UnitOfWork(context, new ProductRepository(context), new OrderRepository(context));

         unitOfWork.ProductRepository.Create(sampleProduct);
         unitOfWork.Save();
         unitOfWork.ProductRepository.Update(sampleProduct);
         var result = unitOfWork.Save();

         Assert.Equal(1, result);
      }
   }

   [Fact]
   public void Delete_ProvideProductIdShouldReturnNumberOfRowsDeleted()
   {
      var options = new DbContextOptionsBuilder<EFDbContext>()
          .UseInMemoryDatabase(databaseName: "TestDatabase")
          .Options;

      var sampleProduct = GetSampleProduct();

      using (var context = new EFDbContext(options))
      {
         var unitOfWork = new UnitOfWork(context, new ProductRepository(context), new OrderRepository(context));

         unitOfWork.ProductRepository.Create(sampleProduct);
         unitOfWork.Save();
         unitOfWork.ProductRepository.Delete(sampleProduct.Id);
         var result = unitOfWork.Save();

         Assert.Equal(1, result);
      }
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
}
