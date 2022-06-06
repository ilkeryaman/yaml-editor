using EricssonYAMLEditor.Exception.Constants;
using EricssonYAMLEditor.UI.Constants;
using System.Drawing;
using System.Windows.Forms;

namespace EricssonYAMLEditor.UI.Services
{
    class ControlCreator
    {
        public static Label CreateLabel(FlowLayoutPanel panel, string key, string text)
        {
            return CreateLabel(panel, key, text, Color.Black);
        }

        public static Label CreateLabel(FlowLayoutPanel panel, string key, string text, Color foreColor)
        {
            Label lbl = new Label();
            lbl.Name = FormConstants.Prefix.Label_Name + key;
            lbl.Text = text;
            lbl.Size = new Size(700, 15);
            lbl.Margin = new Padding(3, 10, 3, 0);
            lbl.ForeColor = foreColor;
            panel.Controls.Add(lbl);
            return lbl;
        }

        public static TextBox CreateTextBox(FlowLayoutPanel panel, string key, string value)
        {
            CreateLabel(panel, key, key);

            TextBox txtBox = new TextBox();
            txtBox.Name = FormConstants.Prefix.TextBox_Name + key;
            txtBox.Text = value;
            txtBox.Tag = key;
            txtBox.Size = new Size(700, 20);
            txtBox.Margin = new Padding(3, 1, 3, 0);
            panel.Controls.Add(txtBox);
            return txtBox;
        }

        public static TextBox CreateTextArea(FlowLayoutPanel panel, string key, string value)
        {
            CreateLabel(panel, key, key);

            TextBox txtArea = new TextBox();
            txtArea.Name = FormConstants.Prefix.TextArea_Name + key;
            txtArea.Text = string.IsNullOrEmpty(value) ? value : value.Replace("\n", "\r\n");
            txtArea.Tag = key;
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
