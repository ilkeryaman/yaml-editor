using YAMLEditor.Parser.Services;
using System.Collections.Generic;

namespace YAMLEditor.UI.Services.YamlDotNet.DynamicControlConstructor
{
    class YamlDotNetListDynamicControlConstructorFactory : YamlDotNetDynamicControlConstructorFactory
    {
        private List<object> _data;

        public YamlDotNetListDynamicControlConstructorFactory(YamlDotNetDynamicPanelConstructor dynamicPanelConstructor,
            List<object> data) : base(dynamicPanelConstructor)
        {
            _data = data;
        }

        public override void ConstructDynamicControl(string key, bool isFromFirstLevelParent = false)
        {
            bool listWithKeyValuePair = false;

            for (int i = 0; i < _data.Count; i++)
            {
                object item = _data[i];
                /// It is difficult to manage list objects while rendering it recursively, so there should be a constraint here to show when only clicked from
                /// first level parent. When first level parent clicked, component will be shown; when upper level parents are clicked, it will not be shown.
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
                ControlCreator.CreateLabel(_dynamicPanelConstructor.Panel, key, key + " ====== [List (" + _data.Count + " items)]");
            }
        }
    }
}
