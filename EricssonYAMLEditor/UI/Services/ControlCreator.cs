using EricssonYAMLEditor.Exception.Constants;
using EricssonYAMLEditor.UI.Constants;
using EricssonYAMLEditor.UI.Screens.LoadingScreen;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EricssonYAMLEditor.UI.Services
{
    class ControlCreator
    {
        public static Label CreateLabel(FlowLayoutPanel panel, string name, string text)
        {
            return CreateLabel(panel, name, text, Color.Black);
        }

        public static Label CreateLabel(FlowLayoutPanel panel, string name, string text, Color foreColor)
        {
            Label lbl = new Label();
            lbl.Name = FormConstants.Prefix.Label_Name + name;
            lbl.Text = text;
            lbl.Size = new Size(700, 15);
            lbl.Margin = new Padding(3, 10, 3, 0);
            lbl.ForeColor = foreColor;
            panel.Controls.Add(lbl);
            return lbl;
        }

        public static TextBox CreateTextBox(FlowLayoutPanel panel, string name, string value)
        {
            CreateLabel(panel, name, name);

            TextBox txtBox = new TextBox();
            txtBox.Name = FormConstants.Prefix.TextBox_Name + name;
            txtBox.Text = value;
            txtBox.Tag = name;
            txtBox.Size = new Size(700, 20);
            txtBox.Margin = new Padding(3, 1, 3, 0);
            panel.Controls.Add(txtBox);
            return txtBox;
        }

        public static TextBox CreateTextArea(FlowLayoutPanel panel, string name, string value)
        {
            CreateLabel(panel, name, name);

            TextBox txtArea = new TextBox();
            txtArea.Name = FormConstants.Prefix.TextArea_Name + name;
            txtArea.Text = string.IsNullOrEmpty(value) ? value : value.Replace("\n", "\r\n");
            txtArea.Tag = name;
            txtArea.Multiline = true;
            txtArea.ScrollBars = ScrollBars.Vertical;
            txtArea.Size = new Size(700, 100);
            txtArea.Margin = new Padding(3, 1, 3, 0);
            panel.Controls.Add(txtArea);
            return txtArea;
        }

        public static Button CreateButton(FlowLayoutPanel panel, string name, string text, System.EventHandler onClick)
        {
            Button btn = new Button();
            btn.Name = FormConstants.Prefix.Button_Name + name;
            btn.Size = new Size(75, 25);
            btn.Text = text;
            btn.UseVisualStyleBackColor = true;
            btn.Margin = new Padding(3, 10, 3, 10);
            btn.Click += onClick;
            panel.Controls.Add(btn);
            return btn;
        }

        public static ComboBox CreateComboBox(FlowLayoutPanel panel, string name, List<string> data, string selectedData)
        {
            CreateLabel(panel, name, name);

            ComboBox comboBox = new ComboBox();
            comboBox.Name = FormConstants.Prefix.ComboBox_Name + name;
            comboBox.Size = new Size(700, 100);
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Items.AddRange(data.ToArray());
            if (data.Contains(selectedData))
            {
                comboBox.SelectedIndex = data.FindIndex(item => item.Equals(selectedData));
            }
            comboBox.Tag = name;
            panel.Controls.Add(comboBox);
            return comboBox;
        }

        public static void LoadingAnimation(int intervalMillis = 2000)
        {
            LoadingForm loadingForm = new LoadingForm(intervalMillis);
            loadingForm.ShowDialog();
        }

        public static void ShowExceptionMessage(string message, string title, IWin32Window owner = null)
        {
            if(owner == null)
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ShowImplementationError(string message)
        {
            MessageBox.Show(message, ExceptionMessage.ImplementationError, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        public static void ShowInfoMessage(string message, string title, IWin32Window owner = null)
        {
            if(owner == null)
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show(owner, message, title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
