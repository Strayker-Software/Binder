using System;
using System.Diagnostics.CodeAnalysis;

namespace Binder.Task
{
    public class StandardTask : ITask
    {
        private string name;
        private string desc;
        private DateTime startDate;
        private DateTime endDate;
        private bool complete;
        private string category;

        public string Name
        {
            get { return name; }
            set
            {
                name = value ?? throw new NullReferenceException("Value can't be null.");
                if (value == string.Empty) throw new ArgumentException("Value can't be empty string");
            }
        }

        public string Description
        {
            get { return desc; }
            set
            {
                desc = value ?? throw new NullReferenceException("Value can't be null.");
            }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                if (DateTime.Compare(new DateTime(1970, 1, 1, 0, 0, 0), value) > 0) throw new ArgumentException("Value of StartDate can't exced UTC start date.");

                startDate = value;
            }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                if (DateTime.Compare(new DateTime(1970, 1, 1, 0, 0, 0), value) > 0) throw new ArgumentException("Value of StartDate can't exced UTC start date.");

                endDate = value;
            }
        }

        public bool Complete
        {
            get { return complete; }
            set
            {
                complete = value;
            }
        }

        public string Category
        {
            get { return category; }
            set
            {
                category = value ?? throw new NullReferenceException("Value can't be null.");
                if (value == string.Empty) throw new ArgumentException("Value can't be empty string.");
            }
        }

        public StandardTask()
        {
            
        }

        public StandardTask(string name, string description, DateTime startDate, DateTime endDate, bool complete)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Complete = complete;
        }

        public bool Equals([AllowNull] ITask other)
        {
            if (Name == other.Name
                    && Description == other.Description
                    && Category == other.Category
                    && Complete == other.Complete
                    && StartDate == other.StartDate
                    && EndDate == other.EndDate)
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
