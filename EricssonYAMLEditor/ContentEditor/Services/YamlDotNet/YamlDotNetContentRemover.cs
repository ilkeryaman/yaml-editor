using EricssonYAMLEditor.ContentEditor.Model;
using EricssonYAMLEditor.ContentEditor.Services.Interfaces;
using EricssonYAMLEditor.Exception.Constants;
using EricssonYAMLEditor.Exception.Model;
using EricssonYAMLEditor.Node.Models;
using System.Collections.Generic;

namespace EricssonYAMLEditor.ContentEditor.Services.YamlDotNet
{
    class YamlDotNetContentRemover : IContentRemover
    {
        public ContentEditorResult RemoveContent(YamlNode node)
        {
            object data = node.ParentNode.Data;
            object dataToRemove = node.Data;

            if(data is Dictionary<object, object>)
            {
                Dictionary<object, object> dict = (Dictionary<object, object>) data;
                bool isContentRemoved = RemoveDataFromDictionary(dict, node);
                return GenerateResult(RemoveDataFromDictionary(dict, node), node.Name);
            }
            else if(data is Dictionary<string, object>)
            {
                Dictionary<string, object> dict = (Dictionary<string, object>)data;
                return GenerateResult(RemoveDataFromDictionary(dict, node), node.Name);
                
            }
            else if(data is KeyValuePair<object, object>)
            {
                KeyValuePair<object, object> kvpData = (KeyValuePair<object, object>) data;
                return GenerateResult(RemoveDataFromValueOfKeyValuePair(kvpData.Value, dataToRemove, node), node.Name);
            }
            else if(data is KeyValuePair<string, object>)
            {
                KeyValuePair<string, object> kvpData = (KeyValuePair<string, object>) data;
                return GenerateResult(RemoveDataFromValueOfKeyValuePair(kvpData.Value, dataToRemove, node), node.Name);
            }
            else
            {
                return GenerateResult(false, node.Name);
            }
        }

        private bool RemoveDataFromDictionary<T>(Dictionary<T, object> dict, YamlNode node)
        {
            int indexToRemove = node.ParentNode.SubNodeList.FindIndex(i => i == node);
            int currentIndex = 0;
            T keyFound = default(T);
            foreach (T key in dict.Keys)
            {
                if (currentIndex == indexToRemove)
                {
                    keyFound = key;
                    break;
                }
                currentIndex++;
            }

            return dict.Remove(keyFound);
        }

        private bool RemoveDataFromValueOfKeyValuePair(object kvpValue, object dataToRemove, YamlNode node)
        {
            bool isContentRemoved = false;
            if (kvpValue is Dictionary<object, object>)
            {
                Dictionary<object, object> dict = (Dictionary<object, object>)kvpValue;
                if (dataToRemove is KeyValuePair<object, object>)
                {
                    KeyValuePair<object, object> kvpData2Remove = (KeyValuePair<object, object>) dataToRemove;
                    isContentRemoved = dict.Remove(kvpData2Remove.Key);
                }
            }
            else if (kvpValue is List<object>)
            {
                List<object> list = (List<object>)kvpValue;
                int indexToRemove = node.ParentNode.SubNodeList.FindIndex(i => i == node);
                list.RemoveAt(indexToRemove);
                isContentRemoved = true;
            }
            return isContentRemoved;
        }

        private ContentEditorResult GenerateResult(bool isSuccess, string propertyName)
        {
            ContentEditorResult result = new ContentEditorResult();
            return isSuccess ? result : result.SetException(new ImplementationException(string.Format(ExceptionMessage.Not_Removed_Content, propertyName)));
        }
    }
}
