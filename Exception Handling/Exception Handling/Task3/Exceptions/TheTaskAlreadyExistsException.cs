using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Exceptions
{
    public class TheTaskAlreadyExistsException : UserTaskException
   {
        private const string DefaultMessage = "The task already exists";
        private readonly string _customMessage;
        public override string Message => _customMessage;
        public TheTaskAlreadyExistsException()
        {
            _customMessage = DefaultMessage;
        }

        public TheTaskAlreadyExistsException(string message)
            : base(message)
        {
            _customMessage = message;
        }

        public TheTaskAlreadyExistsException(string message, Exception inner)
            : base(message, inner)
        {
            _customMessage = message;
        }
    }
}
