using EricssonYAMLEditor.Node.Models;

namespace EricssonYAMLEditor.ContentEditor.Services.Interfaces
{
    interface IContentChanger
    {
        void ChangeContent(YamlNode node, string value);
    }
}
