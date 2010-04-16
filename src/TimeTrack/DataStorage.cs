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
        const string NOTES_FILE = @"\notes.json";

        public static void SaveTaskList(TimeTask[] TaskList) 
        {
            SerializeObject(Application.UserAppDataPath + TASKLIST_FILE, TaskList);
        }

        public static TimeTask[] ReadTaskList() 
        {
            return (TimeTask[])DeserializeObject(Application.UserAppDataPath + TASKLIST_FILE, typeof(TimeTask[]));
        }

        public static void SaveCommonTasks(string[] TaskList) 
        {
            SerializeObject(Application.UserAppDataPath + COMMONTASK_FILE, TaskList);
        }

        public static string[] ReadCommonTasks() 
        {
            return (string[])DeserializeObject(Application.UserAppDataPath + COMMONTASK_FILE, typeof(string[]));
        }

        // for some weird reason we cannot serialize just a straight string to json, it must be an
        // object or an array. So we convert the string to an aray with a single element
        public static void SaveNotes(string Notes)
        {
            string[] a = new string[1] {Notes};
            SerializeObject(Application.UserAppDataPath + NOTES_FILE, a);
        }

        public static string ReadNotes()
        {

            string[] a = (string[])DeserializeObject(Application.UserAppDataPath + NOTES_FILE, typeof(string[]));
            return (a == null)? null : a[0];
        }

        // generic serialization/deserialization methods.
        public static void SerializeObject(string Path, object Data) 
        {
            string jsonData = JavaScriptConvert.SerializeObject(Data);
            File.WriteAllText(Path, jsonData);
        }

        public static object DeserializeObject(string Path, Type ObjectType) 
        {
            try {
                string jsonData = File.ReadAllText(Path);
                return JavaScriptConvert.DeserializeObject(jsonData, ObjectType);
            } catch(FileNotFoundException) {
                return null;
            }
        }
    }

}
