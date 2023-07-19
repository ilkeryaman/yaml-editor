using System;
using YAMLEditor.Node.Models;
using YAMLEditor.Node.Services.YamlDotNet;
using System.Collections.Generic;

namespace YAMLEditor.Parser.Services.YamlDotNet.PropertyContentParser
{
    class YamlDotNetDictionaryParserFactory : YamlDotNetPropertyContentParserFactory
    {
        public YamlDotNetDictionaryParserFactory(YamlDotNetTreeBuilder treeBuilder) : base(treeBuilder)
        {
        }

        public override void ProcessNodes(string parentPropertyName, object value, YamlNode parentNode)
        {
            Dictionary<object, object> dictionary = (Dictionary<object, object>)value;

            foreach (var property in dictionary)
            {
                string propertyName = PropertyNamer.GetInnerPropertyName(parentPropertyName, Convert.ToString(property.Key));
                _treeBuilder.ProcessNode(propertyName, property, parentNode);
            }
        }
    }
}
