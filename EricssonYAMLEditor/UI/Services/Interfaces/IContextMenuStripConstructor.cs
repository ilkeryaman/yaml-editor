using System.Windows.Forms;

namespace EricssonYAMLEditor.UI.Services.Interfaces
{
    public interface IContextMenuStripConstructor
    {
        ContextMenuStrip GetContextMenuStrip(object data, bool isRootNode = false);
    }
}
