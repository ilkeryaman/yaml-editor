
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
            if (_data.Contains("\n"))
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
