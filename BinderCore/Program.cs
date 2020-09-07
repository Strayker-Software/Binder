using System;
using System.Windows.Forms;

namespace Binder
{
    static class Program
    {
        /// <summary>
        /// Main entry point for application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI.DataGridViewMain());
        }
    }
}
