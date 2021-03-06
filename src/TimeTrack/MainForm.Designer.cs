namespace TimeTrack
{
    partial class timerMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(timerMainForm));
            this.timerLabel = new System.Windows.Forms.Label();
            this.startStopButton = new System.Windows.Forms.Button();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.curTaskLabel = new System.Windows.Forms.Label();
            this.chromeTimer = new System.Windows.Forms.Timer(this.components);
            this.taskNameTxt = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.timeListView = new System.Windows.Forms.ListView();
            this.StartHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EndHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DurHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.summaryListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.NotesTxt = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.TotalLbl = new System.Windows.Forms.Label();
            this.summaryTimer = new System.Windows.Forms.Timer(this.components);
            this.listContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.minToStartTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minFromStartTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.listContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Arial", 36F);
            this.timerLabel.Location = new System.Drawing.Point(5, 20);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(212, 55);
            this.timerLabel.TabIndex = 0;
            this.timerLabel.Text = "00:00:00";
            // 
            // startStopButton
            // 
            this.startStopButton.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startStopButton.Location = new System.Drawing.Point(5, 78);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.Size = new System.Drawing.Size(209, 45);
            this.startStopButton.TabIndex = 1;
            this.startStopButton.Text = "Start";
            this.startStopButton.UseVisualStyleBackColor = true;
            this.startStopButton.Click += new System.EventHandler(this.startStopButton_Click);
            // 
            // mainTimer
            // 
            this.mainTimer.Interval = 1000;
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // curTaskLabel
            // 
            this.curTaskLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curTaskLabel.Location = new System.Drawing.Point(12, 1);
            this.curTaskLabel.Name = "curTaskLabel";
            this.curTaskLabel.Size = new System.Drawing.Size(202, 19);
            this.curTaskLabel.TabIndex = 4;
            this.curTaskLabel.Text = "...";
            this.curTaskLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chromeTimer
            // 
            this.chromeTimer.Interval = 1000;
            this.chromeTimer.Tick += new System.EventHandler(this.chromeTimer_Tick);
            // 
            // taskNameTxt
            // 
            this.taskNameTxt.ForeColor = System.Drawing.Color.Gray;
            this.taskNameTxt.FormattingEnabled = true;
            this.taskNameTxt.Location = new System.Drawing.Point(5, 129);
            this.taskNameTxt.Name = "taskNameTxt";
            this.taskNameTxt.Size = new System.Drawing.Size(209, 21);
            this.taskNameTxt.TabIndex = 5;
            this.taskNameTxt.Text = "Type Task Code Here";
            this.taskNameTxt.DropDown += new System.EventHandler(this.taskNameTxt_DropDown);
            this.taskNameTxt.Enter += new System.EventHandler(this.taskNameTxt_Enter);
            this.taskNameTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.taskNameTxt_KeyDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(5, 156);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(213, 275);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.timeListView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(205, 249);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tasks";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // timeListView
            // 
            this.timeListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StartHeader1,
            this.EndHeader,
            this.DurHeader1,
            this.NameHeader1});
            this.timeListView.ContextMenuStrip = this.listContextMenu;
            this.timeListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeListView.FullRowSelect = true;
            this.timeListView.Location = new System.Drawing.Point(3, 3);
            this.timeListView.Name = "timeListView";
            this.timeListView.Size = new System.Drawing.Size(199, 243);
            this.timeListView.TabIndex = 3;
            this.timeListView.UseCompatibleStateImageBehavior = false;
            this.timeListView.View = System.Windows.Forms.View.Details;
            // 
            // StartHeader1
            // 
            this.StartHeader1.Text = "Start";
            this.StartHeader1.Width = 40;
            // 
            // EndHeader
            // 
            this.EndHeader.Text = "End";
            this.EndHeader.Width = 40;
            // 
            // DurHeader1
            // 
            this.DurHeader1.Text = "Length";
            this.DurHeader1.Width = 50;
            // 
            // NameHeader1
            // 
            this.NameHeader1.Text = "Task";
            this.NameHeader1.Width = 65;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.summaryListView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(205, 249);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Summary";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // summaryListView
            // 
            this.summaryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.summaryListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.summaryListView.FullRowSelect = true;
            this.summaryListView.Location = new System.Drawing.Point(3, 3);
            this.summaryListView.Name = "summaryListView";
            this.summaryListView.Size = new System.Drawing.Size(199, 243);
            this.summaryListView.TabIndex = 7;
            this.summaryListView.UseCompatibleStateImageBehavior = false;
            this.summaryListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 1;
            this.columnHeader1.Text = "Length";
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 0;
            this.columnHeader2.Text = "Task";
            this.columnHeader2.Width = 120;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.NotesTxt);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(205, 249);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Notes";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // NotesTxt
            // 
            this.NotesTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotesTxt.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotesTxt.Location = new System.Drawing.Point(3, 3);
            this.NotesTxt.Multiline = true;
            this.NotesTxt.Name = "NotesTxt";
            this.NotesTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.NotesTxt.Size = new System.Drawing.Size(199, 243);
            this.NotesTxt.TabIndex = 0;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(162, 433);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(49, 26);
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(107, 433);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(49, 26);
            this.stopButton.TabIndex = 9;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // TotalLbl
            // 
            this.TotalLbl.AutoSize = true;
            this.TotalLbl.ForeColor = System.Drawing.Color.DimGray;
            this.TotalLbl.Location = new System.Drawing.Point(12, 440);
            this.TotalLbl.Name = "TotalLbl";
            this.TotalLbl.Size = new System.Drawing.Size(64, 13);
            this.TotalLbl.TabIndex = 10;
            this.TotalLbl.Text = "Total: 00:00";
            // 
            // summaryTimer
            // 
            this.summaryTimer.Interval = 60000;
            this.summaryTimer.Tick += new System.EventHandler(this.updateSummary_Tick);
            // 
            // listContextMenu
            // 
            this.listContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minToStartTimeToolStripMenuItem,
            this.minFromStartTimeToolStripMenuItem});
            this.listContextMenu.Name = "listContextMenu";
            this.listContextMenu.ShowImageMargin = false;
            this.listContextMenu.Size = new System.Drawing.Size(177, 48);
            this.listContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.listContextMenu_Opening);
            // 
            // minToStartTimeToolStripMenuItem
            // 
            this.minToStartTimeToolStripMenuItem.Name = "minToStartTimeToolStripMenuItem";
            this.minToStartTimeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.minToStartTimeToolStripMenuItem.Text = "+15 min to Start Time";
            this.minToStartTimeToolStripMenuItem.Click += new System.EventHandler(this.minToStartTimeToolStripMenuItem_Click);
            // 
            // minFromStartTimeToolStripMenuItem
            // 
            this.minFromStartTimeToolStripMenuItem.Name = "minFromStartTimeToolStripMenuItem";
            this.minFromStartTimeToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.minFromStartTimeToolStripMenuItem.Text = "-15 min from Start Time";
            this.minFromStartTimeToolStripMenuItem.Click += new System.EventHandler(this.minFromStartTimeToolStripMenuItem_Click);
            // 
            // timerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 463);
            this.Controls.Add(this.TotalLbl);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.curTaskLabel);
            this.Controls.Add(this.taskNameTxt);
            this.Controls.Add(this.startStopButton);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "timerMainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Time Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.timerMainForm_FormClosing);
            this.Load += new System.EventHandler(this.timerMainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.listContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Button startStopButton;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Label curTaskLabel;
        private System.Windows.Forms.Timer chromeTimer;
        private System.Windows.Forms.ComboBox taskNameTxt;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView timeListView;
        private System.Windows.Forms.ColumnHeader StartHeader1;
        private System.Windows.Forms.ColumnHeader EndHeader;
        private System.Windows.Forms.ColumnHeader DurHeader1;
        private System.Windows.Forms.ColumnHeader NameHeader1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView summaryListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox NotesTxt;
        private System.Windows.Forms.Label TotalLbl;
        private System.Windows.Forms.Timer summaryTimer;
        private System.Windows.Forms.ContextMenuStrip listContextMenu;
        private System.Windows.Forms.ToolStripMenuItem minToStartTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minFromStartTimeToolStripMenuItem;
    }
}

