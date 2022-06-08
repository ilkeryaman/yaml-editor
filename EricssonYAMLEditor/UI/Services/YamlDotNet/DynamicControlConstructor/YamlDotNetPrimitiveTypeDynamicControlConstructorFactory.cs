using EricssonYAMLEditor.Node.Models;
using System.Windows.Forms;

namespace EricssonYAMLEditor.UI.Services.YamlDotNet.DynamicControlConstructor
{
    class YamlDotNetPrimitiveTypeDynamicControlConstructorFactory : YamlDotNetDynamicControlConstructorFactory
    {
        private string _data;

        public YamlDotNetPrimitiveTypeDynamicControlConstructorFactory(YamlDotNetDynamicPanelConstructor dynamicPanelConstructor,
            string data) : base(dynamicPanelConstructor)
        {
            _data = data;
        }

        public override void ConstructDynamicControl(string key, bool isFromFirstLevelParent = false)
        {
            if (ComboBoxReferenceMapService.IsComboBoxProperty(key))
            {
                TreeView treeView = (TreeView) _dynamicPanelConstructor.Panel.Tag;
                ControlCreator.CreateComboBox(_dynamicPanelConstructor.Panel, key, ComboBoxReferenceMapService.GetComboBoxData(key, (YamlNode)treeView.Tag), _data);
            }
            else if (_data.Contains("\n"))
            {
                ControlCreator.CreateTextArea(_dynamicPanelConstructor.Panel, key, _data);
            }
            else
            {
                ControlCreator.CreateTextBox(_dynamicPanelConstructor.Panel, key, _data);
            }
        }
    }
}
