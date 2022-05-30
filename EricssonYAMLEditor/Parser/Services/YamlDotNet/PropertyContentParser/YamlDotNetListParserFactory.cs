using System;
using EricssonYAMLEditor.Node.Models;
using System.Collections.Generic;
using EricssonYAMLEditor.Node.Services.YamlDotNet;

namespace EricssonYAMLEditor.Parser.Services.YamlDotNet.PropertyContentParser
{
    class YamlDotNetListParserFactory : YamlDotNetPropertyContentParserFactory
    {
        public YamlDotNetListParserFactory(YamlDotNetTreeBuilder treeBuilder) : base(treeBuilder)
        {
        }

        public override void ProcessNodes(string parentPropertyName, object value, YamlNode parentNode)
        {
            List<object> items = (List<object>) value;

            for(int i=0; i<items.Count; i++)
            {
                object item = items[i];
                string propertyName = PropertyNamer.GetArrayItemPropertyName(parentPropertyName, i);
                _treeBuilder.ProcessNode(propertyName, item, parentNode);
            }
        }
    }
}
