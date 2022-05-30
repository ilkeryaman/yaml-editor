using EricssonYAMLEditor.Node.Models;
using EricssonYAMLEditor.Node.Services.YamlDotNet;

namespace EricssonYAMLEditor.Parser.Services.YamlDotNet.PropertyContentParser
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
