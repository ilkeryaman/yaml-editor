using EricssonYAMLEditor.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EricssonYAMLEditor.UI.Services.YamlDotNet.ContextMenuStripConstructor
{
    class YamlDotNetContextMenuStripConstructor : IContextMenuStripConstructor
    {
        ContextMenuStrip _contextMenuStripWithAddRemove;
        ContextMenuStrip _contextMenuStripWithRemove;

        public YamlDotNetContextMenuStripConstructor()
        {
            _contextMenuStripWithAddRemove = GetContextMenuStripWithAddRemove();
            _contextMenuStripWithRemove = GetContextMenuStripWithRemove();
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
            toolStripMenuItem_Add.Text = "Add";
            toolStripMenuItem_Add.Click += new EventHandler(toolStripMenuItem_Add_Click);
            ToolStripMenuItem toolStripMenuItem_Remove = new ToolStripMenuItem();
            toolStripMenuItem_Remove.Text = "Remove";
            toolStripMenuItem_Remove.Click += new EventHandler(toolStripMenuItem_Remove_Click);
            contextMenuStrip.Items.AddRange(new ToolStripMenuItem[] { toolStripMenuItem_Add, toolStripMenuItem_Remove });
            return contextMenuStrip;
        }

        private ContextMenuStrip GetContextMenuStripWithRemove()
        {
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            ToolStripMenuItem toolStripMenuItem_Remove = new ToolStripMenuItem();
            toolStripMenuItem_Remove.Text = "Remove";
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
        }

        private TreeNode GetSelectedTreeNode(object sender)
        {
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
            ContextMenuStrip contextMenuStrip = (ContextMenuStrip)toolStripMenuItem.GetCurrentParent();
            TreeView treeview = (TreeView)contextMenuStrip.SourceControl;
            return treeview.SelectedNode;
        }
    }
}
