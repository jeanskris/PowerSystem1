namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.importData = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.exportData = new System.Windows.Forms.Button();
            this.printBtn = new System.Windows.Forms.Button();
            this.manage = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.下方插入行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除整行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // importData
            // 
            this.importData.Location = new System.Drawing.Point(12, 39);
            this.importData.Name = "importData";
            this.importData.Size = new System.Drawing.Size(133, 54);
            this.importData.TabIndex = 0;
            this.importData.Text = "导入数据";
            this.importData.UseVisualStyleBackColor = true;
            this.importData.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1051, 461);
            this.dataGridView1.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // exportData
            // 
            this.exportData.Location = new System.Drawing.Point(218, 39);
            this.exportData.Name = "exportData";
            this.exportData.Size = new System.Drawing.Size(148, 54);
            this.exportData.TabIndex = 2;
            this.exportData.Text = "导出数据";
            this.exportData.UseVisualStyleBackColor = true;
            this.exportData.Click += new System.EventHandler(this.exportData_Click);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(463, 39);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(158, 54);
            this.printBtn.TabIndex = 3;
            this.printBtn.Text = "一键打印";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_click);
            // 
            // manage
            // 
            this.manage.Location = new System.Drawing.Point(727, 50);
            this.manage.Name = "manage";
            this.manage.Size = new System.Drawing.Size(75, 23);
            this.manage.TabIndex = 4;
            this.manage.Text = "配置与管理";
            this.manage.UseVisualStyleBackColor = true;
            this.manage.Click += new System.EventHandler(this.manageBtn_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(1, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1083, 501);
            this.panel1.TabIndex = 5;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.下方插入行ToolStripMenuItem,
            this.删除整行ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 48);
            // 
            // 下方插入行ToolStripMenuItem
            // 
            this.下方插入行ToolStripMenuItem.Name = "下方插入行ToolStripMenuItem";
            this.下方插入行ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.下方插入行ToolStripMenuItem.Text = "下方插入行";
            // 
            // 删除整行ToolStripMenuItem
            // 
            this.删除整行ToolStripMenuItem.Name = "删除整行ToolStripMenuItem";
            this.删除整行ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.删除整行ToolStripMenuItem.Text = "删除整行";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 583);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.manage);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.exportData);
            this.Controls.Add(this.importData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button importData;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button exportData;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button manage;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 下方插入行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除整行ToolStripMenuItem;
    }
}

