using EricssonYAMLEditor.ContentEditor.Model;
using EricssonYAMLEditor.ContentEditor.Services.Interfaces;
using EricssonYAMLEditor.Exception.Constants;
using EricssonYAMLEditor.Exception.Model;
using EricssonYAMLEditor.Node.Models;
using System.Collections.Generic;

namespace EricssonYAMLEditor.ContentEditor.Services.YamlDotNet
{
    class YamlDotNetContentChanger : IContentChanger
    {
        IContentValidator _contentValidator;

        public YamlDotNetContentChanger()
        {
            _contentValidator = new ContentValidator();
        }

        public ContentEditorResult ChangeContent(YamlNode node, string value)
        {
            ContentEditorResult result = new ContentEditorResult();
            string propertyName = node.Name.Substring(node.Name.LastIndexOf(".") + 1);
            if(_contentValidator.ValidateContent(propertyName, value))
            {
                if (ChangeOriginalData(node, propertyName, value))
                {
                    ChangeDataOfCurrentNode(node, propertyName, value);
                }
                else
                {
                    result.SetException(new ImplementationException(string.Format(ExceptionMessage.Not_Edited_Content, propertyName)));
                }
            }
            else
            {
                result.SetException(new ValidationException(string.Format(ExceptionMessage.Not_Valid_Content, propertyName)));
            }
            
            return result;
        }

        private bool ChangeOriginalData(YamlNode node, string propertyName, string value)
        {
            bool isOriginalDataChanged = false;
            object dataOfParentNode = node.ParentNode.Data;

            if (dataOfParentNode is Dictionary<object, object>)
            {
                Dictionary<object, object> dict = (Dictionary<object, object>)dataOfParentNode;
                dict[propertyName] = value;
                isOriginalDataChanged = true;
            }
            else if (dataOfParentNode is Dictionary<string, object>)
            {
                Dictionary<string, object> dict = (Dictionary<string, object>)dataOfParentNode;
                dict[propertyName] = value;
                isOriginalDataChanged = true;
            }
            else if (dataOfParentNode is KeyValuePair<string, object>)
            {
                KeyValuePair<string, object> kvp = (KeyValuePair<string, object>)dataOfParentNode;
                if (kvp.Value is Dictionary<object, object>)
                {
                    Dictionary<object, object> dict = (Dictionary<object, object>)kvp.Value;
                    dict[propertyName] = value;
                    isOriginalDataChanged = true;
                }
                else if (kvp.Value is List<object>)
                {
                    List<object> list = (List<object>)kvp.Value;
                    int indexToChange = node.ParentNode.SubNodeList.FindIndex(i => i == node);
                    list[indexToChange] = value;
                    isOriginalDataChanged = true;
                }
            }
            else if (dataOfParentNode is KeyValuePair<object, object>)
            {
                KeyValuePair<object, object> kvp = (KeyValuePair<object, object>)dataOfParentNode;
                if (kvp.Value is Dictionary<object, object>)
                {
                    Dictionary<object, object> dict = (Dictionary<object, object>)kvp.Value;
                    dict[propertyName] = value;
                    isOriginalDataChanged = true;
                }
                else if (kvp.Value is List<object>)
                {
                    List<object> list = (List<object>)kvp.Value;
                    int indexToChange = node.ParentNode.SubNodeList.FindIndex(i => i == node);
                    list[indexToChange] = value;
                    isOriginalDataChanged = true;
                }
            }
            return isOriginalDataChanged;
        }

        private void ChangeDataOfCurrentNode(YamlNode node, string propertyName, string value)
        {
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
