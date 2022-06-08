
namespace EricssonYAMLEditor.ContentEditor.Services.Validator
{
    class WhiteSpaceValidatorFactory : IValidatorFactory
    {
        public bool Validate(string value)
        {
            string space = " ";
            return !(value.StartsWith(space) || value.EndsWith(space));
        }
    }
}
