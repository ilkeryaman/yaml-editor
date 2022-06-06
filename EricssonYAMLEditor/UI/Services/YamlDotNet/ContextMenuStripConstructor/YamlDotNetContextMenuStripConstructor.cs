using EricssonYAMLEditor.ContentEditor.Model;
using EricssonYAMLEditor.ContentEditor.Services.Interfaces;
using EricssonYAMLEditor.ContentEditor.Services.YamlDotNet;
using EricssonYAMLEditor.Exception.Constants;
using EricssonYAMLEditor.Node.Models;
using EricssonYAMLEditor.Node.Services.Interfaces;
using EricssonYAMLEditor.Node.Services.YamlDotNet;
using EricssonYAMLEditor.UI.Constants;
using EricssonYAMLEditor.UI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EricssonYAMLEditor.UI.Services.YamlDotNet.ContextMenuStripConstructor
{
    class YamlDotNetContextMenuStripConstructor : IContextMenuStripConstructor
    {
        ContextMenuStrip _contextMenuStripWithAddRemove;
        ContextMenuStrip _contextMenuStripWithRemove;
        IYamlTreeBuilder<Dictionary<string, object>> _treeBuilder;

        public YamlDotNetContextMenuStripConstructor()
        {
            _contextMenuStripWithAddRemove = GetContextMenuStripWithAddRemove();
            _contextMenuStripWithRemove = GetContextMenuStripWithRemove();
            _treeBuilder = new YamlDotNetTreeBuilder();
        }

        public ContextMenuStrip GetContextMenuStrip(object data)
        {
            if(data is KeyValuePair<string, object>)
            {
                return ((KeyValuePair<string, object>)data).Value is List<object> ? _contextMenuStripWithAddRemove : _contextMenuStripWithRemove;
            }
            else if(data is KeyValuePair<object, object>)
            {
                return ((KeyValuePair<object, object>)data).Value is List<object> ? _contextMenuStripWithAddRemove : _contextMenuStripWithRemove;
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

        private ContextMenuStrip GetContextMenuStripWithAddRemove()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem toolStripMenuItem_Add = new ToolStripMenuItem();
            toolStripMenuItem_Add.Text = FormConstants.ToolStripMenuItem.Add.Text;
            toolStripMenuItem_Add.Click += new EventHandler(toolStripMenuItem_Add_Click);
            ToolStripMenuItem toolStripMenuItem_Remove = new ToolStripMenuItem();
            toolStripMenuItem_Remove.Text = FormConstants.ToolStripMenuItem.Remove.Text;
            toolStripMenuItem_Remove.Click += new EventHandler(toolStripMenuItem_Remove_Click);
            contextMenuStrip.Items.AddRange(new ToolStripMenuItem[] { toolStripMenuItem_Add, toolStripMenuItem_Remove });
            return contextMenuStrip;
        }

        private ContextMenuStrip GetContextMenuStripWithRemove()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem toolStripMenuItem_Remove = new ToolStripMenuItem();
            toolStripMenuItem_Remove.Text = FormConstants.ToolStripMenuItem.Remove.Text;
            toolStripMenuItem_Remove.Click += new EventHandler(toolStripMenuItem_Remove_Click);
            contextMenuStrip.Items.AddRange(new ToolStripMenuItem[] { toolStripMenuItem_Remove });
            return contextMenuStrip;
        }

        private void toolStripMenuItem_Add_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = GetSelectedTreeNode(sender);
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
