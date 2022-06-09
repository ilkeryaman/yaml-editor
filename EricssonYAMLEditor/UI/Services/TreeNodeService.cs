using System.Windows.Forms;
using EricssonYAMLEditor.Node.Models;
using EricssonYAMLEditor.UI.Services.Interfaces;

namespace EricssonYAMLEditor.UI.Services
{
    class TreeNodeService
    {
        public static TreeNode CreateNode(string name, string text, IContextMenuStripConstructor contextMenuStripConstructor, YamlNode node, bool isRootNode = false)
        {
            TreeNode treeNode = new TreeNode();
            treeNode.Name = name;
            treeNode.Text = text;
            treeNode.Tag = node;
            if(contextMenuStripConstructor != null)
            {
                treeNode.ContextMenuStrip = contextMenuStripConstructor.GetContextMenuStrip(node.Data, isRootNode);
            }
            return treeNode;
        }

        public static void AddSubNodes(TreeNode parentTreeNode, YamlNode yamlNode, IContextMenuStripConstructor contextMenuStripConstructor)
        {
            foreach (YamlNode node in yamlNode.SubNodeList)
            {
                TreeNode treeNode = CreateNode(node.Name, node.GetVisibleName(node.Name, node.ParentNode.Name), contextMenuStripConstructor, node);
                parentTreeNode.Nodes.Add(treeNode);
                AddSubNodes(treeNode, node, contextMenuStripConstructor);
            }
        }
    }
}
