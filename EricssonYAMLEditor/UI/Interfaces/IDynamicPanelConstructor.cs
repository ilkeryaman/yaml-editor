
namespace EricssonYAMLEditor.UI.Interfaces
{
    interface IDynamicPanelConstructor
    {
        void ConstructDynamicPanel(string key, object data, bool isFromFirstLevelParent = false);
    }
}
