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
            this.系统维护toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新人脸特征ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.测试模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登录IP摄像机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加载人脸特征库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除人脸特征库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxCamera = new System.Windows.Forms.GroupBox();
            this.listViewVideoChannel = new System.Windows.Forms.ListView();
            this.videoChannel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.videoName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.videoStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxLogMessage = new System.Windows.Forms.GroupBox();
            this.richTextBoxLogMessage = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanelVideoReal = new System.Windows.Forms.TableLayoutPanel();
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
            this.系统维护toolStripMenuItem,
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
            // 系统维护toolStripMenuItem
            // 
            this.系统维护toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更新人脸特征ToolStripMenuItem});
            this.系统维护toolStripMenuItem.Name = "系统维护toolStripMenuItem";
            this.系统维护toolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.系统维护toolStripMenuItem.Text = "系统维护";
            // 
            // 更新人脸特征ToolStripMenuItem
            // 
            this.更新人脸特征ToolStripMenuItem.Name = "更新人脸特征ToolStripMenuItem";
            this.更新人脸特征ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.更新人脸特征ToolStripMenuItem.Text = "更新人脸特征";
            this.更新人脸特征ToolStripMenuItem.Click += new System.EventHandler(this.更新人脸特征ToolStripMenuItem_Click);
            // 
            // 测试模式ToolStripMenuItem
            // 
            this.测试模式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.登录IP摄像机ToolStripMenuItem,
            this.加载人脸特征库ToolStripMenuItem,
            this.清除人脸特征库ToolStripMenuItem});
            this.测试模式ToolStripMenuItem.Name = "测试模式ToolStripMenuItem";
            this.测试模式ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.测试模式ToolStripMenuItem.Text = "测试模式";
            // 
            // 登录IP摄像机ToolStripMenuItem
            // 
            this.登录IP摄像机ToolStripMenuItem.Name = "登录IP摄像机ToolStripMenuItem";
            this.登录IP摄像机ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.登录IP摄像机ToolStripMenuItem.Text = "登录IP摄像机";
            this.登录IP摄像机ToolStripMenuItem.Click += new System.EventHandler(this.登录IP摄像机ToolStripMenuItem_Click);
            // 
            // 加载人脸特征库ToolStripMenuItem
            // 
            this.加载人脸特征库ToolStripMenuItem.Name = "加载人脸特征库ToolStripMenuItem";
            this.加载人脸特征库ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.加载人脸特征库ToolStripMenuItem.Text = "加载人脸特征库";
            this.加载人脸特征库ToolStripMenuItem.Click += new System.EventHandler(this.加载人脸特征库ToolStripMenuItem_Click);
            // 
            // 清除人脸特征库ToolStripMenuItem
            // 
            this.清除人脸特征库ToolStripMenuItem.Name = "清除人脸特征库ToolStripMenuItem";
            this.清除人脸特征库ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.清除人脸特征库ToolStripMenuItem.Text = "清除人脸特征库";
            this.清除人脸特征库ToolStripMenuItem.Click += new System.EventHandler(this.清除人脸特征库ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // groupBoxCamera
            // 
            this.groupBoxCamera.Controls.Add(this.listViewVideoChannel);
            this.groupBoxCamera.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxCamera.Location = new System.Drawing.Point(0, 25);
            this.groupBoxCamera.Name = "groupBoxCamera";
            this.groupBoxCamera.Size = new System.Drawing.Size(283, 425);
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
            this.listViewVideoChannel.FullRowSelect = true;
            this.listViewVideoChannel.GridLines = true;
            this.listViewVideoChannel.HideSelection = false;
            this.listViewVideoChannel.Location = new System.Drawing.Point(3, 17);
            this.listViewVideoChannel.Name = "listViewVideoChannel";
            this.listViewVideoChannel.Size = new System.Drawing.Size(277, 405);
            this.listViewVideoChannel.TabIndex = 0;
            this.listViewVideoChannel.UseCompatibleStateImageBehavior = false;
            this.listViewVideoChannel.View = System.Windows.Forms.View.Details;
            this.listViewVideoChannel.SelectedIndexChanged += new System.EventHandler(this.listViewVideoChannel_SelectedIndexChanged);
            this.listViewVideoChannel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewVideoChannel_MouseClick);
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
            this.groupBoxLogMessage.Controls.Add(this.richTextBoxLogMessage);
            this.groupBoxLogMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxLogMessage.Location = new System.Drawing.Point(283, 326);
            this.groupBoxLogMessage.Name = "groupBoxLogMessage";
            this.groupBoxLogMessage.Size = new System.Drawing.Size(517, 124);
            this.groupBoxLogMessage.TabIndex = 2;
            this.groupBoxLogMessage.TabStop = false;
            this.groupBoxLogMessage.Text = "运行信息";
            // 
            // richTextBoxLogMessage
            // 
            this.richTextBoxLogMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLogMessage.Location = new System.Drawing.Point(3, 17);
            this.richTextBoxLogMessage.Name = "richTextBoxLogMessage";
            this.richTextBoxLogMessage.ReadOnly = true;
            this.richTextBoxLogMessage.Size = new System.Drawing.Size(511, 104);
            this.richTextBoxLogMessage.TabIndex = 0;
            this.richTextBoxLogMessage.Text = "";
            // 
            // flowLayoutPanelVideoReal
            // 
            this.flowLayoutPanelVideoReal.ColumnCount = 2;
            this.flowLayoutPanelVideoReal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.flowLayoutPanelVideoReal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.flowLayoutPanelVideoReal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.flowLayoutPanelVideoReal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.flowLayoutPanelVideoReal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.flowLayoutPanelVideoReal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelVideoReal.Location = new System.Drawing.Point(283, 25);
            this.flowLayoutPanelVideoReal.Name = "flowLayoutPanelVideoReal";
            this.flowLayoutPanelVideoReal.RowCount = 2;
            this.flowLayoutPanelVideoReal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.flowLayoutPanelVideoReal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.flowLayoutPanelVideoReal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.flowLayoutPanelVideoReal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.flowLayoutPanelVideoReal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.flowLayoutPanelVideoReal.Size = new System.Drawing.Size(517, 301);
            this.flowLayoutPanelVideoReal.TabIndex = 3;
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxCamera.ResumeLayout(false);
            this.groupBoxLogMessage.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        public System.Windows.Forms.RichTextBox richTextBoxLogMessage;
        private System.Windows.Forms.ToolStripMenuItem 系统维护toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新人脸特征ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加载人脸特征库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除人脸特征库ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel flowLayoutPanelVideoReal;
    }
}