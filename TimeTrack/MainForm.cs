using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TimeTrack
{
    public partial class timerMainForm : Form
    {

        bool isRunning;
        TimeTask currentTask;

        public timerMainForm()
        {
            InitializeComponent();
        }
        
        private void timerMainForm_Load(object sender, EventArgs e)
        {
            summaryListView.Sorting = SortOrder.Descending;
            isRunning = false;

        }

        private void startStopButton_Click(object sender, EventArgs e)
        {
            startNewTask();
        }

        private void startNewTask()
        {
            string[] listItems = new string[4];
            
            // we cannot start a new task unless the user has entered a 
            // task name
            if(taskNameTxt.Text == "" || taskNameTxt.ForeColor == Color.Gray) 
            {
                // no task name, so flash the text box, and dont start the timer
                chromeTimer.Enabled = true;
                taskNameTxt.BackColor = Color.Salmon;
                return;

            }

            if (isRunning == true)
            {
                currentTask.EndTime = DateTime.Now;

                // remove the bottom row of the list, where it shows the current task
                timeList.Items.RemoveAt(timeList.Items.Count-1);

                // add the current task to the task list
                // but only if it is longer than 5 minutes, otherwise just ignore it
                if(currentTask.Duration > TimeSpan.FromMinutes(5)) {
                    timeList.Items.Add(currentTask.toListViewItem());
                }
            }
            else
            {
                mainTimer.Enabled = true;
                startStopButton.Text = "New Task";
                isRunning = true;
            }

            // add the task to the combobox if its not already in there
            if(taskNameTxt.FindString(taskNameTxt.Text) == -1) {
                taskNameTxt.Items.Add(taskNameTxt.Text);
            }
            
            
            currentTask = new TimeTask(taskNameTxt.Text, DateTime.Now);
            curTaskLabel.Text = "Current Task: " + currentTask.TaskName;
            taskNameTxt.Text = "";

            // add the currently running task to the bottom row
            timeList.Items.Add(currentTask.toListViewItem());

            // regenerate the summary list
            generateSummaryList();
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            timerLabel.Text = currentTask.ToString();
        }

        private void taskNameTxt_Enter(object sender, EventArgs e)
        {
            // get rid of the hint text, really should check against the 
            // forecolor, should have a flag instead. but dont care right now
            if(taskNameTxt.ForeColor == Color.Gray) {
                taskNameTxt.ForeColor = Color.Black;
                taskNameTxt.Text = "";
            }
        }

        private void chromeTimer_Tick(object sender, EventArgs e)
        {
            taskNameTxt.BackColor = Color.White;
            chromeTimer.Enabled = false;
        }

        private void taskNameTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) {
                startNewTask();
                e.SuppressKeyPress = true;
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void generateSummaryList()
        {
            summaryListView.Items.Clear();
            List<SummaryTask> summaryList = new List<SummaryTask>();

            // lopp through each item in the orginal list
            // and add it to the summary list if it doesnt already exist.
            // update the total time if it does.
            foreach(ListViewItem taskEntry in timeList.Items) {
                TimeTask currentTask = taskEntry.Tag as TimeTask;
                SummaryTask sumItem = summaryList.Find(delegate(SummaryTask st) {return st.TaskName == currentTask.TaskName;});
                if(sumItem == null) {
                    summaryList.Add(new SummaryTask(currentTask.TaskName, currentTask.Duration));
                } else {
                    sumItem.Duration += currentTask.Duration;
                }
            }

            // now we have the summary duration for all the tasks, we can go ahead and add it all
            // to the listview. They will be sorted by the listview automatically.
            foreach(SummaryTask st in summaryList) {
                summaryListView.Items.Add(st.toListViewItem());
            }

        }

        private void timerMainForm_Activated(object sender, EventArgs e)
        {
            taskNameTxt.Focus();
        }
    }

    public class TimeTask {
        private string _taskName;
        private DateTime _startTime;
        private DateTime _endTime;

        public string TaskName {get { return _taskName; } set { _taskName = value; }}
        public DateTime StartTime {get { return _startTime; } set { _startTime = value; }}
        public DateTime EndTime { get { return _endTime; } set { _endTime = value; } }
        public TimeSpan Duration {get { return ((this.EndTime == DateTime.MaxValue)?DateTime.Now:this.EndTime) - this.StartTime; } }

        public TimeTask() {
            this.TaskName = "";
            this.StartTime = DateTime.MaxValue;
            this.EndTime = DateTime.MaxValue;
        }

        public TimeTask(string TaskName, DateTime StartTime) {
            this.TaskName = TaskName;
            this.StartTime = StartTime;
            this.EndTime = DateTime.MaxValue;
        }

        public TimeTask(string TaskName, DateTime StartTime, DateTime EndTime) {
            this.TaskName = TaskName;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
        }

        public ListViewItem toListViewItem()
        {
            string[] listItems = new string[4];
            listItems[0] = String.Format("{0:d2}:{1:d2}", StartTime.Hour, StartTime.Minute); 
            
            if(EndTime != DateTime.MaxValue) {
                listItems[1] = String.Format("{0:d2}:{1:d2}", EndTime.Hour, EndTime.Minute); 
                listItems[2] = String.Format("{0:d2}:{1:d2}", Duration.Hours, Duration.Minutes); 
            } else {
                // if there is no end time set, then just shove in some dashes
                listItems[1] = "--";
                listItems[2] = "--";
            }
            listItems[3] = TaskName;

            ListViewItem newItem = new ListViewItem(listItems);
            newItem.Tag = this;
            return newItem;
        }

        public override string ToString()
        {
            return String.Format("{0:d2}:{1:d2}:{2:d2}", this.Duration.Hours,this.Duration.Minutes, this.Duration.Seconds);
        }
    }

    public class SummaryTask {
        private string _taskName;
        private TimeSpan _duration;

        public string TaskName {  get { return _taskName; } set { _taskName = value; }}
        public TimeSpan Duration { get { return _duration; }  set { _duration = value; }}

        public SummaryTask(string TaskName) {
            this.TaskName = TaskName;
        }

        public SummaryTask(string TaskName, TimeSpan Duration) {
            this.TaskName = TaskName;
            this.Duration = Duration;
        }
        
        public ListViewItem toListViewItem()
        {
            string[] listItems = new string[2];
            listItems[0] = String.Format("{0:d2}:{1:d2}", this.Duration.Hours, this.Duration.Minutes); 
            listItems[1] = this.TaskName;

            ListViewItem newItem = new ListViewItem(listItems);
            newItem.Tag = this;
            return newItem;
        }
    }
}