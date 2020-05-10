namespace ARCSoftFaceApp
{
    partial class UpdataFaceWinow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdataFaceWinow));
            this.ImageListView = new System.Windows.Forms.ListView();
            this.imageLists = new System.Windows.Forms.ImageList(this.components);
            this.listViewFaceDetal = new System.Windows.Forms.ListView();
            this.columnHeaderStatue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStudentId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderProcessDetal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSelectImage = new System.Windows.Forms.Button();
            this.buttonUpdateFace = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ImageListView
            // 
            this.ImageListView.Dock = System.Windows.Forms.DockStyle.Left;
            this.ImageListView.HideSelection = false;
            this.ImageListView.LargeImageList = this.imageLists;
            this.ImageListView.Location = new System.Drawing.Point(0, 0);
            this.ImageListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ImageListView.Name = "ImageListView";
            this.ImageListView.Size = new System.Drawing.Size(1261, 1474);
            this.ImageListView.TabIndex = 0;
            this.ImageListView.UseCompatibleStateImageBehavior = false;
            // 
            // imageLists
            // 
            this.imageLists.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageLists.ImageSize = new System.Drawing.Size(80, 80);
            this.imageLists.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listViewFaceDetal
            // 
            this.listViewFaceDetal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderStatue,
            this.columnHeaderStudentId,
            this.columnHeaderProcessDetal});
            this.listViewFaceDetal.Dock = System.Windows.Forms.DockStyle.Left;
            this.listViewFaceDetal.HideSelection = false;
            this.listViewFaceDetal.Location = new System.Drawing.Point(1261, 0);
            this.listViewFaceDetal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewFaceDetal.MinimumSize = new System.Drawing.Size(547, 1573);
            this.listViewFaceDetal.Name = "listViewFaceDetal";
            this.listViewFaceDetal.Size = new System.Drawing.Size(547, 1573);
            this.listViewFaceDetal.TabIndex = 1;
            this.listViewFaceDetal.UseCompatibleStateImageBehavior = false;
            this.listViewFaceDetal.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderStatue
            // 
            this.columnHeaderStatue.Text = "状态";
            // 
            // columnHeaderStudentId
            // 
            this.columnHeaderStudentId.Text = "学生ID";
            this.columnHeaderStudentId.Width = 101;
            // 
            // columnHeaderProcessDetal
            // 
            this.columnHeaderProcessDetal.Text = "执行结果";
            this.columnHeaderProcessDetal.Width = 262;
            // 
            // buttonSelectImage
            // 
            this.buttonSelectImage.Location = new System.Drawing.Point(1821, 46);
            this.buttonSelectImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSelectImage.Name = "buttonSelectImage";
            this.buttonSelectImage.Size = new System.Drawing.Size(270, 52);
            this.buttonSelectImage.TabIndex = 2;
            this.buttonSelectImage.Text = "选择照片";
            this.buttonSelectImage.UseVisualStyleBackColor = true;
            this.buttonSelectImage.Click += new System.EventHandler(this.buttonSelectImage_Click);
            // 
            // buttonUpdateFace
            // 
            this.buttonUpdateFace.Enabled = false;
            this.buttonUpdateFace.Location = new System.Drawing.Point(1822, 142);
            this.buttonUpdateFace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUpdateFace.Name = "buttonUpdateFace";
            this.buttonUpdateFace.Size = new System.Drawing.Size(270, 54);
            this.buttonUpdateFace.TabIndex = 3;
            this.buttonUpdateFace.Text = "上传特征";
            this.buttonUpdateFace.UseVisualStyleBackColor = true;
            this.buttonUpdateFace.Click += new System.EventHandler(this.buttonUpdateFace_Click);
            // 
            // UpdataFaceWinow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2109, 1474);
            this.Controls.Add(this.buttonUpdateFace);
            this.Controls.Add(this.buttonSelectImage);
            this.Controls.Add(this.listViewFaceDetal);
            this.Controls.Add(this.ImageListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "UpdataFaceWinow";
            this.Text = "更新学生人脸";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdataFaceWinow_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ImageListView;
        private System.Windows.Forms.ImageList imageLists;
        private System.Windows.Forms.ListView listViewFaceDetal;
        private System.Windows.Forms.ColumnHeader columnHeaderStudentId;
        private System.Windows.Forms.ColumnHeader columnHeaderProcessDetal;
        private System.Windows.Forms.Button buttonSelectImage;
        private System.Windows.Forms.Button buttonUpdateFace;
        private System.Windows.Forms.ColumnHeader columnHeaderStatue;
    }
}