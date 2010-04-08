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
            this.timerLabel = new System.Windows.Forms.Label();
            this.startStopButton = new System.Windows.Forms.Button();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.curTaskLabel = new System.Windows.Forms.Label();
            this.chromeTimer = new System.Windows.Forms.Timer(this.components);
            this.taskNameTxt = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.timeList = new System.Windows.Forms.ListView();
            this.StartHeader1 = new System.Windows.Forms.ColumnHeader();
            this.EndHeader = new System.Windows.Forms.ColumnHeader();
            this.DurHeader1 = new System.Windows.Forms.ColumnHeader();
            this.NameHeader1 = new System.Windows.Forms.ColumnHeader();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.summaryListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.startStopButton.Size = new System.Drawing.Size(213, 45);
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
            this.taskNameTxt.Size = new System.Drawing.Size(213, 21);
            this.taskNameTxt.TabIndex = 5;
            this.taskNameTxt.Text = "Type Task Code Here";
            this.taskNameTxt.Enter += new System.EventHandler(this.taskNameTxt_Enter);
            this.taskNameTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.taskNameTxt_KeyDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 156);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(213, 280);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.timeList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(205, 254);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tasks";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // timeList
            // 
            this.timeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StartHeader1,
            this.EndHeader,
            this.DurHeader1,
            this.NameHeader1});
            this.timeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeList.Location = new System.Drawing.Point(3, 3);
            this.timeList.Name = "timeList";
            this.timeList.Size = new System.Drawing.Size(199, 248);
            this.timeList.TabIndex = 3;
            this.timeList.UseCompatibleStateImageBehavior = false;
            this.timeList.View = System.Windows.Forms.View.Details;
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
            this.tabPage2.Size = new System.Drawing.Size(205, 254);
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
            this.summaryListView.Location = new System.Drawing.Point(3, 3);
            this.summaryListView.Name = "summaryListView";
            this.summaryListView.Size = new System.Drawing.Size(199, 248);
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
            // timerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 438);
            this.Controls.Add(this.curTaskLabel);
            this.Controls.Add(this.taskNameTxt);
            this.Controls.Add(this.startStopButton);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "timerMainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Time Tracker";
            this.Activated += new System.EventHandler(this.timerMainForm_Activated);
            this.Load += new System.EventHandler(this.timerMainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
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
        private System.Windows.Forms.ListView timeList;
        private System.Windows.Forms.ColumnHeader StartHeader1;
        private System.Windows.Forms.ColumnHeader EndHeader;
        private System.Windows.Forms.ColumnHeader DurHeader1;
        private System.Windows.Forms.ColumnHeader NameHeader1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView summaryListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
