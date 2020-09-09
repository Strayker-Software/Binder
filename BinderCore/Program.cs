using System;
using System.Windows.Forms;
using Binder.UI;

namespace Binder
{
    static class Program
    {
        /// <summary>
        /// Main entry point for application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DataGridViewMain());
        }
    }
}
