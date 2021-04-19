using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Binder.Task
{
    public class StandardCategory : ICategory, IEquatable<ICategory>, INameEquatable
    {
        private string name;
        private IList<ITask> tasks;

        public string Name
        {
            get { return name; }
            set
            {
                name = value ?? throw new NullReferenceException("Value can't be null.");
                if (value == string.Empty) throw new ArgumentException("Value can't be empty string.");
            }
        }

        public IList<ITask> Tasks
        {
            get { return tasks; }
            set
            {
                tasks = value ?? throw new NullReferenceException("Value can't be null.");
            }
        }

        public bool Equals([AllowNull] ICategory other)
        {
            if (Name == other.Name && Tasks == other.Tasks)
                return true;
            else return false;
        }

        public bool EqualsNames([AllowNull] string name)
        {
            if (Name == name) return true;
            else return false;
        }
    }
}
