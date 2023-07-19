using YAMLEditor.ContentEditor.Model;
using YAMLEditor.Node.Models;

namespace YAMLEditor.ContentEditor.Services.Interfaces
{
    interface IContentRemover
    {
        ContentEditorResult RemoveContent(YamlNode node);
    }
}
