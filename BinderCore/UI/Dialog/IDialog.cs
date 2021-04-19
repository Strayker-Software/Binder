namespace Binder.UI.Dialog
{
    public interface IDialog
    {
        object ReturnValue
        {
            get;
        }

        void AskUser();

        bool IsDataProvided();
    }
}
