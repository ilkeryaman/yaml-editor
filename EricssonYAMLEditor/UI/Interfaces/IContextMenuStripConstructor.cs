
using System.Windows.Forms;

namespace EricssonYAMLEditor.UI.Interfaces
{
    interface IContextMenuStripConstructor
    {
        ContextMenuStrip GetContextMenuStrip(object data);
    }
}
