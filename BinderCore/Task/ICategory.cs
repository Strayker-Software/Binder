using System;
using System.Collections.Generic;

namespace Binder.Task
{
    public interface ICategory : IEquatable<ICategory>, INameEquatable
    {
        string Name
        {
            get;
            set;
        }

        IList<ITask> Tasks
        {
            get;
            set;
        }
    }
}
