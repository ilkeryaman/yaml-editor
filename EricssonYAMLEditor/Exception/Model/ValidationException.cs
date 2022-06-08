using System;

namespace EricssonYAMLEditor.Exception.Model
{
    class ValidationException : ApplicationException
    {
        public ValidationException(string message) : base(message)
        {

        }
    }
}
