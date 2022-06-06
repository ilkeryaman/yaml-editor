using EricssonYAMLEditor.ContentEditor.Services.Interfaces;
using EricssonYAMLEditor.Node.Models;
using System.Collections.Generic;

namespace EricssonYAMLEditor.ContentEditor.Services.YamlDotNet
{
    class YamlDotNetContentChanger : IContentChanger
    {
        public void ChangeContent(YamlNode node, string value)
        {
            object dataOfParentNode = node.ParentNode.Data;
            string propertyName = node.Name.Substring(node.Name.LastIndexOf(".") + 1);

            if (dataOfParentNode is Dictionary<object, object>)
            {
                Dictionary<object, object> dict = (Dictionary<object, object>)dataOfParentNode;
                dict[propertyName] = value;
            }
            else if(dataOfParentNode is Dictionary<string, object>)
            {
                Dictionary<string, object> dict = (Dictionary<string, object>)dataOfParentNode;
                dict[propertyName] = value;
            }
            else if(dataOfParentNode is KeyValuePair<string, object>){
                KeyValuePair<string, object> kvp = (KeyValuePair<string, object>)dataOfParentNode;
                if(kvp.Value is Dictionary<object, object>){
                    Dictionary<object, object> dict = (Dictionary<object, object>) kvp.Value;
                    dict[propertyName] = value;
                }
                else if(kvp.Value is List<object>)
                {
                    List<object> list = (List<object>)kvp.Value;
                    int indexToChange = node.ParentNode.SubNodeList.FindIndex(i => i == node);
                    list[indexToChange] = value;
                }
            }
            else if (dataOfParentNode is KeyValuePair<object, object>)
            {
                KeyValuePair<object, object> kvp = (KeyValuePair<object, object>)dataOfParentNode;
                if (kvp.Value is Dictionary<object, object>)
                {
                    Dictionary<object, object> dict = (Dictionary<object, object>)kvp.Value;
                    dict[propertyName] = value;
                }
                else if (kvp.Value is List<object>)
                {
                    List<object> list = (List<object>)kvp.Value;
                    int indexToChange = node.ParentNode.SubNodeList.FindIndex(i => i == node);
                    list[indexToChange] = value;
                }
            }

            if (node.Data is KeyValuePair<string, object>)
            {
                node.Data = new KeyValuePair<string, object>(propertyName, value);
            }
            else if (node.Data is KeyValuePair<object, object>)
            {
                node.Data = new KeyValuePair<object, object>(propertyName, value);
            }
            else if (node.Data is string)
            {
                node.Data = value;
            }
        }
    }
}
