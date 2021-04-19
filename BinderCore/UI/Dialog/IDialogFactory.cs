namespace Binder.UI.Dialog
{
    public enum EDialog
    {
        StandardTask,
        StringInput
    }

    public interface IDialogFactory
    {
        IDialog GetDialog(EDialog dialogType, object arg);

        IDialog GetDialog(EDialog dialogType);
    }
}
