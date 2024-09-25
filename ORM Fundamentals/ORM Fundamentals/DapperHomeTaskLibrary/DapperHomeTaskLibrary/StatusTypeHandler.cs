using Dapper;
using Data;
using System.Data;

namespace DapperHomeTaskLibrary;

public class StatusTypeHandler : SqlMapper.TypeHandler<Status>
{
   public override Status Parse(object value)
   {
      return Enum.Parse<Status>(value.ToString());
   }
   public override void SetValue(IDbDataParameter parameter, Status value)
   {
      parameter.Value = value.ToString();
   }
}

