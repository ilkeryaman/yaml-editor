using System;
using EricssonYAMLEditor.Exception.Constants;

namespace EricssonYAMLEditor.Exception.Model
{
    class IllegalYamlFileException : FormatException
    {
        public IllegalYamlFileException() : base(ExceptionMessage.IllegalYamlFile)
        {

        }
    }
}
