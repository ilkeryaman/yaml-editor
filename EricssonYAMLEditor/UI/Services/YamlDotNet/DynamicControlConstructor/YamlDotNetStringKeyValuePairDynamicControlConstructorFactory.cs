using System;
using System.Collections.Generic;

namespace EricssonYAMLEditor.UI.Services.YamlDotNet.DynamicControlConstructor
{
    class YamlDotNetStringKeyValuePairDynamicControlConstructorFactory : YamlDotNetDynamicControlConstructorFactory
    {
        private KeyValuePair<string, object> _data;

        public YamlDotNetStringKeyValuePairDynamicControlConstructorFactory(YamlDotNetDynamicPanelConstructor dynamicPanelConstructor, 
            KeyValuePair<string, object> data) : base(dynamicPanelConstructor)
        {
            _data = data;
        }

        public override void ConstructDynamicControl(string key, bool isFromFirstLevelParent = false)
        {
            if (_data.Value is string)
            {
                ControlCreator.CreateTextBox(_dynamicPanelConstructor.Panel, key, Convert.ToString(_data.Value));
            }
            else if (_data.Value is Dictionary<object, object>)
            {
                _dynamicPanelConstructor.ConstructDynamicPanel(key, _data.Value);
            }
        }
    }
}
