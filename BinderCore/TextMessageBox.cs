using System;
using System.Windows.Forms;

namespace Binder
{
    public partial class TextMessageBox : Form
    {
        private readonly string Info;

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
