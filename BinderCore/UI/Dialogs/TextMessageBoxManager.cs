using Binder.Exceptions;
using Binder.Storages;
using Binder.Tasks;
using System.Windows.Forms;

namespace Binder.UI
{
    /// <summary>
    /// IFormManager class for to prepare TextMessageBox for user.
    /// </summary>
    public class TextMessageBoxManager : IFormManager
    {
        private IExceptionHandler handler;

        /// <summary>
        /// String data to display info about dialog box to user.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// ITask object to control data in class.
        /// </summary>
        public ITask Task { get; set; }

        /// <summary>
        /// IStorage object to control storage area in class.
        /// </summary>
        public IStorage Strgm { get; set; }

        /// <summary>
        /// IDialog object to call external dialog form.
        /// </summary>
        public IDialog DataDialog { get; set; }

        /// <summary>
        /// String data provided by user.
        /// </summary>
        public string InputData
        {
            get { return Input; }
            set
            {
                Input = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IExceptionHandler ExceptionHandler
        {
            get { return handler; }
            set
            {
                handler = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public TextMessageBox Form { get; }

        private string Input;

        /// <summary>
        /// Constructor for TextMessageBoxManager class.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="message"></param>
        public TextMessageBoxManager(TextMessageBox form, string message)
        {
            Message = message;
            Form = form;
        }

        /// <summary>
        /// Method to handle close form logic.
        /// </summary>
        /// <returns></returns>
        public bool CloseForm()
        {
            // Return input data to user:
            InputData = Form.Input.Text;

            return true;
        }

        /// <summary>
        /// Method to load info string to label.
        /// </summary>
        public bool LoadForm()
        {
            // Set message to form's label:
            Form.InfoLabel.Text = Message;
            return true;
        }

        /// <summary>
        /// Method called to handle accepting the form.
        /// </summary>
        public void OKButtonPressed()
        {
            // Return the dialog:
            Form.DialogResult = DialogResult.OK;
        }
    }
}
