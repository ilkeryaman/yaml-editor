using EricssonYAMLEditor.Node.Models;
using EricssonYAMLEditor.Node.Services.Interfaces;
using System.Text.RegularExpressions;

namespace EricssonYAMLEditor.Node.Services
{
    class NodeSearcher : INodeSearcher
    {
        private string _regexPattern = @"_\[\d{1,}\]";
        private char _dot = '.';

        public YamlNode SearchNode(YamlNode parentNode, string searchText)
        {
            string[] propertyNameTree = string.IsNullOrEmpty(parentNode.Name) 
                ? searchText.Split(_dot)
                : searchText.Replace(parentNode.Name, string.Empty).Split(_dot);

            YamlNode foundNode = parentNode;

            foreach(string propertyName in propertyNameTree)
            {
                Match regexMatch = Regex.Match(propertyName, _regexPattern);
                if (regexMatch.Success)
                {
                    string parentPropertyName = Regex.Replace(propertyName, _regexPattern, string.Empty);
                    string parentNodeName = parentNode.Name;
                    foundNode = FindSubNode(foundNode, parentPropertyName);
                    foundNode = FindSubNode(foundNode, regexMatch.Value, true);
                }
                else
                {
                    foundNode = FindSubNode(foundNode, propertyName);
                }
            }

            return foundNode;
        }

        private YamlNode FindSubNode(YamlNode node, string subNodeName, bool isListItem = false)
        {
            return node.SubNodeList.Find(subNode => subNode.Name.Equals(string.IsNullOrEmpty(node.Name) 
                ? subNodeName 
                : node.Name + (isListItem ? string.Empty : _dot.ToString()) + subNodeName
                ));
        }
    }
}
