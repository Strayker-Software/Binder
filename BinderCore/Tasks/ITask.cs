using System;
using System.Windows.Forms;

namespace Binder.Tasks
{
    /// <summary>
    /// Interface for creation of new task classes.
    /// </summary>
    public interface ITask
    {
        /// <summary>
        /// Value for naming task.
        /// </summary>
        string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Value for task's deadline.
        /// </summary>
        DateTime Date
        {
            get;
            set;
        }
        /// <summary>
        /// Value indicating, if task is for today.
        /// </summary>
        CheckState IfToday
        {
            get;
            set;
        }
        /// <summary>
        /// Object to perform adding, editing and deleting of tasks.
        /// </summary>
        object Destination
        {
            get;
            set;
        }
        /// <summary>
        /// ID integer for task identification.
        /// </summary>
        int TaskId
        {
            get;
            set;
        }
        /// <summary>
        /// Add given data to destination object.
        /// </summary>
        void AddTask();
        /// <summary>
        /// Delete task given by ID from destination.
        /// </summary>
        void DeleteTask();
        /// <summary>
        /// Edit task given by ID with provided data.
        /// </summary>
        void EditTask();
    }
}
