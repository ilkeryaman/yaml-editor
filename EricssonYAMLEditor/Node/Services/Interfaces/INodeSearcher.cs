using EricssonYAMLEditor.Node.Models;

namespace EricssonYAMLEditor.Node.Services.Interfaces
{
    interface INodeSearcher
    {
        YamlNode SearchNode(YamlNode parentNode, string searchText);
    }
}
