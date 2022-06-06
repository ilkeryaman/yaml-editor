using EricssonYAMLEditor.ContentEditor.Model;
using EricssonYAMLEditor.Node.Models;

namespace EricssonYAMLEditor.ContentEditor.Services.Interfaces
{
    interface IContentRemover
    {
        ContentEditorResult RemoveContent(YamlNode node);
    }
}
