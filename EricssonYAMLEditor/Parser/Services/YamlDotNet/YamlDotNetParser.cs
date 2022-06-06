using EricssonYAMLEditor.Parser.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace EricssonYAMLEditor.Parser.Services.YamlDotNet
{
    class YamlDotNetParser : IYamlParser<Dictionary<string, object>>
    {
        public Dictionary<string, object> DeSerializeDocumentToClass(string filepath)
        {
            var deserializer = new Deserializer();
            return deserializer.Deserialize<Dictionary<string, Object>>(new StreamReader(filepath));
        }
    }
}
