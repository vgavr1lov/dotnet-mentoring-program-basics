using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Exceptions
{
    public class UserNotFoundException : UserTaskException
   {
        private const string DefaultMessage = "User not found";
        private readonly string _customMessage;
        public override string Message => _customMessage;
        public UserNotFoundException()
        {
            _customMessage = DefaultMessage;
        }

        public UserNotFoundException(string message)
            : base(message)
        {
            _customMessage = DefaultMessage;
        }

        public UserNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
            _customMessage = DefaultMessage;
        }
    }
}
