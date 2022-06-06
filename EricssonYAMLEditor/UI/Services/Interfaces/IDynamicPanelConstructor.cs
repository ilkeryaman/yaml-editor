
namespace EricssonYAMLEditor.UI.Services.Interfaces
{
    interface IDynamicPanelConstructor
    {
        void ConstructDynamicPanel(string key, object data, bool isFromFirstLevelParent = false);
    }
}
