
using System.Data;

namespace DBHandlerLibrary
{
   public interface IOrderRepository
   {
      int Create(IOrder order);
      int Delete(int orderId);
      int DeleteByProductId(int productId);
      IOrder Read(int orderId);
      DataSetOrder Read();
      DataTable? ReadAsDataTable();
      int DeleteBulk(DataSetOrder dataSet);
      int Update(IOrder order);
   }
}