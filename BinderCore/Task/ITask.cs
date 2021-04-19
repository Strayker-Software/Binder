using System;

namespace Binder.Task
{
    /// <summary>
    /// Interface for standard task classes definitions.
    /// </summary>
    public interface ITask : IEquatable<ITask>, INameEquatable
    {
        /// <summary>
        /// Task's name.
        /// </summary>
        string Name
        {
            get;
            set;
        }

        string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Task's start date.
        /// </summary>
        DateTime StartDate
        {
            get;
            set;
        }

        /// <summary>
        /// Task's end date.
        /// </summary>
        DateTime EndDate
        {
            get;
            set;
        }

        /// <summary>
        /// Value indicating, if task is completed.
        /// </summary>
        bool Complete
        {
            get;
            set;
        }

        string Category
        {
            get;
            set;
        }
    }
}
