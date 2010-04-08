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
        DateTime startTime;
        DateTime endTime;
        string taskName;
        Random randGen;

        bool isRunning;

        public timerMainForm()
        {
            InitializeComponent();
        }
        
        private void timerMainForm_Load(object sender, EventArgs e)
        {
            randGen = new Random();
            summaryList.Sorting = SortOrder.Descending;
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
                endTime = DateTime.Now;
                //TimeSpan taskLength = endTime - startTime;
                TimeSpan taskLength = new TimeSpan(0, randGen.Next(10, 60), 0);

                // remove the bottom row of the list, where it shows the current task
                timeList.Items.RemoveAt(timeList.Items.Count-1);

                // add the current task to the task list
                // but only if it is longer than 5 minutes, otherwise just ignore it
                if(taskLength > new TimeSpan(0, 5, 0)) {
                    // add the row for the just finished task
                    listItems[0] = String.Format("{0:d2}:{1:d2}", startTime.Hour, startTime.Minute); 
                    listItems[1] = String.Format("{0:d2}:{1:d2}", endTime.Hour, endTime.Minute); 
                    listItems[2] = String.Format("{0:d2}:{1:d2}", taskLength.Hours, taskLength.Minutes); 
                    listItems[3] = taskName;
                    timeList.Items.Add(new ListViewItem(listItems));
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
            
            // set/reset all the right params
            startTime = DateTime.Now;
            taskName = taskNameTxt.Text;
            taskNameTxt.Text = "";
            curTaskLabel.Text = "Current Task: " + taskName;

            // add the currently running task to the bottom row
            listItems[0] = String.Format("{0:d2}:{1:d2}", startTime.Hour, startTime.Minute);
            listItems[1] = "--";
            listItems[2] = "--";
            listItems[3] = taskName;
            timeList.Items.Add(new ListViewItem(listItems));

            // regenerate the summary list
            generateSummaryList();
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan timeDiff = DateTime.Now - startTime;
            string timeString = String.Format("{0:d2}:{1:d2}:{2:d2}", timeDiff.Hours, timeDiff.Minutes, timeDiff.Seconds);

            timerLabel.Text = timeString;
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
            summaryList.Items.Clear();

            // lopp through each item in the orginal list
            // and add it to the summary list if it doesnt already exist.
            // update the total time if it does.
            foreach(ListViewItem taskEntry in timeList.Items) {
                string[] summaryRow = new string[2];
                summaryRow[0] = taskEntry.SubItems[2].Text; // duration
                summaryRow[1] = taskEntry.SubItems[3].Text; // name
                
                // not ideal to check for the final item this way, but whatever
                if(summaryRow[0] == "--") {
                    continue;
                }
                // check if this item is already in the summary list or not
                if(summaryList.Items.Find(summaryRow[1], true).Length == 0) {
                    ListViewItem newRow = new ListViewItem(summaryRow);
                    newRow.Name = summaryRow[1];
                    summaryList.Items.Add(newRow);
                } else {
                    // it already exists, so add the duration of the current item
                    ListViewItem curItem = summaryList.Items.Find(summaryRow[1], true)[0];
                    TimeSpan newDuration = TimeSpan.Parse(curItem.SubItems[0].Text) + TimeSpan.Parse(summaryRow[0]);

                    curItem.SubItems[0].Text = String.Format("{0:d2}:{1:d2}", newDuration.Hours, newDuration.Minutes);
                }
            }

            summaryList.Sort();
        }
    }
}