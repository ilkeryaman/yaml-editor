using System;
using YAMLEditor.Node.Models;
using YAMLEditor.Node.Services.YamlDotNet;

namespace YAMLEditor.Parser.Services.YamlDotNet.PropertyContentParser
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
