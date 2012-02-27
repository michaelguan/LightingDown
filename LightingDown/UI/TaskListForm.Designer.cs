namespace LightingDown.UI
{
    partial class TaskListForm
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.columnModel = new XPTable.Models.ColumnModel();
            this.StateimageColumn = new XPTable.Models.ImageColumn();
            this.FileNameimageColumn = new XPTable.Models.ImageColumn();
            this.progressBarColumn = new XPTable.Models.ProgressBarColumn();
            this.RatetextColumn = new XPTable.Models.TextColumn();
            this.DownloadedSize = new XPTable.Models.TextColumn();
            this.FileSizetextColumn = new XPTable.Models.TextColumn();
            this.LeftTimetextColumn = new XPTable.Models.TextColumn();
            this.FileTypeNametextColumn = new XPTable.Models.TextColumn();
            this.tableModel = new XPTable.Models.TableModel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tasktable = new XPTable.Models.Table();
            this.TaskMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.暂停PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.全部开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部暂停ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.清除完成任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.taskTextBox = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.threadTextBox = new System.Windows.Forms.RichTextBox();
            this.threadMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清除记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.linkTextBox = new System.Windows.Forms.RichTextBox();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tasktable)).BeginInit();
            this.TaskMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.threadMenu.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnModel
            // 
            this.columnModel.Columns.AddRange(new XPTable.Models.Column[] {
            this.StateimageColumn,
            this.FileNameimageColumn,
            this.progressBarColumn,
            this.RatetextColumn,
            this.DownloadedSize,
            this.FileSizetextColumn,
            this.LeftTimetextColumn,
            this.FileTypeNametextColumn});
            // 
            // StateimageColumn
            // 
            this.StateimageColumn.Alignment = XPTable.Models.ColumnAlignment.Center;
            this.StateimageColumn.Text = "状态";
            this.StateimageColumn.Width = 35;
            // 
            // FileNameimageColumn
            // 
            this.FileNameimageColumn.Text = "文件名称";
            this.FileNameimageColumn.Width = 200;
            // 
            // progressBarColumn
            // 
            this.progressBarColumn.Text = "进度";
            this.progressBarColumn.Width = 100;
            // 
            // RatetextColumn
            // 
            this.RatetextColumn.Editable = false;
            this.RatetextColumn.Text = "速度";
            this.RatetextColumn.Width = 80;
            // 
            // DownloadedSize
            // 
            this.DownloadedSize.Editable = false;
            this.DownloadedSize.Text = "已下载";
            this.DownloadedSize.Width = 80;
            // 
            // FileSizetextColumn
            // 
            this.FileSizetextColumn.Editable = false;
            this.FileSizetextColumn.Text = "文件大小";
            this.FileSizetextColumn.Width = 80;
            // 
            // LeftTimetextColumn
            // 
            this.LeftTimetextColumn.Editable = false;
            this.LeftTimetextColumn.Text = "剩余时间";
            this.LeftTimetextColumn.Width = 80;
            // 
            // FileTypeNametextColumn
            // 
            this.FileTypeNametextColumn.Editable = false;
            this.FileTypeNametextColumn.Text = "文件类型";
            this.FileTypeNametextColumn.Width = 160;
            // 
            // tableModel
            // 
            this.tableModel.RowHeight = 20;
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tasktable);
            this.splitContainer.Panel1MinSize = 100;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer.Panel2MinSize = 50;
            this.splitContainer.Size = new System.Drawing.Size(819, 419);
            this.splitContainer.SplitterDistance = 270;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 1;
            // 
            // tasktable
            // 
            this.tasktable.ColumnModel = this.columnModel;
            this.tasktable.ContextMenuStrip = this.TaskMenuStrip;
            this.tasktable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tasktable.FullRowSelect = true;
            this.tasktable.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.tasktable.GridLines = XPTable.Models.GridLines.Both;
            this.tasktable.Location = new System.Drawing.Point(0, 0);
            this.tasktable.MultiSelect = true;
            this.tasktable.Name = "tasktable";
            this.tasktable.NoItemsText = "";
            this.tasktable.SelectionBackColor = System.Drawing.Color.Teal;
            this.tasktable.Size = new System.Drawing.Size(819, 270);
            this.tasktable.TabIndex = 1;
            this.tasktable.TableModel = this.tableModel;
            this.tasktable.UnfocusedSelectionBackColor = System.Drawing.Color.SkyBlue;
            this.tasktable.CellDoubleClick += new XPTable.Events.CellMouseEventHandler(this.tasktable_CellDoubleClick);
            this.tasktable.SelectionChanged += new XPTable.Events.SelectionEventHandler(this.tasktable_SelectionChanged);
            // 
            // TaskMenuStrip
            // 
            this.TaskMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.暂停PToolStripMenuItem,
            this.删除DToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripSeparator1,
            this.全部开始ToolStripMenuItem,
            this.全部暂停ToolStripMenuItem,
            this.全部删除ToolStripMenuItem,
            this.toolStripSeparator2,
            this.清除完成任务ToolStripMenuItem});
            this.TaskMenuStrip.Name = "TaskMenuStrip";
            this.TaskMenuStrip.Size = new System.Drawing.Size(166, 220);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItem1.Text = "开始(&S)";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.Start_Click);
            // 
            // 暂停PToolStripMenuItem
            // 
            this.暂停PToolStripMenuItem.Name = "暂停PToolStripMenuItem";
            this.暂停PToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.暂停PToolStripMenuItem.Text = "暂停(&P)";
            this.暂停PToolStripMenuItem.Click += new System.EventHandler(this.Pause_Click);
            // 
            // 删除DToolStripMenuItem
            // 
            this.删除DToolStripMenuItem.Name = "删除DToolStripMenuItem";
            this.删除DToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.删除DToolStripMenuItem.Text = "删除(&D)";
            this.删除DToolStripMenuItem.Click += new System.EventHandler(this.Remove_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(162, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItem2.Text = "打开文件夹";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.OpenDirectory_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItem3.Text = "复制URL到剪贴板";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // 全部开始ToolStripMenuItem
            // 
            this.全部开始ToolStripMenuItem.Name = "全部开始ToolStripMenuItem";
            this.全部开始ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.全部开始ToolStripMenuItem.Text = "全部开始";
            this.全部开始ToolStripMenuItem.Click += new System.EventHandler(this.StartAll_Click);
            // 
            // 全部暂停ToolStripMenuItem
            // 
            this.全部暂停ToolStripMenuItem.Name = "全部暂停ToolStripMenuItem";
            this.全部暂停ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.全部暂停ToolStripMenuItem.Text = "全部暂停";
            this.全部暂停ToolStripMenuItem.Click += new System.EventHandler(this.PauseAll_Click);
            // 
            // 全部删除ToolStripMenuItem
            // 
            this.全部删除ToolStripMenuItem.Name = "全部删除ToolStripMenuItem";
            this.全部删除ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.全部删除ToolStripMenuItem.Text = "全部删除";
            this.全部删除ToolStripMenuItem.Click += new System.EventHandler(this.RemoveAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // 清除完成任务ToolStripMenuItem
            // 
            this.清除完成任务ToolStripMenuItem.Name = "清除完成任务ToolStripMenuItem";
            this.清除完成任务ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.清除完成任务ToolStripMenuItem.Text = "清除完成任务";
            this.清除完成任务ToolStripMenuItem.Click += new System.EventHandler(this.Clear_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(819, 144);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.taskTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(811, 119);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "任务信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // taskTextBox
            // 
            this.taskTextBox.BackColor = System.Drawing.Color.White;
            this.taskTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.taskTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.taskTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskTextBox.Location = new System.Drawing.Point(3, 3);
            this.taskTextBox.Name = "taskTextBox";
            this.taskTextBox.ReadOnly = true;
            this.taskTextBox.Size = new System.Drawing.Size(805, 113);
            this.taskTextBox.TabIndex = 0;
            this.taskTextBox.Text = "";
            this.taskTextBox.WordWrap = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.threadTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(811, 119);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "线程信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // threadTextBox
            // 
            this.threadTextBox.BackColor = System.Drawing.Color.White;
            this.threadTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.threadTextBox.ContextMenuStrip = this.threadMenu;
            this.threadTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.threadTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.threadTextBox.Location = new System.Drawing.Point(3, 3);
            this.threadTextBox.Name = "threadTextBox";
            this.threadTextBox.ReadOnly = true;
            this.threadTextBox.Size = new System.Drawing.Size(805, 113);
            this.threadTextBox.TabIndex = 0;
            this.threadTextBox.Text = "";
            this.threadTextBox.WordWrap = false;
            // 
            // threadMenu
            // 
            this.threadMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清除记录ToolStripMenuItem});
            this.threadMenu.Name = "threadMenu";
            this.threadMenu.Size = new System.Drawing.Size(123, 26);
            // 
            // 清除记录ToolStripMenuItem
            // 
            this.清除记录ToolStripMenuItem.Name = "清除记录ToolStripMenuItem";
            this.清除记录ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.清除记录ToolStripMenuItem.Text = "清除记录";
            this.清除记录ToolStripMenuItem.Click += new System.EventHandler(this.清除记录ToolStripMenuItem_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.linkTextBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(811, 119);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "连接信息";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // linkTextBox
            // 
            this.linkTextBox.BackColor = System.Drawing.Color.White;
            this.linkTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.linkTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.linkTextBox.Location = new System.Drawing.Point(0, 0);
            this.linkTextBox.Name = "linkTextBox";
            this.linkTextBox.ReadOnly = true;
            this.linkTextBox.Size = new System.Drawing.Size(811, 119);
            this.linkTextBox.TabIndex = 0;
            this.linkTextBox.Text = "";
            this.linkTextBox.WordWrap = false;
            // 
            // TaskListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "TaskListForm";
            this.Size = new System.Drawing.Size(819, 419);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tasktable)).EndInit();
            this.TaskMenuStrip.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.threadMenu.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private XPTable.Models.ColumnModel columnModel;
        private XPTable.Models.TableModel tableModel;
        private XPTable.Models.ImageColumn StateimageColumn;
        private XPTable.Models.ImageColumn FileNameimageColumn;
        private XPTable.Models.ProgressBarColumn progressBarColumn;
        private XPTable.Models.TextColumn RatetextColumn;
        private XPTable.Models.TextColumn FileSizetextColumn;
        private XPTable.Models.TextColumn LeftTimetextColumn;
        private XPTable.Models.TextColumn FileTypeNametextColumn;
        private System.Windows.Forms.SplitContainer splitContainer;
        private XPTable.Models.Table tasktable;
        private System.Windows.Forms.ContextMenuStrip TaskMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 暂停PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除DToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 全部开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部暂停ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 清除完成任务ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox taskTextBox;
        private System.Windows.Forms.RichTextBox threadTextBox;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox linkTextBox;
        private System.Windows.Forms.ContextMenuStrip threadMenu;
        private System.Windows.Forms.ToolStripMenuItem 清除记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private XPTable.Models.TextColumn DownloadedSize;
    }
}
