using System;
using System.Windows.Forms;

namespace Binder.UI
{
    /// <summary>
    /// Windows Form for getting single input string from user.
    /// </summary>
    public partial class TextMessageBox : Form
    {
        private readonly IFormManager Frm;

        /// <summary>
        /// Constructor for TextMessageBox.
        /// </summary>
        /// <param name="info">String with information, what app wants from user.</param>
        public TextMessageBox(string info)
        {
            InitializeComponent();
            Frm = new TextMessageBoxManager(this, info);
        }

        private void TextMessageBox_Load(object sender, EventArgs e)
        {
            var frm = (TextMessageBoxManager)Frm;
            frm.LoadForm();
        }
    }
}
