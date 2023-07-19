using YAMLEditor.UI.Services.Interfaces;
using System.Windows.Forms;

namespace YAMLEditor.UI.Models
{
    public class AddNewItemFormParams
    {
        private TreeNode _treeNode;
        private IContextMenuStripConstructor _contextMenuStripConstructor;

        public TreeNode TreeNode
        {
            get { return _treeNode; }
            set { _treeNode = value; }
        }

        public IContextMenuStripConstructor ContextMenuStripConstructor
        {
            get { return _contextMenuStripConstructor; }
            set { _contextMenuStripConstructor = value; }
        }
    }
}
