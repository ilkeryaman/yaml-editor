using System.Windows.Forms;

namespace EricssonYAMLEditor.UI.Services.Interfaces
{
    interface IContextMenuStripConstructor
    {
        ContextMenuStrip GetContextMenuStrip(object data);
    }
}
