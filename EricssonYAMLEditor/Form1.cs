using EricssonYAMLEditor.Node.Models;
using EricssonYAMLEditor.Node.Services;
using EricssonYAMLEditor.Node.Services.Interfaces;
using EricssonYAMLEditor.Node.Services.YamlDotNet;
using EricssonYAMLEditor.Parser.Services.Interfaces;
using EricssonYAMLEditor.Parser.Services.YamlDotNet;
using EricssonYAMLEditor.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EricssonYAMLEditor
{
    public partial class Form1 : Form
    {
        TreeNode rootNode;
        YamlNode rrNode;
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
            object yamlData = yamlParser.DeSerializeDocumentToClass("C:\\Users\\eilkyam\\Desktop\\ilker2.yaml");
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
            rootNode = new TreeNode();
            rootNode.Name = rootYamlNode.Name;
            rootNode.Text = rootYamlNode.Name;
            rootNode.Tag = rootYamlNode.Name;
            treeView1.Nodes.Add(rootNode);
            AddSubNodes(rootNode, rootYamlNode);
        }

        private void AddSubNodes(TreeNode parentTreeNode, YamlNode yamlNode)
        {
            foreach (YamlNode node in yamlNode.SubNodeList)
            {
                TreeNode treeNode = new TreeNode();
                treeNode.Name = node.Name;
                treeNode.Text = node.GetVisibleName(node.Name, node.ParentNode.Name);
                treeNode.Tag = node;
                parentTreeNode.Nodes.Add(treeNode);
                AddSubNodes(treeNode, node);
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

            changeIt(rrNode.Data);
            Helper h = new Helper();
            h.test2(rrNode.Data);
        }
    }
}
