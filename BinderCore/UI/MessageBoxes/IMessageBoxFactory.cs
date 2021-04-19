using System.Windows.Forms;

namespace Binder.UI.MessageBoxes
{
    public enum EMessageBox
    {
        Standard
    }

    public interface IMessageBoxFactory
    {
        DialogResult ShowMessageBox(EMessageBox type, string info, string boxname, MessageBoxButtons buttons, MessageBoxIcon icon);
    }
}
