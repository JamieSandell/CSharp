using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Program_Restarter
{
    public class ProgramRestarter
    {
        #region Constructors
        public ProgramRestarter()
        {

        }
        #endregion

        #region Accessors
        /// <summary>
        /// Gets/Sets the name of the program to start
        /// </summary>
        public string ProgramName
        { 
            get;
            set;
        }
        #endregion

        #region Member Methods
        /// <summary>
        /// Starts the program
        /// </summary>
        /// <returns>An empty string if successful, else an error message is returned.</returns>
        public string StartProgram()
        {
            string baseError = "A problem occurred starting the program, the exact error was\r\n";

            try
            {
                Process.Start(ProgramName);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                return baseError + ex.ToString();
            }
            catch (System.ObjectDisposedException ex)
            {
                return baseError + ex.ToString();
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                return baseError + ex.ToString();
            }
            catch (System.Exception ex)
            {
                return baseError + ex.ToString();
            }

            return ""; //If here then everything went OK.
        }
        #endregion
    }
}
