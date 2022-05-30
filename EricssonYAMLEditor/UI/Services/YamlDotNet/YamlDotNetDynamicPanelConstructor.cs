using EricssonYAMLEditor.UI.Interfaces;
using EricssonYAMLEditor.UI.Services.YamlDotNet.DynamicControlConstructor;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EricssonYAMLEditor.UI.Services.YamlDotNet
{
    class YamlDotNetDynamicPanelConstructor : IDynamicPanelConstructor
    {
        private FlowLayoutPanel _panel;
        private List<TextBox> textBoxList;

        public YamlDotNetDynamicPanelConstructor(FlowLayoutPanel panel)
        {
            _panel = panel;
            textBoxList = new List<TextBox>();
        }

        public FlowLayoutPanel Panel
        {
            get { return _panel; }
        }

        public void ConstructDynamicPanel(string key, object data, bool isFromFirstLevelParent = false)
        {
            YamlDotNetDynamicControlConstructorFactory factory = null;
            if (data is KeyValuePair<string, object>)
            {
                KeyValuePair<string, object> kvpData = (KeyValuePair<string, object>) data;
                factory = new YamlDotNetStringKeyValuePairDynamicControlConstructorFactory(this, kvpData);
            }
            else if (data is KeyValuePair<object, object>)
            {
                KeyValuePair<object, object> kvpData = (KeyValuePair<object, object>) data;
                factory = new YamlDotNetKeyValuePairDynamicControlConstructorFactory(this, kvpData);
            }
            else if (data is Dictionary<object, object>)
            {
                Dictionary<object, object> dictData = (Dictionary<object, object>) data;
                factory = new YamlDotNetDictionaryDynamicControlConstructorFactory(this, dictData);
            }
            else if (data is string)
            {
                string strData = Convert.ToString(data);
                factory = new YamlDotNetPrimitiveTypeDynamicControlConstructorFactory(this, strData);
            }

            factory.ConstructDynamicControl(key, isFromFirstLevelParent);
        }
    }
}
