
namespace YAMLEditor
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
            this.menuItem_About = new System.Windows.Forms.MenuItem();
            this.menuItem_Constraints = new System.Windows.Forms.MenuItem();
            this.treeView_networks = new System.Windows.Forms.TreeView();
            this.treeView_control_plane = new System.Windows.Forms.TreeView();
            this.treeView_worker_pools = new System.Windows.Forms.TreeView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button_prev = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
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
            this.menuItem_SaveFile.Click += new System.EventHandler(this.menuItem_SaveFile_Click);
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
            // menuItem_About
            // 
            this.menuItem_About.Index = 1;
            this.menuItem_About.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_Constraints});
            this.menuItem_About.Text = "About";
            // 
            // menuItem_Constraints
            // 
            this.menuItem_Constraints.Index = 0;
            this.menuItem_Constraints.Text = "Constraints...";
            this.menuItem_Constraints.Click += new System.EventHandler(this.menuItem_Constraints_Click);
            // 
            // treeView_networks
            // 
            this.treeView_networks.Location = new System.Drawing.Point(13, 13);
            this.treeView_networks.Name = "treeView_networks";
            this.treeView_networks.Size = new System.Drawing.Size(380, 500);
            this.treeView_networks.TabIndex = 0;
            this.treeView_networks.Visible = false;
            this.treeView_networks.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView_networks.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // treeView_control_plane
            // 
            this.treeView_control_plane.Location = new System.Drawing.Point(13, 13);
            this.treeView_control_plane.Name = "treeView_control_plane";
            this.treeView_control_plane.Size = new System.Drawing.Size(380, 500);
            this.treeView_control_plane.TabIndex = 2;
            this.treeView_control_plane.Visible = false;
            this.treeView_control_plane.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView_control_plane.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // treeView_worker_pools
            // 
            this.treeView_worker_pools.Location = new System.Drawing.Point(13, 13);
            this.treeView_worker_pools.Name = "treeView_worker_pools";
            this.treeView_worker_pools.Size = new System.Drawing.Size(380, 500);
            this.treeView_worker_pools.TabIndex = 3;
            this.treeView_worker_pools.Visible = false;
            this.treeView_worker_pools.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.treeView_worker_pools.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(399, 13);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(750, 500);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // button_prev
            // 
            this.button_prev.Location = new System.Drawing.Point(845, 535);
            this.button_prev.Name = "button_prev";
            this.button_prev.Size = new System.Drawing.Size(140, 23);
            this.button_prev.TabIndex = 4;
            this.button_prev.Text = "<< Prev";
            this.button_prev.UseVisualStyleBackColor = true;
            this.button_prev.Click += new System.EventHandler(this.button_prev_Click);
            this.button_prev.Visible = false;
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(990, 535);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(140, 23);
            this.button_next.TabIndex = 5;
            this.button_next.Text = "Next >>";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            this.button_next.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 570);
            this.Controls.Add(this.button_prev);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.treeView_networks);
            this.Controls.Add(this.treeView_control_plane);
            this.Controls.Add(this.treeView_worker_pools);
            this.MaximizeBox = false;
            this.Menu = new System.Windows.Forms.MainMenu();
            this.Menu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { menuItem_File, menuItem_About });
            this.Name = "Form1";
            this.Text = "Yaml Editor GUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_networks;
        private System.Windows.Forms.TreeView treeView_control_plane;
        private System.Windows.Forms.TreeView treeView_worker_pools;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.MenuItem menuItem_File;
        private System.Windows.Forms.MenuItem menuItem_OpenFile;
        private System.Windows.Forms.MenuItem menuItem_SaveFile;
        private System.Windows.Forms.MenuItem menuItem_HorizontalLine;
        private System.Windows.Forms.MenuItem menuItem_Exit;
        private System.Windows.Forms.MenuItem menuItem_About;
        private System.Windows.Forms.MenuItem menuItem_Constraints;
        private System.Windows.Forms.Button button_prev;
        private System.Windows.Forms.Button button_next;
    }
}

