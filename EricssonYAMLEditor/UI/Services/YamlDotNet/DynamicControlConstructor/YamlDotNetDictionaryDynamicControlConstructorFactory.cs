using EricssonYAMLEditor.Parser.Services;
using System;
using System.Collections.Generic;

namespace EricssonYAMLEditor.UI.Services.YamlDotNet.DynamicControlConstructor
{
    class YamlDotNetDictionaryDynamicControlConstructorFactory : YamlDotNetDynamicControlConstructorFactory
    {
        private Dictionary<object, object> _data;

        public YamlDotNetDictionaryDynamicControlConstructorFactory(YamlDotNetDynamicPanelConstructor dynamicPanelConstructor,
            Dictionary<object, object> data) : base(dynamicPanelConstructor)
        {
            _data = data;
        }

        public override void ConstructDynamicControl(string key, bool isFromFirstLevelParent = false)
        {
            foreach (var entry in _data)
            {
                _dynamicPanelConstructor.ConstructDynamicPanel(PropertyNamer.GetInnerPropertyName(key, Convert.ToString(entry.Key)), entry);
            }
        }
    }
}
