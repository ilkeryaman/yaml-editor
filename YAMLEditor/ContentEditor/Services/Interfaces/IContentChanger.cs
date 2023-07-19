using YAMLEditor.ContentEditor.Model;
using YAMLEditor.Node.Models;

namespace YAMLEditor.ContentEditor.Services.Interfaces
{
    interface IContentChanger
    {
        ContentEditorResult ChangeContent(YamlNode node, string value);
    }
}
