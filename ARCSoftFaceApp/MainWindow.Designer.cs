namespace ARCSoftFaceApp
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.系统设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登录IP摄像机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxCamera = new System.Windows.Forms.GroupBox();
            this.listViewVideoChannel = new System.Windows.Forms.ListView();
            this.videoChannel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.videoName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.videoStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxLogMessage = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelVideoReal = new System.Windows.Forms.FlowLayoutPanel();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBoxCamera.SuspendLayout();
            this.groupBoxLogMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统设置ToolStripMenuItem,
            this.测试模式ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统设置ToolStripMenuItem
            // 
            this.系统设置ToolStripMenuItem.Name = "系统设置ToolStripMenuItem";
            this.系统设置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.系统设置ToolStripMenuItem.Text = "系统设置";
            // 
            // 测试模式ToolStripMenuItem
            // 
            this.测试模式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登录IP摄像机ToolStripMenuItem});
            this.测试模式ToolStripMenuItem.Name = "测试模式ToolStripMenuItem";
            this.测试模式ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.测试模式ToolStripMenuItem.Text = "测试模式";
            // 
            // 登录IP摄像机ToolStripMenuItem
            // 
            this.登录IP摄像机ToolStripMenuItem.Name = "登录IP摄像机ToolStripMenuItem";
            this.登录IP摄像机ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.登录IP摄像机ToolStripMenuItem.Text = "登录IP摄像机";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // groupBoxCamera
            // 
            this.groupBoxCamera.Controls.Add(this.listViewVideoChannel);
            this.groupBoxCamera.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxCamera.Location = new System.Drawing.Point(0, 25);
            this.groupBoxCamera.Name = "groupBoxCamera";
            this.groupBoxCamera.Size = new System.Drawing.Size(289, 425);
            this.groupBoxCamera.TabIndex = 1;
            this.groupBoxCamera.TabStop = false;
            this.groupBoxCamera.Text = "设备列表";
            // 
            // listViewVideoChannel
            // 
            this.listViewVideoChannel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.videoChannel,
            this.videoName,
            this.videoStatus});
            this.listViewVideoChannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewVideoChannel.HideSelection = false;
            this.listViewVideoChannel.Location = new System.Drawing.Point(3, 17);
            this.listViewVideoChannel.Name = "listViewVideoChannel";
            this.listViewVideoChannel.Size = new System.Drawing.Size(283, 405);
            this.listViewVideoChannel.TabIndex = 0;
            this.listViewVideoChannel.UseCompatibleStateImageBehavior = false;
            this.listViewVideoChannel.View = System.Windows.Forms.View.Details;
            this.listViewVideoChannel.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // videoChannel
            // 
            this.videoChannel.Text = "通道";
            this.videoChannel.Width = 90;
            // 
            // videoName
            // 
            this.videoName.Text = "设备名";
            this.videoName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.videoName.Width = 90;
            // 
            // videoStatus
            // 
            this.videoStatus.Text = "状态";
            this.videoStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.videoStatus.Width = 90;
            // 
            // groupBoxLogMessage
            // 
            this.groupBoxLogMessage.Controls.Add(this.textBox1);
            this.groupBoxLogMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxLogMessage.Location = new System.Drawing.Point(289, 326);
            this.groupBoxLogMessage.Name = "groupBoxLogMessage";
            this.groupBoxLogMessage.Size = new System.Drawing.Size(511, 124);
            this.groupBoxLogMessage.TabIndex = 2;
            this.groupBoxLogMessage.TabStop = false;
            this.groupBoxLogMessage.Text = "运行信息";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 17);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(505, 104);
            this.textBox1.TabIndex = 0;
            // 
            // flowLayoutPanelVideoReal
            // 
            this.flowLayoutPanelVideoReal.AutoSize = true;
            this.flowLayoutPanelVideoReal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelVideoReal.Location = new System.Drawing.Point(289, 25);
            this.flowLayoutPanelVideoReal.Name = "flowLayoutPanelVideoReal";
            this.flowLayoutPanelVideoReal.Size = new System.Drawing.Size(511, 301);
            this.flowLayoutPanelVideoReal.TabIndex = 3;
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanelVideoReal);
            this.Controls.Add(this.groupBoxLogMessage);
            this.Controls.Add(this.groupBoxCamera);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "人脸采集系统 Va0.02";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxCamera.ResumeLayout(false);
            this.groupBoxLogMessage.ResumeLayout(false);
            this.groupBoxLogMessage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 测试模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 登录IP摄像机ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBoxCamera;
        private System.Windows.Forms.ListView listViewVideoChannel;
        private System.Windows.Forms.ColumnHeader videoChannel;
        private System.Windows.Forms.ColumnHeader videoName;
        private System.Windows.Forms.ColumnHeader videoStatus;
        private System.Windows.Forms.GroupBox groupBoxLogMessage;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelVideoReal;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
    }
}