using EricssonYAMLEditor.Node.Models;

namespace EricssonYAMLEditor.ContentEditor.Services.Interfaces
{
    interface IContentRemover
    {
        bool RemoveContent(YamlNode node);
    }
}
