using Microsoft.EntityFrameworkCore;
using MvcHomeTaskLibrary.Models;

namespace MvcHomeTaskLibrary
{
    public class ProductRepository : GenericRepository<Product>
    {
        private readonly int _maxNumberOdProducts;
        public ProductRepository(NorthwindDbContext context, int maxNumberOdProducts) : base(context)
        {
            _maxNumberOdProducts = maxNumberOdProducts;
        }

        public List<ProductWithCategoryNameAndSupplierName> GetProductsWithCategoryNameAndSupplierName()
        {
            if (_maxNumberOdProducts == 0)
                return GetAll();

            var products = DbContext.Products
                .Take(_maxNumberOdProducts)
                .Select(p => new ProductWithCategoryNameAndSupplierName
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    SupplierId = p.SupplierId,
                    SupplierName = p.Supplier.CompanyName,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.CategoryName,
                    QuantityPerUnit = p.QuantityPerUnit,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock,
                    UnitsOnOrder = p.UnitsOnOrder,
                    ReorderLevel = p.ReorderLevel,
                    Discontinued = p.Discontinued
                })
                .ToList();
            return products;
        }

        public List<ProductWithCategoryNameAndSupplierName> GetAll()
        {
            var products = DbContext.Products
                .Select(p => new ProductWithCategoryNameAndSupplierName
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    SupplierId = p.SupplierId,
                    SupplierName = p.Supplier.CompanyName,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.CategoryName,
                    QuantityPerUnit = p.QuantityPerUnit,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock,
                    UnitsOnOrder = p.UnitsOnOrder,
                    ReorderLevel = p.ReorderLevel,
                    Discontinued = p.Discontinued
                })
                .ToList();
            return products;
        }

        public ProductForUpdate GetProductForUpdate(int productId)
        {
            var product = DbContext.Products.Find(productId);

            return new ProductForUpdate
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SupplierId = product.SupplierId,
                CategoryId = product.CategoryId,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                ReorderLevel = product.ReorderLevel,
                Discontinued = ((Discontinued)Convert.ToInt32(product.Discontinued)).ToString(),
                Suppliers = DbContext.Suppliers.ToList(),
                Categories = DbContext.Categories.ToList(),
            };
        }
    }
}
