using EricssonYAMLEditor.Node.Models;

namespace EricssonYAMLEditor.Node.Services.Interfaces
{
    interface IYamlTreeBuilder
    {
        YamlNode BuildTree<T>(T yamlData);
        void UpdateListNode(YamlNode node);
    }
}
