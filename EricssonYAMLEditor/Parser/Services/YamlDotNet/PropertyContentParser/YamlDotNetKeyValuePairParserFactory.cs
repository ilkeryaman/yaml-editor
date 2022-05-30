using System;
using EricssonYAMLEditor.Node.Models;
using EricssonYAMLEditor.Node.Services.YamlDotNet;
using System.Collections.Generic;

namespace EricssonYAMLEditor.Parser.Services.YamlDotNet.PropertyContentParser
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
