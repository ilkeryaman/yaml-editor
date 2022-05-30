﻿using System;
using EricssonYAMLEditor.Node.Models;
using EricssonYAMLEditor.Node.Services.YamlDotNet;
using System.Collections.Generic;

namespace EricssonYAMLEditor.Parser.Services.YamlDotNet.PropertyContentParser
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
