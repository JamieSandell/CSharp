using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program_Restarter
{
    public partial class Options : Form
    {
        #region Member Variables
        private FormMain m_mainForm;
        private OpenFileDialog m_ofd;
        #endregion

        #region Constructors
        public Options(Form callingForm)
        {
            InitializeComponent();

            m_mainForm = callingForm as FormMain;
            m_ofd = null;
            textBoxProgramToRestart.Text = m_mainForm.GetProgramName();
        }
        #endregion

        #region Accessors
        /// <summary>
        /// Returns the open file dialog.
        /// </summary>
        /// <returns>The open file dialog.</returns>
        public OpenFileDialog GetOpenFileDialog()
        {
            return m_ofd;
        }

        /// <summary>
        /// Returns the program name (including file path) of the program to restart.
        /// </summary>
        /// <returns>The program name (including file path) of the program to restart.</returns>
        public string GetProgramName()
        {
            return textBoxProgramToRestart.Text;
        }

        /// <summary>
        /// Sets the interval control value.
        /// </summary>
        /// <param name="interval">The interval value.</param>
        public void SetInterval(decimal interval)
        {
            numericUpDownInterval.Value = interval;
        }

        /// <summary>
        /// Sets the path and filename of the program to restart.
        /// </summary>
        /// <param name="program">The program (including file path) to restart.</param>
        public void SetProgramToRestart(string program)
        {
            textBoxProgramToRestart.Text = program;
        }
        #endregion

        #region Member Methods
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string result = SaveOptions();
            if (result != "")
            {
                MessageBox.Show(result, "Program Restarter", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Options saved successfully.", "Program Restarter", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Attempts to save the options.
        /// </summary>
        /// <returns>An empty string if successful, else an error message is returned.</returns>
        private string SaveOptions()
        {
            string baseError = "There was an error saving. The error was:\r\n";
            double interval = -1;

            // Try and convert the value to a double.
            try
            {
                interval = double.Parse(numericUpDownInterval.Value.ToString());
            }
            catch (System.ArgumentNullException ex)
            {
                return baseError + ex.ToString();
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

            // Try and set the converted value.
            string result = m_mainForm.SetInterval(interval);
            if (result != "")
            {
                return baseError + result;
            }
            else //Everything went OK so write the changes to the file.
            {
                string optionsFile = m_mainForm.GetOptionsFileLocation();
                StreamWriter sw = null;
                // Try and open the options file, write to it, and then close it.
                try
                {
                    sw = new StreamWriter(optionsFile, false);
                    sw.WriteLine(textBoxProgramToRestart.Text);
                    sw.Write(interval);
                    m_mainForm.SetProgramParameters();
                }
                catch (System.UnauthorizedAccessException ex)
                {
                    return baseError + ex.ToString();
                }
                catch (System.ArgumentNullException ex)
                {
                    return baseError + ex.ToString();
                }
                catch (System.IO.PathTooLongException ex)
                {
                    return baseError + ex.ToString();
                }
                catch (System.ArgumentException ex)
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
                catch (System.Security.SecurityException ex)
                {
                    return baseError + ex.ToString();
                }
                catch (System.Exception ex)
                {
                    return baseError + ex.ToString();
                }
                finally
                {
                    if (sw != null)
                        sw.Close();
                }
                return "";
            }
        }
        #endregion

        private void buttonSelectProgram_Click(object sender, EventArgs e)
        {
            if (m_ofd == null)
                m_ofd = new OpenFileDialog();
            DialogResult dlgResult = m_ofd.ShowDialog();
            if (dlgResult != DialogResult.OK)
            {
                MessageBox.Show("There was a problem selecting a file to open.", "Project Restarter", MessageBoxButtons.OK);
                return;
            }
            else
                textBoxProgramToRestart.Text = m_ofd.FileName;
        }
    }
}
