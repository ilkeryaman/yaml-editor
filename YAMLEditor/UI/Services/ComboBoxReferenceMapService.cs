using YAMLEditor.Node.Constants;
using YAMLEditor.Node.Models;
using YAMLEditor.Node.Services;
using YAMLEditor.Node.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace YAMLEditor.UI.Services
{
    class ComboBoxReferenceMapService
    {
        private static List<string> comboBoxPropertyList = new List<string>(){
            PropertyKey.FullName.control_plane_internal_vip
        };

        public static bool IsComboBoxProperty(string property)
        {
            return comboBoxPropertyList.Contains(property);
        }

        public static List<string> GetComboBoxData(string property, YamlNode rootNode)
        {
            List<string> data = new List<string>();
            switch (property)
            {
                case PropertyKey.FullName.control_plane_internal_vip:
                    INodeSearcher nodeSearcher = new NodeSearcher();
                    YamlNode foundNode = nodeSearcher.SearchNode(rootNode, PropertyKey.FullName.networks);
                    if(foundNode != null)
                    {
                        List<object> networkList = (List<object>)((KeyValuePair<object, object>)foundNode.Data).Value;
                        foreach (object item in networkList)
                        {
                            Dictionary<object, object> dict = item as Dictionary<object, object>;
                            if (dict.ContainsKey(PropertyKey.LeafName.gateway_ipv4))
                            {
                                data.Add(Convert.ToString(dict[PropertyKey.LeafName.gateway_ipv4]));
                            }
                        }
                    }
                    break;
            }
            return data;
        }
    }
}
