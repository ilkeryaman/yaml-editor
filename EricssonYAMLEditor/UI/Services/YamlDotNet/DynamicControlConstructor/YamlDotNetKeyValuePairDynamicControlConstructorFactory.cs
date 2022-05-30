using EricssonYAMLEditor.Parser.Services;
using System;
using System.Collections.Generic;

namespace EricssonYAMLEditor.UI.Services.YamlDotNet.DynamicControlConstructor
{
    class YamlDotNetKeyValuePairDynamicControlConstructorFactory : YamlDotNetDynamicControlConstructorFactory
    {
        private KeyValuePair<object, object> _data;

        public YamlDotNetKeyValuePairDynamicControlConstructorFactory(YamlDotNetDynamicPanelConstructor dynamicPanelConstructor,
            KeyValuePair<object, object> data) : base(dynamicPanelConstructor)
        {
            _data = data;
        }

        public override void ConstructDynamicControl(string key, bool isFromFirstLevelParent = false)
        {
            if (_data.Value is string)
            {
                ControlCreator.CreateTextBox(_dynamicPanelConstructor.Panel, key, Convert.ToString(_data.Value));
            }
            else if (_data.Value is KeyValuePair<object, object>)
            {

            }
            else if(_data.Value is Dictionary<object, object>)
            {
                Dictionary<object, object> dictData = (Dictionary<object, object>)_data.Value;
                foreach (var entry in dictData)
                {
                    _dynamicPanelConstructor.ConstructDynamicPanel(PropertyNamer.GetInnerPropertyName(key, Convert.ToString(entry.Key)), entry);
                }
            }
            else if (_data.Value is List<object>)
            {
                List<object> objKvpData = (List<object>) _data.Value;

                bool listWithKeyValuePair = false;

                for (int i = 0; i < objKvpData.Count; i++)
                {
                    object item = objKvpData[i];
                    /// It is difficult to manage list objects when render it recursively, so there should be a constraint here to show when clicked from first level parent
                    /// When first level parent clicked, component will be shown; when upper level parents are clicked, it will not be shown.
                    if (isFromFirstLevelParent && item is string)
                    {
                        _dynamicPanelConstructor.ConstructDynamicPanel(PropertyNamer.GetArrayItemPropertyName(key, i), item);
                    }
                    else
                    {
                        listWithKeyValuePair = true;
                        break;
                    }
                }

                if (listWithKeyValuePair)
                {
                    ControlCreator.CreateLabel(_dynamicPanelConstructor.Panel, key, key + " ====== [List (" + objKvpData.Count + " items)]");
                }
            }
        }
    }
}
