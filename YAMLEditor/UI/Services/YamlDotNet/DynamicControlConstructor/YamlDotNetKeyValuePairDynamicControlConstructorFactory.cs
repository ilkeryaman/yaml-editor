using System.Collections.Generic;

namespace YAMLEditor.UI.Services.YamlDotNet.DynamicControlConstructor
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
            _dynamicPanelConstructor.ConstructDynamicPanel(key, _data.Value);
        }
    }
}
