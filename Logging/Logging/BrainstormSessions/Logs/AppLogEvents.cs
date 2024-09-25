using Microsoft.Extensions.Logging;

namespace BrainstormSessions.Logs
{
   public static class AppLogEvents
   {
      public static readonly EventId Create = new EventId(1000, "Created");
      public static readonly EventId Read = new EventId(1001, "Read");
      public static readonly EventId Update = new EventId(1002, "Updated");
      public static readonly EventId Delete = new EventId(1003, "Deleted");
   }
}
