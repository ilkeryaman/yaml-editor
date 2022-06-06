using EricssonYAMLEditor.ContentEditor.Model;
using EricssonYAMLEditor.Node.Models;

namespace EricssonYAMLEditor.ContentEditor.Services.Interfaces
{
    interface IContentChanger
    {
        ContentEditorResult ChangeContent(YamlNode node, string value);
    }
}
