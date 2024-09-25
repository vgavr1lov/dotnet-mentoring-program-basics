using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Exceptions
{
   public abstract class UserTaskException: Exception
   {
      public UserTaskException()
      {
      }

      public UserTaskException(string message)
      {
      }

      public UserTaskException(string message, Exception inner)
      {
      }
   }
}
