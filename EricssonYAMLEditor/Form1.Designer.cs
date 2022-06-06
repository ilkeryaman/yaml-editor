
namespace EricssonYAMLEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuItem_File = new System.Windows.Forms.MenuItem();
            this.menuItem_OpenFile = new System.Windows.Forms.MenuItem();
            this.menuItem_SaveFile = new System.Windows.Forms.MenuItem();
            this.menuItem_HorizontalLine = new System.Windows.Forms.MenuItem();
            this.menuItem_Exit = new System.Windows.Forms.MenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // menuItem_File
            // 
            this.menuItem_File.Index = 0;
            this.menuItem_File.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_OpenFile,
            this.menuItem_SaveFile,
            this.menuItem_HorizontalLine,
            this.menuItem_Exit});
            this.menuItem_File.Text = "File";
            // 
            // menuItem_OpenFile
            // 
            this.menuItem_OpenFile.Index = 0;
            this.menuItem_OpenFile.Text = "Open";
            this.menuItem_OpenFile.Click += new System.EventHandler(this.menuItem_OpenFile_Click);
            // 
            // menuItem_SaveFile
            // 
            this.menuItem_SaveFile.Enabled = false;
            this.menuItem_SaveFile.Index = 1;
            this.menuItem_SaveFile.Text = "Save As...";
            this.menuItem_SaveFile.Click += new System.EventHandler(this.menuItem_SaveFile_Click);// 
            //
            // menuItem_HorizontalLine
            // 
            this.menuItem_HorizontalLine.Enabled = false;
            this.menuItem_HorizontalLine.Index = 2;
            this.menuItem_HorizontalLine.Text = "-";
            // 
            // menuItem_Exit
            // 
            this.menuItem_Exit.Index = 3;
            this.menuItem_Exit.Text = "Exit";
            this.menuItem_Exit.Click += new System.EventHandler(this.menuItem_Exit_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(17, 16);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(505, 614);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(532, 16);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1000, 630);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.Tag = this.treeView1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1533, 661);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.treeView1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Yaml Editor GUI";
            this.MaximizeBox = false;
            this.Menu = new System.Windows.Forms.MainMenu();
            this.Menu.MenuItems.Add(menuItem_File);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.MenuItem menuItem_File;
        private System.Windows.Forms.MenuItem menuItem_OpenFile;
        private System.Windows.Forms.MenuItem menuItem_SaveFile;
        private System.Windows.Forms.MenuItem menuItem_HorizontalLine;
        private System.Windows.Forms.MenuItem menuItem_Exit;
    }
}

