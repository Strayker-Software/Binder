namespace Binder.Task.Factories
{
    public enum ETask
    {
        Standard,
        None
    }

    public interface ITaskFactory
    {
        ITask GetTask(ETask taskType);
    }
}
