
namespace ChuongChat
{
    partial class Server
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Gửi Tất Cả");
            this.txbMessage = new System.Windows.Forms.TextBox();
            this.lsvMessage = new System.Windows.Forms.ListView();
            this.image1 = new System.Windows.Forms.ImageList();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.listView1 = new System.Windows.Forms.ListView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xoatnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chuyểnTiếpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnanh = new System.Windows.Forms.Button();
            this.btnicon = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbMessage
            // 
            this.txbMessage.Location = new System.Drawing.Point(6, 330);
            this.txbMessage.Margin = new System.Windows.Forms.Padding(4);
            this.txbMessage.Multiline = true;
            this.txbMessage.Name = "txbMessage";
            this.txbMessage.Size = new System.Drawing.Size(331, 51);
            this.txbMessage.TabIndex = 6;
            // 
            // lsvMessage
            // 
            this.lsvMessage.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvMessage.HideSelection = false;
            this.lsvMessage.Location = new System.Drawing.Point(6, 4);
            this.lsvMessage.Margin = new System.Windows.Forms.Padding(4);
            this.lsvMessage.Name = "lsvMessage";
            this.lsvMessage.Size = new System.Drawing.Size(561, 251);
            this.lsvMessage.SmallImageList = this.image1;
            this.lsvMessage.TabIndex = 4;
            this.lsvMessage.TileSize = new System.Drawing.Size(228, 36);
            this.lsvMessage.UseCompatibleStateImageBehavior = false;
            this.lsvMessage.View = System.Windows.Forms.View.SmallIcon;
            this.lsvMessage.VirtualListSize = 50;
            // 
            // image1
            // 
            this.image1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.image1.ImageSize = new System.Drawing.Size(80, 80);
            this.image1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 262);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(561, 61);
            this.listView1.TabIndex = 11;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(590, 27);
            this.treeView1.Name = "treeView1";
            treeNode1.Checked = true;
            treeNode1.Name = "Node0";
            treeNode1.Text = "Gửi Tất Cả";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(189, 106);
            this.treeView1.TabIndex = 12;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Beige;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(590, 136);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(280, 28);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xoatnToolStripMenuItem,
            this.chuyểnTiếpToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Image = global::ChuongChat.Properties.Resources.settings;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.fileToolStripMenuItem.Text = "Chức Năng";
            // 
            // xoatnToolStripMenuItem
            // 
            this.xoatnToolStripMenuItem.Name = "xoatnToolStripMenuItem";
            this.xoatnToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.xoatnToolStripMenuItem.Text = "Xóa ";
            this.xoatnToolStripMenuItem.Click += new System.EventHandler(this.xoatnToolStripMenuItem_Click);
            // 
            // chuyểnTiếpToolStripMenuItem
            // 
            this.chuyểnTiếpToolStripMenuItem.Name = "chuyểnTiếpToolStripMenuItem";
            this.chuyểnTiếpToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.chuyểnTiếpToolStripMenuItem.Text = "Chuyển Tiếp TN";
            // 
            // btnanh
            // 
            this.btnanh.BackgroundImage = global::ChuongChat.Properties.Resources.image_gallery;
            this.btnanh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnanh.Location = new System.Drawing.Point(503, 331);
            this.btnanh.Margin = new System.Windows.Forms.Padding(4);
            this.btnanh.Name = "btnanh";
            this.btnanh.Size = new System.Drawing.Size(64, 50);
            this.btnanh.TabIndex = 9;
            this.btnanh.UseVisualStyleBackColor = true;
            this.btnanh.Click += new System.EventHandler(this.btnanh_Click);
            // 
            // btnicon
            // 
            this.btnicon.BackgroundImage = global::ChuongChat.Properties.Resources.smile__1_;
            this.btnicon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnicon.Location = new System.Drawing.Point(424, 331);
            this.btnicon.Margin = new System.Windows.Forms.Padding(4);
            this.btnicon.Name = "btnicon";
            this.btnicon.Size = new System.Drawing.Size(61, 50);
            this.btnicon.TabIndex = 8;
            this.btnicon.UseVisualStyleBackColor = true;
            this.btnicon.Click += new System.EventHandler(this.btnIcon_Click);
            // 
            // btnSend
            // 
            this.btnSend.BackgroundImage = global::ChuongChat.Properties.Resources.send__1_;
            this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSend.Location = new System.Drawing.Point(345, 331);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(62, 50);
            this.btnSend.TabIndex = 4;
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(872, 525);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnanh);
            this.Controls.Add(this.btnicon);
            this.Controls.Add(this.txbMessage);
            this.Controls.Add(this.lsvMessage);
            this.Controls.Add(this.btnSend);
            this.Name = "Server";
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbMessage;
        private System.Windows.Forms.ListView lsvMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnicon;
        private System.Windows.Forms.Button btnanh;
        private System.Windows.Forms.ImageList image1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xoatnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chuyểnTiếpToolStripMenuItem;
    }
}

