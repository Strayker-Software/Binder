using Binder.Task;

namespace Binder.UI.Dialog
{
    public class DialogFactory : IDialogFactory
    {
        public IDialog GetDialog(EDialog dialogType, object arg)
        {
            switch (dialogType)
            {
                case EDialog.StandardTask:
                    if (arg == null)
                        return new StandardTaskForm();
                    else return new StandardTaskForm((ITask)arg);
                case EDialog.StringInput:
                    return new StringInputDialog((string)arg);
                default:
                    return null;
            }
        }

        public IDialog GetDialog(EDialog dialogType)
        {
            return GetDialog(dialogType, null);
        }
    }
}
