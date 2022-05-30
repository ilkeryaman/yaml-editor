namespace EricssonYAMLEditor.Parser.Services
{
    class PropertyNamer
    {
        public static string GetInnerPropertyName(string parentPropertyName, string propertyName)
        {
            return parentPropertyName + "." + propertyName;
        }

        public static string GetArrayItemPropertyName(string parentPropertyName, int index)
        {
            return parentPropertyName + "_[" + index + "]";
        }
    }
}
