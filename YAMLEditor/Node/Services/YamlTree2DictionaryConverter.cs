using System;
using System.Collections.Generic;
using YAMLEditor.Node.Models;
using YAMLEditor.Node.Services.Interfaces;

namespace YAMLEditor.Node.Services
{
    class YamlTree2DictionaryConverter : IYamlTree2DictionaryConverter
    {
        public Dictionary<string, object> Convert(YamlNode rootNode)
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            AddNodeToDictionary(dictionary, rootNode);
            return dictionary;
        }

        private void AddNodeToDictionary(Dictionary<string, object> dictionary, YamlNode yamlNode)
        {
            dictionary.Add(yamlNode.Name, yamlNode.Data);
            foreach (YamlNode subNode in yamlNode.SubNodeList)
            {
                AddNodeToDictionary(dictionary, subNode);
            }
        }
    }
}
