using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Exceptions
{
    public class InvalidUserIdException : UserTaskException
   {
        private const string DefaultMessage = "Invalid userId";
        private readonly string _customMessage;
        public override string Message => _customMessage;
        public InvalidUserIdException()
        {
            _customMessage = DefaultMessage;
        }

        public InvalidUserIdException(string message)
            : base(message)
        {
            _customMessage = message;
        }

        public InvalidUserIdException(string message, Exception inner)
            : base(message, inner)
        {
            _customMessage = message;
        }
    }
}
