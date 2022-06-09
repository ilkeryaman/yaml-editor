using EricssonYAMLEditor.File.Services.Interfaces;
using EricssonYAMLEditor.File.Services;
using EricssonYAMLEditor.Node.Models;
using EricssonYAMLEditor.Node.Services.Interfaces;
using EricssonYAMLEditor.Node.Services.YamlDotNet;
using EricssonYAMLEditor.Parser.Services.Interfaces;
using EricssonYAMLEditor.Parser.Services.YamlDotNet;
using EricssonYAMLEditor.UI.Constants;
using EricssonYAMLEditor.UI.Services.Interfaces;
using EricssonYAMLEditor.UI.Services;
using EricssonYAMLEditor.UI.Services.YamlDotNet.ContextMenuStripConstructor;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EricssonYAMLEditor.Exception.Constants;
using EricssonYAMLEditor.Exception.Model;
using EricssonYAMLEditor.Node.Services;
using EricssonYAMLEditor.Node.Constants;

namespace EricssonYAMLEditor
{
    public partial class Form1 : Form
    {
        PageManager pageManager;
        TreeNode rootNode;
        //Dictionary<string, object> yamlNodeDictionary;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pageManager = new PageManager(this);
        }

        public Button Button_Prev { get { return button_prev; } }
        public Button Button_Next { get { return button_next; } }
        public TreeView TreeView_Networks { get { return treeView_networks; } }
        public TreeView TreeView_Control_Plane { get { return treeView_control_plane; } }
        public TreeView TreeView_Worker_Pools { get { return treeView_worker_pools; } }
        public FlowLayoutPanel FlowLayoutPanel1 { get { return flowLayoutPanel1; } }

        private void ReadAndProcess(string filePath)
        {
            try
            {
                IYamlParser<Dictionary<string, object>> yamlParser = new YamlDotNetParser();
                Dictionary<string, object> yamlData = yamlParser.DeSerializeDocumentToClass(filePath);
                IYamlTreeBuilder<Dictionary<string, object>> yamlTreeBuilder = new YamlDotNetTreeBuilder();
                YamlNode rootYamlNode = yamlTreeBuilder.BuildTree(yamlData);
                if (RenderTreeView(rootYamlNode))
                {
                    pageManager.Reset();
                }
                //IYamlTree2DictionaryConverter tree2dictionaryConverter = new YamlTree2DictionaryConverter();
                //yamlNodeDictionary = tree2dictionaryConverter.Convert(rootYamlNode);
            }
            catch (IllegalYamlFileException exc)
            {
                ControlCreator.ShowExceptionMessage(exc.Message, ExceptionMessage.Error, this);
            }
        }

        private bool RenderTreeView(YamlNode rootYamlNode)
        {
            IContextMenuStripConstructor contextMenuStripConstructor = new YamlDotNetContextMenuStripConstructor();
            rootNode = TreeNodeService.CreateNode(rootYamlNode.Name, rootYamlNode.Name, null, rootYamlNode);
            return PrepareTreeViews(rootYamlNode, contextMenuStripConstructor);
        }

        private bool PrepareTreeViews(YamlNode rootYamlNode, IContextMenuStripConstructor contextMenuStripConstructor)
        {
            bool isValidYamlFile = true;
            try
            {
                PrepareTreeView(rootYamlNode, treeView_networks, PropertyKey.FullName.networks, contextMenuStripConstructor);
                PrepareTreeView(rootYamlNode, treeView_control_plane, PropertyKey.FullName.controlplane, contextMenuStripConstructor);
                PrepareTreeView(rootYamlNode, treeView_worker_pools, PropertyKey.FullName.worker_pools, contextMenuStripConstructor);
            }
            catch(IllegalYamlFileException exc)
            {
                isValidYamlFile = false;
                ControlCreator.ShowExceptionMessage(exc.Message, ExceptionMessage.Error, this);
            }
            return isValidYamlFile;
        }

        private void PrepareTreeView(YamlNode rootYamlNode, TreeView treeView, string propertyName, IContextMenuStripConstructor contextMenuStripConstructor)
        {
            treeView.Nodes.Clear();
            treeView.Tag = rootYamlNode;
            INodeSearcher nodeSearcher = new NodeSearcher();
            YamlNode foundNode = nodeSearcher.SearchNode(rootYamlNode, propertyName);
            if(foundNode == null)
            {
                throw new IllegalYamlFileException();
            }
            TreeNode treeNode = TreeNodeService.CreateNode(foundNode.Name, foundNode.Name, contextMenuStripConstructor, foundNode, true);
            TreeNodeService.AddSubNodes(treeNode, foundNode, contextMenuStripConstructor);
            treeView.Nodes.Add(treeNode);
            treeNode.Expand();
        }

        #region Events

        private void menuItem_OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = FormConstants.File_Filter_Text;
            if (file.ShowDialog() == DialogResult.OK)
            {
                menuItem_SaveFile.Enabled = true;
                string filePath = file.FileName;
                ReadAndProcess(filePath);
            }
        }

        private void menuItem_SaveFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = "yaml";
            saveFileDialog1.Filter = FormConstants.File_Filter_Text;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                ISerializer serializer = new YamlDotNetSerializer();
                IFileSaver<string> fileSaver = new FileSaver();
                fileSaver.Save(filePath, serializer.Serialize(((YamlNode)rootNode.Tag).Data));
            }
        }

        private void menuItem_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItem_Constraints_Click(object sender, EventArgs e)
        {
            ControlCreator.ShowInfoMessage(Notification.Constraints.Message, Notification.Constraints.Title, this);
        }

        /// <summary>
        /// This event handler works in coordination with context menu strips of tree nodes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeView treeView = (TreeView)sender;
                treeView.SelectedNode = e.Node;
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if(e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
                {
                    TreeView treeView = (TreeView)sender;
                    flowLayoutPanel1.Controls.Clear();
                    string key = treeView.SelectedNode.Name;

                    if (!string.IsNullOrEmpty(key))
                    {
                        YamlNode yamlNode = (YamlNode)treeView.SelectedNode.Tag;
                        DynamicPanelGenerator dynamicControlGenerator = new DynamicPanelGenerator(flowLayoutPanel1, yamlNode.Data);
                        dynamicControlGenerator.ConstructDynamicPanel(key);
                    }
                }
            }
            catch { }
        }

        private void button_prev_Click(object sender, EventArgs e)
        {
            pageManager.Prev();
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            pageManager.Next();
        }

        #endregion Events
    }
}
