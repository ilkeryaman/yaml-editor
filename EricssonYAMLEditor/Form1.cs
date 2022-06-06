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

namespace EricssonYAMLEditor
{
    public partial class Form1 : Form
    {
        TreeNode rootNode;
        //Dictionary<string, object> yamlNodeDictionary;

        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ReadAndProcess(string filePath)
        {
            try
            {
                IYamlParser<Dictionary<string, object>> yamlParser = new YamlDotNetParser();
                Dictionary<string, object> yamlData = yamlParser.DeSerializeDocumentToClass(filePath);
                IYamlTreeBuilder<Dictionary<string, object>> yamlTreeBuilder = new YamlDotNetTreeBuilder();
                //IYamlTree2DictionaryConverter tree2dictionaryConverter = new YamlTree2DictionaryConverter();
                YamlNode rootYamlNode = yamlTreeBuilder.BuildTree(yamlData);
                RenderTreeView(rootYamlNode);
                //yamlNodeDictionary = tree2dictionaryConverter.Convert(rootYamlNode);
            }
            catch(IllegalYamlFileException exc)
            {
                ControlCreator.ShowExceptionMessage(exc.Message, ExceptionMessage.Error, this);
            }
        }

        private void RenderTreeView(YamlNode rootYamlNode)
        {
            IContextMenuStripConstructor contextMenuStripConstructor = new YamlDotNetContextMenuStripConstructor();
            rootNode = new TreeNode();
            rootNode.Name = rootYamlNode.Name;
            rootNode.Text = rootYamlNode.Name;
            rootNode.Tag = rootYamlNode;
            treeView1.Nodes.Add(rootNode);
            AddSubNodes(rootNode, rootYamlNode, contextMenuStripConstructor);
        }

        private void AddSubNodes(TreeNode parentTreeNode, YamlNode yamlNode, IContextMenuStripConstructor contextMenuStripConstructor)
        {
            foreach (YamlNode node in yamlNode.SubNodeList)
            {
                TreeNode treeNode = new TreeNode();
                treeNode.Name = node.Name;
                treeNode.Text = node.GetVisibleName(node.Name, node.ParentNode.Name);
                treeNode.Tag = node;
                treeNode.ContextMenuStrip = contextMenuStripConstructor.GetContextMenuStrip(node.Data);
                parentTreeNode.Nodes.Add(treeNode);
                AddSubNodes(treeNode, node, contextMenuStripConstructor);
            }
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
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView1.SelectedNode = e.Node;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                string key = treeView1.SelectedNode.Name;

                if (!string.IsNullOrEmpty(key))
                {
                    YamlNode yamlNode = (YamlNode) treeView1.SelectedNode.Tag;
                    DynamicPanelGenerator dynamicControlGenerator = new DynamicPanelGenerator(flowLayoutPanel1, yamlNode.Data);
                    dynamicControlGenerator.ConstructDynamicPanel(key);
                }
            }
            catch { }
        }

        #endregion Events
    }
}
