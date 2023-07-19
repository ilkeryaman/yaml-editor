using System.Collections.Generic;

namespace YAMLEditor.UI.Services.YamlDotNet.DynamicControlConstructor
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
            _dynamicPanelConstructor.ConstructDynamicPanel(key, _data.Value);
        }
    }
}
