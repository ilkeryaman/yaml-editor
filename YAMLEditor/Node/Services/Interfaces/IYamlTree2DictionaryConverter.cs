using YAMLEditor.Node.Models;
using System.Collections.Generic;

namespace YAMLEditor.Node.Services.Interfaces
{
    interface IYamlTree2DictionaryConverter
    {
        Dictionary<string, object> Convert(YamlNode rootNode);
    }
}
