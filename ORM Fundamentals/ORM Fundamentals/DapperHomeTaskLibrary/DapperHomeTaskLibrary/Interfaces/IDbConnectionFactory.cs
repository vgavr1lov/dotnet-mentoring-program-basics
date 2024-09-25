using System.Data;

namespace DapperHomeTaskLibrary
{
   public interface IDbConnectionFactory
   {
      IDbConnection Create();
   }
}