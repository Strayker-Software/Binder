using System;
using System.Windows.Forms;

namespace Binder.UI
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDialog
    {
        /// <summary>
        /// 
        /// </summary>
        DialogResult DialogResult { get; }

        /// <summary>
        /// 
        /// </summary>
        DialogResult ShowDialog();
    }
}
