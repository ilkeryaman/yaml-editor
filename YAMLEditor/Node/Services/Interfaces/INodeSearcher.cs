using YAMLEditor.Node.Models;

namespace YAMLEditor.Node.Services.Interfaces
{
    interface INodeSearcher
    {
        YamlNode SearchNode(YamlNode parentNode, string searchText);
    }
}
