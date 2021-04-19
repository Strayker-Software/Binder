using System;
using System.Windows.Forms;
using Binder.Properties.Languages;

namespace Binder.UI.Dialog
{
    public partial class StringInputDialog : Form, IDialog
    {
        public object ReturnValue { get; private set; }

        public StringInputDialog(string info)
        {
            InitializeComponent();

            InfoLabel.Text = info;
            DialogAcceptButton.Text = ResourceInputDialog.AcceptButton;
            DialogCancelButton.Text = ResourceInputDialog.CancelButton;
            Text = ResourceInputDialog.FormTitle;
        }

        public void AskUser()
        {
            ShowDialog();
        }

        public bool IsDataProvided()
        {
            if (ReturnValue != null) return true;
            else return false;
        }

        private void DialogAcceptButton_Click(object sender, EventArgs e)
        {
            if (InputTextBox.Text == "") ReturnValue = null;
            else ReturnValue = InputTextBox.Text;
        }
    }
}
