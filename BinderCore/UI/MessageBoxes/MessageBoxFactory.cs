using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace Binder.UI.MessageBoxes
{
    [ExcludeFromCodeCoverage]
    public class MessageBoxFactory : IMessageBoxFactory
    {
        public DialogResult ShowMessageBox(EMessageBox type, string info, string boxname, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            var result = DialogResult.None;

            switch (type)
            {
                case EMessageBox.Standard:
                    result = MessageBox.Show(info, boxname, buttons, icon);
                    break;
            }

            return result;
        }
    }
}
