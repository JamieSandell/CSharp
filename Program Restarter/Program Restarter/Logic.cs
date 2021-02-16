using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;

namespace Program_Restarter
{
    public class Logic
    {
        #region Constructors
        public Logic()
        {
            //Initialise member variables
            m_errorStartingProgram = false;
            m_programRestarter = new ProgramRestarter();
            m_timer = new Timer();
            m_timer.Elapsed += new ElapsedEventHandler(DisplayTimerEvent);
            m_numberOfCrashesThisSession = 0;
            m_programRestarter.ProgramName = ".\\test.exe";
            m_programName = "";
        }
        #endregion

        #region Member Variables
        private bool m_errorStartingProgram;
        private string m_errorString;
        private int m_numberOfCrashesThisSession;
        private string m_processName;
        private ProgramRestarter m_programRestarter;
        private string m_programName;
        private Timer m_timer;
        #endregion

        #region Accessors
        /// <summary>
        /// Gets the starting program status
        /// </summary>
        /// <returns>A bool indicating whether or not there was an error starting the program.</returns>
        public bool GetErrorStartingProgram()
        {
            return m_errorStartingProgram;
        }

        /// <summary>
        /// Gets the error caused by trying to start the program.
        /// </summary>
        /// <returns>A string containing the error caused by trying to start the program.</returns>
        public string GetErrorString()
        {
            return m_errorString;
        }

        /// <summary>
        /// Gets the current interval between checks to see if the designated program hasn't crashed.
        /// </summary>
        /// <returns>The interval in milli-seconds.</returns>
        public double GetInterval()
        {
            return m_timer.Interval;
        }

        /// <summary>
        /// Sets the interval (in milli-seconds) between checks to see if the designated program hasn't crashed.
        /// The value must be greater than zero and less than or equal to System.Int32.MaxValue.
        /// </summary>
        /// <param name="interval">The interval in milli-seconds</param>
        /// <returns>An empty string if everything went OK, else an error message is returned.</returns>
        public string SetInterval(double interval)
        {
            if (interval <= 0.0)
                return "The interval must be greater than 0.";
            else if (interval > System.Int32.MaxValue)
                return "The interval must be less than or equal to " + System.Int32.MaxValue.ToString() + 
                    " (System.Int32.MaxValue).";
            else
            {
                m_timer.Interval = interval;
                return "";
            }
        }

        /// <summary>
        /// Gets the number of program crashes this session
        /// </summary>
        /// <returns>A number containing the number of crashes this session</returns>
        public int GetNumberOfCrashesThisSession()
        {
            return m_numberOfCrashesThisSession;
        }

        /// <summary>
        /// Gets the name of the program to restart.
        /// </summary>
        /// <returns>A string containing the name of the program to restart.</returns>
        public string GetProgramName()
        {
            return m_programName;
        }

        /// <summary>
        /// Sets the name of the program to restart.
        /// </summary>
        /// <param name="programName">The name of the program to restart.</param>
        public void SetProgramName(string programName)
        {
            m_programRestarter.ProgramName = programName;
            m_programName = programName;
            int index = 0;
            int lastFoundIndex = 0;
            // Extract the file name + extension
            foreach (char c in m_programName)
            {               
                if (c == '\\')
                    lastFoundIndex = index;
                index++;
            }
            // Remove the file extension
            m_processName = m_programName.Substring(lastFoundIndex + 1, m_programName.Length - lastFoundIndex - 1);
            int indexOfDot = m_processName.IndexOf('.');
            m_processName = m_processName.Remove(indexOfDot);
        }
        #endregion

        #region Member Methods
        /// <summary>
        /// Delegate used to run an event every time the set interval is reached.
        /// </summary>
        /// <param name="source">The object that fired the event.</param>
        /// <param name="e">Data for the elapsed event.</param>
        private void DisplayTimerEvent(object source, ElapsedEventArgs e)
        {
            lock (this)
            {
                Process[] process = new Process[1];
                //// Check to see if the program is running
                //// If the program isn't run it then start it.
                if (DoesProcessExist(m_processName, out process) == false)
                {
                    m_errorString = m_programRestarter.StartProgram();
                    if (m_errorString != "")
                        m_errorStartingProgram = true;
                    else
                        m_errorStartingProgram = false;
                }
                //// If the program is running and the error window is showing
                ////  then kill the error window process (which will kill the crashed program)
                ////  and restart the program
                else if (DoesProcessExist("WerFault", out process) == true)
                {
                    m_numberOfCrashesThisSession++;
                    foreach (Process p in process)
                    {
                        p.Kill();
                    }
                    m_errorString = m_programRestarter.StartProgram();
                    if (m_errorString != "")
                        m_errorStartingProgram = true;
                    else
                        m_errorStartingProgram = false;
                }
            }
        }

        /// <summary>
        /// Checks to see if a current process is running.
        /// </summary>
        /// <param name="processName">The name of the process to look for</param>
        /// <param name="processes">An array containing any found processes</param>
        /// <returns></returns>
        private bool DoesProcessExist(string processName, out Process[] processes)
        {
            processes = Process.GetProcessesByName(processName);
            if (processes.Length == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Start the timer that runs the logic
        /// </summary>
        public void Start()
        {
            m_timer.Start();
        }

        /// <summary>
        /// Stop the timer that runs the logic
        /// </summary>
        public void Stop()
        {
            m_timer.Stop();
        }
        #endregion
    }
}
