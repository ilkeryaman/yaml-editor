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
            lbl.Name = "lbl_" + key;
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
            txtBox.Name = "txtBox_" + key;
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
            txtArea.Name = "txtArea_" + key;
            txtArea.Text = string.IsNullOrEmpty(value) ? value : value.Replace("\n", "\r\n");
            txtArea.Tag = key;
            txtArea.Multiline = true;
            txtArea.ScrollBars = ScrollBars.Vertical;
            txtArea.Size = new Size(700, 100);
            txtArea.Margin = new Padding(3, 1, 3, 0);
            panel.Controls.Add(txtArea);
            return txtArea;
        }
    }
}
