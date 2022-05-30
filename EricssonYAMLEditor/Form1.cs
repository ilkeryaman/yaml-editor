using EricssonYAMLEditor.Node.Models;
using EricssonYAMLEditor.Node.Services;
using EricssonYAMLEditor.Node.Services.Interfaces;
using EricssonYAMLEditor.Node.Services.YamlDotNet;
using EricssonYAMLEditor.Parser.Services;
using EricssonYAMLEditor.Parser.Services.Interfaces;
using EricssonYAMLEditor.Parser.Services.YamlDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EricssonYAMLEditor
{
    public partial class Form1 : Form
    {
        TreeNode rootNode;
        YamlNode rrNode;
        List<TextBox> textBoxList;
        Dictionary<string, object> yamlNodeDictionary;

        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            //Start();
            Start2();
        }

        private void Start2()
        {
            Helper h = new EricssonYAMLEditor.Helper();
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
                textBoxList = new List<TextBox>();
                string key = treeView1.SelectedNode.Name;

                if (!string.IsNullOrEmpty(key))
                {
                    YamlNode yamlNode = (YamlNode) treeView1.SelectedNode.Tag;
                    ConstructDynamicPanel(key, yamlNode.Data, true);
                }
            }
            catch { }
        }

        private void ConstructDynamicPanel(string key, object data, bool isFromFirstLevelParent = false)
        {
            if (data is KeyValuePair<string, object>)
            {
                KeyValuePair<string, object> kvpData = (KeyValuePair<string, object>) data;
                if (kvpData.Value is string)
                {
                    CreateTextBox(key, Convert.ToString(kvpData.Value));
                }
                else if(kvpData.Value is Dictionary<object, object>)
                {
                    ConstructDynamicPanel(key, kvpData.Value);
                }
            }
            else if (data is KeyValuePair<object, object>)
            {
                KeyValuePair<object, object> kvpData = (KeyValuePair<object, object>) data;
                if (kvpData.Value is string)
                {
                    CreateTextBox(key, Convert.ToString(kvpData.Value));
                }
                else if (kvpData.Value is KeyValuePair<object, object>)
                {

                }
                else if(kvpData.Value is List<object>)
                {
                    List<object> objKvpData = (List<object>) kvpData.Value;

                    bool listWithKeyValuePair = false;

                    for (int i = 0; i < objKvpData.Count; i++)
                    {
                        object item = objKvpData[i];
                        /// It is difficult to manage list objects when render it recursively, so there should be a constraint here to show when clicked from first level parent
                        /// When first level parent clicked, component will be shown; when upper level parents are clicked, it will not be shown.
                        if (isFromFirstLevelParent && item is string)
                        {
                            ConstructDynamicPanel(PropertyNamer.GetArrayItemPropertyName(key, i), item);
                        }
                        else
                        {
                            listWithKeyValuePair = true;
                            break;
                        }
                    }

                    if (listWithKeyValuePair)
                    {
                        CreateLabel(key, key + " ====== [List (" + objKvpData.Count + " items)]");
                    }
                }
            }
            else if (data is Dictionary<object, object>)
            {
                Dictionary<object, object> dictData = (Dictionary<object, object>) data;
                foreach(var entry in dictData)
                {
                    ConstructDynamicPanel(PropertyNamer.GetInnerPropertyName(key, Convert.ToString(entry.Key)), entry);
                }
            }
            else if (data is string)
            {
                CreateTextBox(key, Convert.ToString(data));
            }
        }

        private void CreateLabel(string key, string text)
        {
            Label lbl = new Label();
            lbl.Name = "lbl_" + key;
            lbl.Text = text;
            lbl.Size = new Size(300, 15);
            lbl.Margin = new Padding(3, 10, 3, 0);
            flowLayoutPanel1.Controls.Add(lbl);
        }

        private void CreateTextBox(string key, string value)
        {
            CreateLabel(key, key);

            TextBox txtBox = new TextBox();
            txtBox.Name = "txtBox_" + key;
            txtBox.Text = value;
            txtBox.Tag = key;
            txtBox.Size = new Size(300, 20);
            txtBox.Margin = new Padding(3, 1, 3, 0);
            textBoxList.Add(txtBox);
            flowLayoutPanel1.Controls.Add(txtBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            changeIt(rrNode.Data);
            Helper h = new EricssonYAMLEditor.Helper();
            h.test2(rrNode.Data);
        }
    }
}
