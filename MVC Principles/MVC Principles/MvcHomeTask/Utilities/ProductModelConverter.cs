using MvcHomeTaskLibrary.Models;
using MvcHomeTaskLibrary;

namespace MvcHomeTask
{
    public static class ProductModelConverter
    {
        public static Product ConvertProductForUpdateIntoProduct(ProductForUpdate productForUpdate)
        {
            return new Product
            {
                ProductId = productForUpdate.ProductId,
                ProductName = productForUpdate.ProductName,
                SupplierId = productForUpdate.SupplierId,
                CategoryId = productForUpdate.CategoryId,
                QuantityPerUnit = productForUpdate.QuantityPerUnit,
                UnitPrice = productForUpdate.UnitPrice,
                UnitsInStock = productForUpdate.UnitsInStock,
                UnitsOnOrder = productForUpdate.UnitsOnOrder,
                ReorderLevel = productForUpdate.ReorderLevel,
                Discontinued = (Discontinued)Enum.Parse(typeof(Discontinued), productForUpdate.Discontinued!) == Discontinued.Yes,
            };
        }
    }
}
