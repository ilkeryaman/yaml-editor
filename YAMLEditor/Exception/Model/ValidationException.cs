using System;

namespace YAMLEditor.Exception.Model
{
    class ValidationException : ApplicationException
    {
        public ValidationException(string message) : base(message)
        {

        }
    }
}
