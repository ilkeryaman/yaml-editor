using System;
using EricssonYAMLEditor.Node.Models;
using EricssonYAMLEditor.Node.Services.YamlDotNet;

namespace EricssonYAMLEditor.Parser.Services.YamlDotNet.PropertyContentParser
{
    class YamlDotNetPrimitiveTypeParserFactory : YamlDotNetPropertyContentParserFactory
    {
        public YamlDotNetPrimitiveTypeParserFactory(YamlDotNetTreeBuilder treeBuilder) : base(treeBuilder)
        {
        }

        public override void ProcessNodes(string parentPropertyName, object value, YamlNode parentNode)
        {
            // Nothing to do
        }
    }
}
