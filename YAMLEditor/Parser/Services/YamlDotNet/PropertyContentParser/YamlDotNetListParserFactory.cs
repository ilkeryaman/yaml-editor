using System;
using YAMLEditor.Node.Models;
using System.Collections.Generic;
using YAMLEditor.Node.Services.YamlDotNet;

namespace YAMLEditor.Parser.Services.YamlDotNet.PropertyContentParser
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

        public void UpdateListNodes(YamlNode node)
        {
            for(int i=0; i < node.SubNodeList.Count; i++)
            {
                YamlNode subNode = node.SubNodeList[i];
                string propertyName = PropertyNamer.GetArrayItemPropertyName(node.Name, i);
                subNode.Name = propertyName;
            }
        }
    }
}
