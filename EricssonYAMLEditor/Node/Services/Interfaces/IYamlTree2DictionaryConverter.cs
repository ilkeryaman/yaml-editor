using EricssonYAMLEditor.Node.Models;
using System.Collections.Generic;

namespace EricssonYAMLEditor.Node.Services.Interfaces
{
    interface IYamlTree2DictionaryConverter
    {
        Dictionary<string, object> Convert(YamlNode rootNode);
    }
}
