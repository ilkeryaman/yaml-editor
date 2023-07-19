using System.Text.RegularExpressions;

namespace YAMLEditor.ContentEditor.Services.Validator
{
    class IPValidatorFactory : IValidatorFactory
    {
        public bool Validate(string value)
        {
            string ipPattern = @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b";
            return Regex.Match(value, ipPattern).Success;
        }
    }
}
