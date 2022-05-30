﻿using EricssonYAMLEditor.Node.Models;
using EricssonYAMLEditor.Node.Services.Interfaces;
using EricssonYAMLEditor.Parser.Services.YamlDotNet.PropertyContentParser;
using System.Collections.Generic;

namespace EricssonYAMLEditor.Node.Services.YamlDotNet
{
    class YamlDotNetTreeBuilder : IYamlTreeBuilder
    {
        public YamlNode BuildTree<T>(T yamlData)
        {
            Dictionary<string, object> data =  yamlData as Dictionary<string, object>;

            YamlNode rootYamlNode = new YamlNode(string.Empty);
            rootYamlNode.Data = data;

            foreach (KeyValuePair<string, object> property in data)
            {
                string currentPropertyName = property.Key;
                ProcessNode(currentPropertyName, property, rootYamlNode);
            }

            return rootYamlNode;
        }

        public void ProcessNode(string propertyName, object value, YamlNode parentNode)
        {
            YamlNode newNode = AddNode(propertyName, value, parentNode);
            ProcessSubNodes(propertyName, value, newNode);
        }

        private YamlNode AddNode(string propertyName, object value, YamlNode parentNode)
        {
            YamlNode newNode = new YamlNode(propertyName);
            newNode.Data = value;
            parentNode.AddSubNode(newNode);
            return newNode;
        }

        public void ProcessSubNodes(string parentPropertyName, object value, YamlNode parentNode)
        {
            YamlDotNetPropertyContentParserFactory factory = null;
            
            if (value is List<object>)
            {
                factory = new YamlDotNetListParserFactory(this);
            }
            else if (value is Dictionary<object, object>)
            {
                factory = new YamlDotNetDictionaryParserFactory(this);
            }
            else if (value is KeyValuePair<object, object>)
            {
                factory = new YamlDotNetKeyValuePairParserFactory(this);
            }
            else if (value is KeyValuePair<string, object>)
            {
                factory = new YamlDotNetStringKeyValuePairParserFactory(this);
            }
            else
            {
                factory = new YamlDotNetPrimitiveTypeParserFactory(this);
            }

            factory.ProcessNodes(parentPropertyName, value, parentNode);
        }
    }
}