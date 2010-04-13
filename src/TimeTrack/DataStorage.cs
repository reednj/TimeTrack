using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace TimeTrack
{
    public static class DataStorage {
        const string TASKLIST_FILE = @"\tasklist.json";
        const string COMMONTASK_FILE = @"\commontasks.json";

        public static void SaveTaskList(TimeTask[] TaskList) 
        {
            string jsonData = JavaScriptConvert.SerializeObject(TaskList);
            File.WriteAllText(Application.UserAppDataPath + TASKLIST_FILE, jsonData);
        }

        public static TimeTask[] ReadTaskList() 
        {
            try {
                string jsonData = File.ReadAllText(Application.UserAppDataPath + TASKLIST_FILE);
                return (TimeTask[])JavaScriptConvert.DeserializeObject(jsonData, typeof(TimeTask[]));
            } catch(FileNotFoundException) {
                return null;
            }
        }

        public static void SaveCommonTasks(string[] TaskList) 
        {
            string jsonData = JavaScriptConvert.SerializeObject(TaskList);
            File.WriteAllText(Application.UserAppDataPath + COMMONTASK_FILE, jsonData);
        }

        public static string[] ReadCommonTasks() 
        {
            try {
                string jsonData = File.ReadAllText(Application.UserAppDataPath + COMMONTASK_FILE);
                return (string[])JavaScriptConvert.DeserializeObject(jsonData, typeof(string[]));
            } catch(FileNotFoundException) {
                return null;
            }
        }
    }

}
