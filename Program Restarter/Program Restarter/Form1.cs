using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program_Restarter
{
    public partial class FormMain : Form
    {
        #region Member Variables
        private AboutBox m_aboutBox;
        private bool m_buttonClick;
        private Timer m_myTimer;
        private Logic m_logic;
        private Options m_optionsForm;
        private string m_optionsFile;
        #endregion

        #region Constructors
        public FormMain()
        {
            InitializeComponent();

            m_logic = new Logic();
            m_logic.SetInterval(2000);
            m_myTimer = new Timer();
            m_myTimer.Tick += new EventHandler(DisplayTimerEvent);
            m_myTimer.Interval = 2000;
            m_myTimer.Start();
            m_buttonClick = false;
            textBoxNumberOfCrashesThisSession.Text = "0";
            m_optionsFile = ".//options.txt";
            m_optionsForm = new Options(this);
            m_aboutBox = new AboutBox();

            string result = LoadOptionsFile();
            if (result != "")
                MessageBox.Show(result, "Program Restarter", MessageBoxButtons.OK);
        }
        #endregion

        #region Accessors
        /// <summary>
        /// Gets the location (including filename) of the options file.
        /// </summary>
        /// <returns>The location (including the filename) of the options file.</returns>
        public string GetOptionsFileLocation()
        {
            return m_optionsFile;
        }

        /// <summary>
        /// Gets the name of the program to restart.
        /// </summary>
        /// <returns>The name of the program to restart.</returns>
        public string GetProgramName()
        {
            return m_logic.GetProgramName();
        }

        /// <summary>
        /// Sets the interval (in milli-seconds) between checks to see if the designated program hasn't crashed.
        /// The value must be greater than zero and less than or equal to System.Int32.MaxValue.
        /// </summary>
        /// <param name="interval">The interval in milli-seconds</param>
        /// <returns>An empty string if everything went OK, else an error message is returned.</returns>
        public string SetInterval(double interval)
        {
            if (interval <= 0)
                return "The interval must be greater than 0.";
            else
            {
                string reply = m_logic.SetInterval(interval);
                if (reply != "")
                    return reply;
                return "";
            }
        }
        #endregion

        #region Member Methods
        /// <summary>
        /// Shows the about box.
        /// </summary>
        /// <param name="sender">The source that fired the event.</param>
        /// <param name="e">Data for the event.</param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_aboutBox.IsDisposed)
                m_aboutBox = new AboutBox();
            m_aboutBox.Show(); ;
        }
        
        /// <summary>
        /// Starts/Stops the monitoring of the program.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">The event arguments.</param>
        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (m_buttonClick == false)
            {
                m_buttonClick = true;
                buttonStartStop.Text = "Stop Monitoring";
                m_logic.Start();
            }
            else
            {
                m_buttonClick = false;
                buttonStartStop.Text = "Start Monitoring";
                m_logic.Stop();
            }
        }

        /// <summary>
        /// Delegate for timer variable.
        /// </summary>
        /// <param name="source">The object that fired the event</param>
        /// <param name="e">Data for the event.</param>
        private void DisplayTimerEvent(object source, EventArgs e)
        {
            if (m_logic.GetErrorStartingProgram())
            {
                MessageBox.Show(m_logic.GetErrorString(), "Program Restarter", MessageBoxButtons.OK);
            }
            textBoxNumberOfCrashesThisSession.Text = (m_logic.GetNumberOfCrashesThisSession()).ToString();
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Data for the event.</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string LoadOptionsFile()
        {
            string baseError = "There was a problem loading the options file. The error was:\r\n";
            StreamReader sr = null;
            // Try and open the options file, read from it, and then close it.
            try
            {
                sr = new StreamReader(m_optionsFile);

                string line = sr.ReadLine();
                // Try and convert the read in line to the appropriate variable type
                try
                {
                    m_optionsForm.SetProgramToRestart(line);
                    line = sr.ReadLine();
                    double interval = Convert.ToDouble(line);
                    string result = m_logic.SetInterval(interval);
                    if (result != "")
                        return baseError + result;
                    decimal intervalDec = Convert.ToDecimal(interval);
                    m_optionsForm.SetInterval(intervalDec);

                    SetProgramParameters();

                }
                catch (System.FormatException ex)
                {
                    return baseError + ex.ToString();
                }
                catch (System.OverflowException ex)
                {
                    return baseError + ex.ToString();
                }
                catch (System.Exception ex)
                {
                    return baseError + ex.ToString();
                }
            }
            catch (System.ArgumentNullException ex)
            {
                return baseError + ex.ToString();
            }
            catch (System.ArgumentException ex)
            {
                return baseError + ex.ToString();
            }
            catch (System.IO.FileNotFoundException ex)
            {
                return baseError + ex.ToString();
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                return baseError + ex.ToString();
            }
            catch (System.IO.IOException ex)
            {
                return baseError + ex.ToString();
            }
            catch (System.Exception ex)
            {
                return baseError + ex.ToString();
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
            return "";
        }

        /// <summary>
        /// Shows the options form.
        /// </summary>
        /// <param name="sender">The object that fired the event.</param>
        /// <param name="e">Data for the event.</param>
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_optionsForm.IsDisposed)
                m_optionsForm = new Options(this);
            m_optionsForm.Show();
        }

        public void SetProgramParameters()
        {
            //OpenFileDialog ofd = m_optionsForm.GetOpenFileDialog();
            //if (ofd != null)
            //{
            //    m_logic.SetProgramName(ofd.FileName);
            //}
            m_logic.SetProgramName(m_optionsForm.GetProgramName());
        }
        #endregion
    }
}
