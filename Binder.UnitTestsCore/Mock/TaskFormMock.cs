using Binder.Tasks;
using Binder.UI;
using System.Windows.Forms;

namespace Binder.UnitTests.Mock
{
    public class TaskFormMock : TaskForm, IDialog
    {
        public new DialogResult DialogResult { get; private set; }

        public TaskFormMock(ITask tsk, bool ifEdit) : base(tsk, ifEdit)
        {

        }

        public new DialogResult ShowDialog()
        {
            DialogResult = DialogResult.OK;
            return DialogResult;
        }
    }
}
