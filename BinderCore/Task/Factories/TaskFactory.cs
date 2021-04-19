namespace Binder.Task.Factories
{
    public class TaskFactory : ITaskFactory
    {
        public ITask GetTask(ETask taskType)
        {
            return taskType switch
            {
                ETask.Standard => new StandardTask(),
                _ => null
            };
        }
    }
}
