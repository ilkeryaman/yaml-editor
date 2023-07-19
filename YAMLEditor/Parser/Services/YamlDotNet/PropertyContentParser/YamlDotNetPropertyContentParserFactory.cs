using YAMLEditor.Node.Models;
using YAMLEditor.Node.Services.YamlDotNet;

namespace YAMLEditor.Parser.Services.YamlDotNet.PropertyContentParser
{
    abstract class YamlDotNetPropertyContentParserFactory
    {
        protected YamlDotNetTreeBuilder _treeBuilder;

        public YamlDotNetPropertyContentParserFactory(YamlDotNetTreeBuilder treeBuilder)
        {
            _treeBuilder = treeBuilder;
        }

        public abstract void ProcessNodes(string parentPropertyName, object value, YamlNode parentNode);
    }
}
