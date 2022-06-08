using EricssonYAMLEditor.ContentEditor.Services.Interfaces;
using EricssonYAMLEditor.ContentEditor.Services.Validator;
using EricssonYAMLEditor.Node.Constants;

namespace EricssonYAMLEditor.ContentEditor.Services
{
    class ContentValidator : IContentValidator
    {
        public bool ValidateContent(string key, string value)
        {
            IValidatorFactory validatorFactory;

            if (key.EndsWith(PropertyKey.LeafName.gateway_ipv4))
            {
                validatorFactory = new IPValidatorFactory();
            }
            else
            {
                validatorFactory = new WhiteSpaceValidatorFactory();   
            }

            return validatorFactory.Validate(value);
        }
    }
}
