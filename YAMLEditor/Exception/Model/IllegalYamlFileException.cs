using System;
using YAMLEditor.Exception.Constants;

namespace YAMLEditor.Exception.Model
{
    class IllegalYamlFileException : FormatException
    {
        public IllegalYamlFileException() : base(ExceptionMessage.IllegalYamlFile)
        {

        }
    }
}
