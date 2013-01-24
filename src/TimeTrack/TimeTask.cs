using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TimeTrack
{
    public class TimeTask {
        public DateTime UndefinedDate = DateTime.Parse("2100-01-01 00:00:00");

        public string TaskName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration {get { return (TimeSpan)(((this.EndTime == this.UndefinedDate)?DateTime.Now:this.EndTime) - this.StartTime); } }

        public TimeTask() {
            this.TaskName = "";
            this.StartTime = this.UndefinedDate;
            this.EndTime = this.UndefinedDate;
        }

        public TimeTask(string TaskName, DateTime StartTime) {
            this.TaskName = TaskName;
            this.StartTime = StartTime;
            this.EndTime = this.UndefinedDate;
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
            
            if(EndTime != this.UndefinedDate) {
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
