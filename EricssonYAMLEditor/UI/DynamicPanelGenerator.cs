using EricssonYAMLEditor.UI.Interfaces;
using EricssonYAMLEditor.UI.Services;
using EricssonYAMLEditor.UI.Services.YamlDotNet;
using System.Drawing;
using System.Windows.Forms;

namespace EricssonYAMLEditor.UI
{
    class DynamicPanelGenerator
    {
        private object _data;
        private FlowLayoutPanel _panel;
        IDynamicPanelConstructor dynamicPanelConstructor;

        public DynamicPanelGenerator(FlowLayoutPanel panel, object data)
        {
            _panel = panel;
            _data = data;
            dynamicPanelConstructor = new YamlDotNetDynamicPanelConstructor(_panel);
        }

        public void ConstructDynamicPanel(string key)
        {
            _panel.Controls.Clear();
            CreateTitle(key);
            dynamicPanelConstructor.ConstructDynamicPanel(key, _data, true);
        }

        private void CreateTitle(string key)
        {
            string title = "[ " + key + " ]";
            ControlCreator.CreateLabel(_panel, key, title, Color.Red);
        }
    }
}
