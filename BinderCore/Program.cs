using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using Binder.Controllers;
using Binder.Data;
using Binder.Data.Storage.Files;
using Binder.Properties;
using Binder.UI;
using Binder.UI.MessageBoxes;

namespace Binder
{
    public static class Program
    {
        /// <summary>
        /// Main entry point for application.
        /// </summary>
        [ExcludeFromCodeCoverage]
        [STAThread]
        public static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Configure main logic:
            var factory = new MessageBoxFactory();
            var mainForm = new DataGridViewMain();
            var storage = new FileStorageManager(new StandardFileSystemAccess(), Settings.Default.DefaultCategoryFileDirectory);
            var converter = new XMLDataConverter();
            var controller = new StandardController(mainForm, storage, converter);
            // TODO: There should be error box informing of error in loading tasks.
            // TODO: Binder Debug Mode built into app?
            // TODO: Damaged date and time info in loading process is being replaced by DateTime.Now values.

#if !DEBUG
            try
            {
                controller.LoadApp();
            }
            catch (Exception a)
            {
                factory.ShowMessageBox(EMessageBox.Standard,
                    string.Format(Resources.UnknownExceptionMessage, a.Message),
                    Settings.Default.AppName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
#else
            controller.LoadApp();
#endif

            Application.Run(mainForm);
        }
    }
}
