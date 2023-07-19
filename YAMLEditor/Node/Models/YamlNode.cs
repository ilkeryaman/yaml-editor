using System.Collections.Generic;

namespace YAMLEditor.Node.Models
{
    class YamlNode
    {
        private List<YamlNode> _subNodeList;
        private YamlNode _parentNode;
        private string _name;
        private object _data;

        public YamlNode(string name)
        {
            _name = name;
            _subNodeList = new List<YamlNode>();
        }

        public YamlNode ParentNode
        {
            get { return _parentNode; }
        }

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public object Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public List<YamlNode> SubNodeList
        {
            get { return _subNodeList; }
        }
        
        public void AddSubNode(YamlNode subNode)
        {
            _subNodeList.Add(subNode);
            subNode._parentNode = this;
        }

        public void Remove()
        {
            if(_parentNode != null && _parentNode._subNodeList != null)
            {
                _parentNode._subNodeList.Remove(this);
            }
        }

        public string GetVisibleName(string name, string parentName)
        {
            int startIndex = string.IsNullOrEmpty(parentName) ? 0 : parentName.Length + 1;
            return name.Substring(startIndex);
        }

        public bool IsItemOfListNode()
        {
            bool isItemOfListNode = false;

            if (ParentNode != null && ParentNode.Data is KeyValuePair<object, object>)
            {
                KeyValuePair<object, object> kvp = (KeyValuePair<object, object>) ParentNode.Data;
                isItemOfListNode = kvp.Value is List<object>;
            }

            return isItemOfListNode;
        }
    }
}
