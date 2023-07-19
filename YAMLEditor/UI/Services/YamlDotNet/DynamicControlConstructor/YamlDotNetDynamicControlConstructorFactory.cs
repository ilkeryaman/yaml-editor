
namespace YAMLEditor.UI.Services.YamlDotNet.DynamicControlConstructor
{
    abstract class YamlDotNetDynamicControlConstructorFactory
    {
        protected YamlDotNetDynamicPanelConstructor _dynamicPanelConstructor;

        public YamlDotNetDynamicControlConstructorFactory(YamlDotNetDynamicPanelConstructor dynamicPanelConstructor)
        {
            _dynamicPanelConstructor = dynamicPanelConstructor;
        }

        public abstract void ConstructDynamicControl(string key, bool isFromFirstLevelParent = false);
    }
}
