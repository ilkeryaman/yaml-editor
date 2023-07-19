using YAMLEditor.ContentEditor.Model;
using YAMLEditor.ContentEditor.Services.Interfaces;
using YAMLEditor.ContentEditor.Services.YamlDotNet;
using YAMLEditor.Exception.Constants;
using YAMLEditor.Node.Models;
using YAMLEditor.Node.Services.Interfaces;
using YAMLEditor.Node.Services.YamlDotNet;
using YAMLEditor.UI.Constants;
using YAMLEditor.UI.Models;
using YAMLEditor.UI.Screens.AddItemScreen;
using YAMLEditor.UI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace YAMLEditor.UI.Services.YamlDotNet.ContextMenuStripConstructor
{
    class YamlDotNetContextMenuStripConstructor : IContextMenuStripConstructor
    {
        ContextMenuStrip _contextMenuStripWithAdd;
        ContextMenuStrip _contextMenuStripWithRemove;
        ContextMenuStrip _contextMenuStripWithAddRemove;
        IYamlTreeBuilder<Dictionary<string, object>> _treeBuilder;

        public YamlDotNetContextMenuStripConstructor()
        {
            _contextMenuStripWithAdd = GetContextMenuStripWithAdd();
            _contextMenuStripWithRemove = GetContextMenuStripWithRemove();
            _contextMenuStripWithAddRemove = GetContextMenuStripWithAddRemove();
            _treeBuilder = new YamlDotNetTreeBuilder();
        }

        public ContextMenuStrip GetContextMenuStrip(object data, bool isRootNode = false)
        {
            if(data is KeyValuePair<string, object>)
            {
                return ((KeyValuePair<string, object>)data).Value is List<object> ? (isRootNode ? _contextMenuStripWithAdd : _contextMenuStripWithAddRemove) : _contextMenuStripWithRemove;
            }
            else if(data is KeyValuePair<object, object>)
            {
                return ((KeyValuePair<object, object>)data).Value is List<object> ? (isRootNode ? _contextMenuStripWithAdd : _contextMenuStripWithAddRemove) : _contextMenuStripWithRemove;
            }
            else if (data is Dictionary<object, object>)
            {
                return _contextMenuStripWithRemove;
            }
            else if (data is List<object>)
            {
                // I believe that there can not be such scenario.
            }
            else if (data is string)
            {
                return _contextMenuStripWithRemove;
            }
            return null;
        }

        private ContextMenuStrip GetContextMenuStripWithAdd()
        {
            return GetContextMenuStrip(true, false);
        }

        private ContextMenuStrip GetContextMenuStripWithRemove()
        {
            return GetContextMenuStrip(false, true);
        }

        private ContextMenuStrip GetContextMenuStripWithAddRemove()
        {
            return GetContextMenuStrip(true, true);
        }

        private ContextMenuStrip GetContextMenuStrip(bool hasAddMenuItem, bool hasRemoveMenuItem)
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            List<ToolStripMenuItem> toolStripMenuItemList = new List<ToolStripMenuItem>();
            if (hasAddMenuItem)
            {
                ToolStripMenuItem toolStripMenuItem_Add = new ToolStripMenuItem();
                toolStripMenuItem_Add.Text = FormConstants.ToolStripMenuItem.Add.Text;
                toolStripMenuItem_Add.Click += new EventHandler(toolStripMenuItem_Add_Click);
                toolStripMenuItemList.Add(toolStripMenuItem_Add);
            }
            if (hasRemoveMenuItem)
            {
                ToolStripMenuItem toolStripMenuItem_Remove = new ToolStripMenuItem();
                toolStripMenuItem_Remove.Text = FormConstants.ToolStripMenuItem.Remove.Text;
                toolStripMenuItem_Remove.Click += new EventHandler(toolStripMenuItem_Remove_Click);
                toolStripMenuItemList.Add(toolStripMenuItem_Remove);
            }
            contextMenuStrip.Items.AddRange(toolStripMenuItemList.ToArray());
            return contextMenuStrip;
        }
        

        private void toolStripMenuItem_Add_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = GetSelectedTreeNode(sender);
            AddNewItemForm addNewItemForm = new AddNewItemForm(new AddNewItemFormParams() { TreeNode = selectedNode, ContextMenuStripConstructor = this });
            DialogResult dg = addNewItemForm.ShowDialog();
        }

        private void toolStripMenuItem_Remove_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = GetSelectedTreeNode(sender);
            YamlNode yamlNode = (YamlNode)selectedNode.Tag;
            ContentEditorResult result = RemoveDataContent(yamlNode);
            if (result.IsSucceded)
            {
                RemoveYamlNode(yamlNode);
                RemoveTreeNode(selectedNode, selectedNode.Parent, yamlNode);
            }
            else
            {
                ControlCreator.ShowImplementationError(result.Exception.Message);
            }
        }

        private TreeNode GetSelectedTreeNode(object sender)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.GetCurrentParent();
            TreeView treeview = (TreeView)contextMenuStrip.SourceControl;
            return treeview.SelectedNode;
        }

        private ContentEditorResult RemoveDataContent(YamlNode yamlNode)
        {
            IContentRemover contentRemover = new YamlDotNetContentRemover();
            return contentRemover.RemoveContent(yamlNode);
        }

        private void RemoveYamlNode(YamlNode yamlNode)
        {
            yamlNode.Remove();
        }

        private void RemoveTreeNode(TreeNode treeNode, TreeNode parentNode, YamlNode yamlNode)
        {
            treeNode.Remove();
            if (yamlNode.IsItemOfListNode())
            {
                _treeBuilder.UpdateListNode(yamlNode);
                UpdateTreeNodes(parentNode);
            }
        }

        private void UpdateTreeNodes(TreeNode parentNode)
        {
            foreach(TreeNode treeNode in parentNode.Nodes)
            {
                YamlNode node = (YamlNode) treeNode.Tag;
                treeNode.Name = node.Name;
                treeNode.Text = node.GetVisibleName(node.Name, node.ParentNode.Name);
            }
        }
    }
}
