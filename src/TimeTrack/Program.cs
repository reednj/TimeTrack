using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Diagnostics;

namespace TimeTrack
{
    static class Program
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool mutexCreated = false;
            System.Threading.Mutex mutex = new System.Threading.Mutex( true, @"Local\TimeTrack.exe", out mutexCreated );

            // only want once instance open at a time.
            // if the application is already open, then scan the processes to find out which
            // one it is, and give it focus.
            if(mutexCreated) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new timerMainForm());
            } else {
                // scan the processes, find the one that is ours, and focus to it
                Process current = Process.GetCurrentProcess();
                foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                {
                    if (process.Id != current.Id)
                    {
                        SetForegroundWindow(process.MainWindowHandle);
                        break;
                    }
                }
            }


            mutex.Close();
        }
    }
}