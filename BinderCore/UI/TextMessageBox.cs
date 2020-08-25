using System;
using System.Windows.Forms;

namespace Binder
{
    /// <summary>
    /// Windows Form for getting single input string from user.
    /// </summary>
    public partial class TextMessageBox : Form
    {
        private readonly string Info;

        /// <summary>
        /// Constructor for TextMessageBox.
        /// </summary>
        /// <param name="info">String with information, what app wants from user.</param>
        public TextMessageBox(string info)
        {
            InitializeComponent();
            Info = info;
        }

        private void TextMessageBox_Load(object sender, EventArgs e)
        {
            InfoLabel.Text = Info;
        }
    }
}
