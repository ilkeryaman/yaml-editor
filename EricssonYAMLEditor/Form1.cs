using EricssonYAMLEditor.Node.Models;
using EricssonYAMLEditor.Node.Services;
using EricssonYAMLEditor.Node.Services.Interfaces;
using EricssonYAMLEditor.Node.Services.YamlDotNet;
using EricssonYAMLEditor.Parser.Services.Interfaces;
using EricssonYAMLEditor.Parser.Services.YamlDotNet;
using EricssonYAMLEditor.UI.Interfaces;
using EricssonYAMLEditor.UI.Services;
using EricssonYAMLEditor.UI.Services.YamlDotNet.ContextMenuStripConstructor;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EricssonYAMLEditor
{
    public partial class Form1 : Form
    {
        TreeNode rootNode;
        Dictionary<string, object> yamlNodeDictionary;

        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            Start();
            //Start2();
        }

        private void Start2()
        {
            Helper h = new Helper();
            h.test();
        }

        private void Start()
        {
            IYamlParser<Dictionary<string, object>> yamlParser = new YamlDotNetParser();
            object yamlData = yamlParser.DeSerializeDocumentToClass("C:\\Users\\eilkyam\\Desktop\\yamldotnet_generated\\test\\ilker2.yaml");
            IYamlTreeBuilder yamlTreeBuilder = new YamlDotNetTreeBuilder();
            IYamlTree2DictionaryConverter tree2dictionaryConverter = new YamlTree2DictionaryConverter();
            YamlNode rootYamlNode = yamlTreeBuilder.BuildTree(yamlData);
            RenderTreeView(rootYamlNode);
            yamlNodeDictionary = tree2dictionaryConverter.Convert(rootYamlNode);
        }

        private void changeIt(object yamlData)
        {
            Dictionary<string, object> a = (Dictionary<string, object>)yamlData;
            object kubernetes;
            a.TryGetValue("kubernetes", out kubernetes);
            Dictionary<object, object> kubernetes2 = (Dictionary<object, object>)kubernetes;
            kubernetes2["ip_version"] = 52222;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Helper helper = new Helper();
            helper.test3(((YamlNode)rootNode.Tag).Data);
        }
    }
}
