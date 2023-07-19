using System;
using YAMLEditor.Node.Models;
using YAMLEditor.Node.Services.YamlDotNet;
using System.Collections.Generic;

namespace YAMLEditor.Parser.Services.YamlDotNet.PropertyContentParser
{
    class YamlDotNetKeyValuePairParserFactory : YamlDotNetPropertyContentParserFactory
    {
        public YamlDotNetKeyValuePairParserFactory(YamlDotNetTreeBuilder treeBuilder) : base(treeBuilder)
        {
        }

        public override void ProcessNodes(string parentPropertyName, object value, YamlNode parentNode)
        {
            var property = (KeyValuePair<object, object>)value;
            _treeBuilder.ProcessSubNodes(parentPropertyName, property.Value, parentNode);
        }
    }
}
