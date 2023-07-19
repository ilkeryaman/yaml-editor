using YAMLEditor.Exception.Model;
using YAMLEditor.Parser.Services.Interfaces;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace YAMLEditor.Parser.Services.YamlDotNet
{
    class YamlDotNetParser : IYamlParser<Dictionary<string, object>>
    {
        public Dictionary<string, object> DeSerializeDocumentToClass(string filepath)
        {
            try
            {
                var deserializer = new Deserializer();
                Dictionary<string, object> dict = deserializer.Deserialize<Dictionary<string, object>>(new StreamReader(filepath));
                if(dict == null)
                {
                    throw new IllegalYamlFileException();
                }
                return dict;
            }
            catch (YamlException)
            {
                throw new IllegalYamlFileException();
            }
        }
    }
}
