using Binder.Storages;
using Binder.Tasks;
using System;

namespace Binder.UI
{
    /// <summary>
    /// IFormManager class for to prepare TextMessageBox for user.
    /// </summary>
    public class TextMessageBoxManager : IFormManager
    {
        /// <summary>
        /// String data to display info about dialog box to user.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// ITask object to control data in class.
        /// </summary>
        public ITask Task { get; set; }
        /// <summary>
        /// IStorage object to control storage area in class.
        /// </summary>
        public IStorage Strgm { get; set; }

        private readonly TextMessageBox Frm;

        /// <summary>
        /// Constructor for TextMessageBoxManager class.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="message"></param>
        public TextMessageBoxManager(TextMessageBox form, string message)
        {
            Message = message;
            Frm = form;
        }

        /// <summary>
        /// Method to handle close form logic. Not used in this class.
        /// </summary>
        /// <returns>Throws NotSupportedException</returns>
        public bool CloseForm() { throw new NotSupportedException(); }

        /// <summary>
        /// Method to load info string to label.
        /// </summary>
        public bool LoadForm()
        {
            Frm.InfoLabel.Text = Message;
            return true;
        }
    }
}
