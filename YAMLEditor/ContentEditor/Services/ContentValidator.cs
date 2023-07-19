using YAMLEditor.ContentEditor.Services.Interfaces;
using YAMLEditor.ContentEditor.Services.Validator;
using YAMLEditor.Node.Constants;

namespace YAMLEditor.ContentEditor.Services
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
