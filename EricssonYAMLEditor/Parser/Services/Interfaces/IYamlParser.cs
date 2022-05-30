namespace EricssonYAMLEditor.Parser.Services.Interfaces
{
    interface IYamlParser<T>
    {
        T DeSerializeDocumentToClass(string filepath);
    }
}
