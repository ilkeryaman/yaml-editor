using EricssonYAMLEditor.Node.Models;

namespace EricssonYAMLEditor.Node.Services.Interfaces
{
    interface IYamlTreeBuilder<T>
    {
        YamlNode BuildTree(T yamlData);
        void UpdateListNode(YamlNode node);
        YamlNode ProcessNode(string propertyName, object value, YamlNode parentNode);
    }
}
