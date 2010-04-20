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

        TimeTask currentTask;
        TimerState currentState = TimerState.Stopped;

        public timerMainForm()
        {
            InitializeComponent();
        }
        
        private void timerMainForm_Load(object sender, EventArgs e)
        {
            this.currentState = TimerState.Stopped;
            summaryListView.Sorting = SortOrder.Descending;

            // load the previously saved results, as well as the common task list
            this.PopulateTaskListView(DataStorage.ReadTaskList());
            this.PopulateCommonTaskList(DataStorage.ReadCommonTasks());
            this.PopulateNotes(DataStorage.ReadNotes());

            // if we have added some tasks then start the timer.
            if(timeListView.Items.Count > 0) {
                currentTask = timeListView.Items[timeListView.Items.Count - 1].Tag as TimeTask;

                // we only want to start the timer if there is a current task in the list
                // and it is running.
                if(currentTask != null && currentTask.EndTime == currentTask.UndefinedDate) {
                    this.currentState = TimerState.Running; 
                }

                // calc the summarys
                this.generateSummaryList();
                this.UpdateTotal();
            }


            this.updateControlState();
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

            if (currentState == TimerState.Running)
            {
                this.finishCurrentTask();
            }
            else
            {
                currentState = TimerState.Running;
            }

            // add the task to the combobox if its not already in there
            if(taskNameTxt.FindString(taskNameTxt.Text) == -1) {
                taskNameTxt.Items.Insert(0, taskNameTxt.Text);
                DataStorage.SaveCommonTasks(this.GetCommonTasks());
            }
            
            currentTask = new TimeTask(taskNameTxt.Text, DateTime.Now);
            taskNameTxt.Text = "";

            this.updateControlState();

            // add the currently running task to the bottom row
            timeListView.Items.Add(currentTask.toListViewItem());

            // regenerate the summary list
            this.generateSummaryList();

            // save the new task list to the disk
            DataStorage.SaveTaskList(this.GetTaskList());
            
        }

        private void finishCurrentTask()
        {
            currentTask.EndTime = DateTime.Now;

            // remove the bottom row of the list, where it shows the current task
            timeListView.Items.RemoveAt(timeListView.Items.Count-1);

            // add the current task to the task list
            // but only if it is longer than 5 minutes, otherwise just ignore it
            if(currentTask.Duration > TimeSpan.FromMinutes(5)) {
                timeListView.Items.Add(currentTask.toListViewItem());
            }
        }

        private void updateTimerLabel()
        {
            timerLabel.Text = currentTask.ToString();
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

        private void generateSummaryList()
        {
            summaryListView.Items.Clear();
            List<SummaryTask> summaryList = new List<SummaryTask>();

            // lopp through each item in the orginal list
            // and add it to the summary list if it doesnt already exist.
            // update the total time if it does.
            foreach(ListViewItem taskEntry in timeListView.Items) {
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

        private string[] GetCommonTasks()
        {
            const int MAX_TASKS = 12;
            List<string> CommonTaskList = new List<string>();
            
            int i = 0;
            foreach(string s in taskNameTxt.Items) {
                // we don't want this list getting massive over time.
                // so just stop after 12 items
                if(i >= MAX_TASKS) {
                    break;
                }

                CommonTaskList.Add(s);
                i++;
            }

            return CommonTaskList.ToArray();
        }

        private TimeTask[] GetTaskList()
        {
            List<TimeTask> TaskList = new List<TimeTask>();
            foreach(ListViewItem curItem in timeListView.Items) {
                TaskList.Add(curItem.Tag as TimeTask);
            }

            return TaskList.ToArray();
        }

        private void PopulateTaskListView(TimeTask[] TaskList) 
        {
            timeListView.Items.Clear();

            if(TaskList == null) {
                return;
            }

            foreach(TimeTask currentTask in TaskList) {
                timeListView.Items.Add(currentTask.toListViewItem());
            }
        }

        private void PopulateCommonTaskList(string[] CommonTaskList)
        {
            if(CommonTaskList == null) {
                return;
            }

            foreach(string s in CommonTaskList) {
                taskNameTxt.Items.Add(s);
            }
        }

        private void PopulateNotes(string Notes) 
        {
            NotesTxt.Text = Notes;
        }

        private void stopTimer()
        {
            // stop the current task, mark it as finished
            // and save the change to the disk
            this.currentState = TimerState.Stopped;
            this.finishCurrentTask();
            this.updateControlState();
            DataStorage.SaveTaskList(this.GetTaskList());

            // update the summary list
            this.generateSummaryList();

        }

        private void clearTaskList()
        {
            // stop the current task
            this.currentState = TimerState.Stopped;
            this.updateControlState();

            // save the cleared list to disk (will save an empty array, not 'null')
            timeListView.Items.Clear();
            summaryListView.Items.Clear();
            DataStorage.SaveTaskList(this.GetTaskList());

            // clear the notes
            NotesTxt.Text = "";

            TotalLbl.Text = "Total: 00:00";
        }

        // sets the state of the controls based on the current application state
        private void updateControlState()
        {
            if(currentState == TimerState.Stopped) {

                stopButton.Enabled = false;
                mainTimer.Enabled = false;
                summaryTimer.Enabled = false;
                startStopButton.Text = "Start";
                curTaskLabel.Text = "...";
                timerLabel.Text = "00:00:00";
            
            } else if(currentState == TimerState.Running) {
                stopButton.Enabled = true;
                mainTimer.Enabled = true;
                summaryTimer.Enabled = true;
                startStopButton.Text = "New Task";
                curTaskLabel.Text = "Current Task: " + currentTask.TaskName;
                this.updateTimerLabel();

            }
        }


        private void disableTaskNameHint()
        {
            // get rid of the hint text, really should check against the 
            // forecolor, should have a flag instead. but dont care right now
            if(taskNameTxt.ForeColor == Color.Gray) {
                taskNameTxt.ForeColor = Color.Black;
                taskNameTxt.Text = "";
            }
        }

        private void UpdateTotal()
        {
            TimeSpan TotalDuration = new TimeSpan(0);

            foreach (ListViewItem curItem in timeListView.Items)
            {
                TimeTask curTask = curItem.Tag as TimeTask;
                TotalDuration += curTask.Duration;
            }

            TotalLbl.Text = String.Format("Total: {0:d2}:{1:d2}", TotalDuration.Hours, TotalDuration.Minutes);
        }

        #region MINOR_EVENTS

        private void startStopButton_Click(object sender, EventArgs e)
        {
            startNewTask();
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            this.updateTimerLabel();
        }

        private void timerMainForm_Activated(object sender, EventArgs e)
        {
            taskNameTxt.Focus();
            taskNameTxt.Select(0, 0);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear task data?", "Confirm Clear Tasks", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.clearTaskList();
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            this.stopTimer();
        }
       
        private void taskNameTxt_TextChanged(object sender, EventArgs e)
        {
            this.disableTaskNameHint();
        }

        private void taskNameTxt_DropDown(object sender, EventArgs e)
        {
            this.disableTaskNameHint();
        }


        private void timerMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataStorage.SaveNotes(NotesTxt.Text);
        }

        private void updateSummary_Tick(object sender, EventArgs e)
        {
            this.UpdateTotal();
            this.generateSummaryList();
        }
        #endregion
    }

    public enum TimerState {
        Stopped,
        Running
    }
}