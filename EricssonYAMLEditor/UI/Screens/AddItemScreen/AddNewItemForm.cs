using EricssonYAMLEditor.Node.Models;
using EricssonYAMLEditor.Node.Services.Interfaces;
using EricssonYAMLEditor.Node.Services.YamlDotNet;
using EricssonYAMLEditor.Parser.Services;
using EricssonYAMLEditor.UI.Constants;
using EricssonYAMLEditor.UI.Models;
using EricssonYAMLEditor.UI.Services;
using EricssonYAMLEditor.UI.Services.Interfaces;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EricssonYAMLEditor.UI.Screens.AddItemScreen
{
    public partial class AddNewItemForm : Form
    {
        private List<object> _list;
        private AddNewItemFormParams _params;

        public AddNewItemForm()
        {
            InitializeComponent();
            InitComponent();
        }

        public AddNewItemForm(AddNewItemFormParams addNewItemFormParams): this()
        {
            _params = addNewItemFormParams;
        }

        private void InitComponent()
        {
            this.label1.Name = FormConstants.Label.CopyItemTemplateFrom.Name;
            this.label1.Text = FormConstants.Label.CopyItemTemplateFrom.Text;
            this.button1.Text = FormConstants.Button.AddNewItem.Text;
        }

        private void AddNewItemForm_Load(object sender, System.EventArgs e)
        {
            InitiateComboBox();
        }

        private void InitiateComboBox()
        {
            SetComboBoxData();
            SelectFirstItem();
        }

        private void SetComboBoxData()
        {
            List<string> comboBoxData = new List<string>();
            YamlNode yamlNode = (YamlNode) _params.TreeNode.Tag;
            _list = (List<object>)((KeyValuePair<object, object>)yamlNode.Data).Value;
            for (int i=0; i < _list.Count; i++ )
            {
                object item = _list[i];
                comboBoxData.Add(PropertyNamer.GetArrayItemPropertyName(yamlNode.Name, i));
            }
            this.comboBox1.Items.AddRange(comboBoxData.ToArray());
        }

        private void SelectFirstItem()
        {
            if (this.comboBox1.Items.Count > 0)
            {
                this.comboBox1.SelectedIndex = 0;
                this.button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            object data = PrepareData();
            YamlNode newNode = PrepareYamlNode(data);
            TreeNode treeNode = PrepareTreeNode(newNode);
            _params.TreeNode.Nodes.Add(treeNode);
            this.Close();
        }

        private object PrepareData()
        {
            int selectedIndex = this.comboBox1.SelectedIndex;
            object clonedObject = ObjectCloner.DeepClone(_list[selectedIndex]);
            _list.Add(clonedObject);
            return clonedObject;
        }

        private YamlNode PrepareYamlNode(object data)
        {
            TreeNode treeNode = _params.TreeNode;
            string parentPropertyName = treeNode.Name;
            int newItemIndex = treeNode.Nodes.Count;
            string propertyName = PropertyNamer.GetArrayItemPropertyName(parentPropertyName, newItemIndex);
            IYamlTreeBuilder<Dictionary<string, object>> yamlTreeBuilder = new YamlDotNetTreeBuilder();
            return yamlTreeBuilder.ProcessNode(propertyName, data, (YamlNode)treeNode.Tag);
        }

        private TreeNode PrepareTreeNode(YamlNode newNode)
        {
            IContextMenuStripConstructor contextMenuStripConstructor = _params.ContextMenuStripConstructor;
            TreeNode treeNode = TreeNodeService.CreateNode(newNode.Name, newNode.GetVisibleName(newNode.Name, newNode.ParentNode.Name), contextMenuStripConstructor, newNode);
            TreeNodeService.AddSubNodes(treeNode, newNode, contextMenuStripConstructor);
            return treeNode;
        }
    }
}
