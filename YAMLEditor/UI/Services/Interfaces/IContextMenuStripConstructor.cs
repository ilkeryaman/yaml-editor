using System.Windows.Forms;

namespace YAMLEditor.UI.Services.Interfaces
{
    public interface IContextMenuStripConstructor
    {
        ContextMenuStrip GetContextMenuStrip(object data, bool isRootNode = false);
    }
}
