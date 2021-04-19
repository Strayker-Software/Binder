namespace Binder.Storage
{
    public interface IFileStorage : IStorage
    {
        void RenameFile(string newname);

        bool CheckFileAccess();
    }
}
