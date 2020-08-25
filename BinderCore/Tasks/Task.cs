using System;
using System.Windows.Forms;

namespace Binder
{
    /// <summary>
    /// Task class for DataGridView access.
    /// </summary>
    public class DataGridViewTask : ITask, IEquatable<DataGridViewTask>
    {
        private string name;
        private DateTime date;
        private CheckState ifToday;
        private DataGridView tab;
        private int taskid;

        /// <summary>
        /// Name of task.
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null || value == "") throw new ArgumentException("Value can't be null or empty.");

                name = value;
            }
        }
        /// <summary>
        /// Date of deadline for the task.
        /// </summary>
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value == DateTime.MinValue) throw new ArgumentException("Value can't be minimal of DateTime.");

                date = value;
            }
        }
        /// <summary>
        /// CheckState value determining if task is for today.
        /// </summary>
        public CheckState IfToday
        {
            get { return ifToday; }
            set
            {
                if (value == CheckState.Indeterminate) throw new ArgumentException("Value of today task can't be indeterminate.");

                ifToday = value;
            }
        }
        /// <summary>
        /// DataGridView object to operate on.
        /// </summary>
        public object Destination
        {
            get { return tab; }
            set
            {
                tab = (DataGridView)value;
            }
        }
        /// <summary>
        /// Task ID integer for deleting and editing task.
        /// </summary>
        public int TaskId
        {
            get { return taskid; }
            set
            {
                taskid = value;
            }
        }

        /// <summary>
        /// Add task to DataGridView.
        /// </summary>
        public void AddTask()
        {
            var row = new DataGridViewRow();
            row.CreateCells(tab);
            row.SetValues(Name, Date, IfToday);
            tab.Rows.Add(row);
        }
        /// <summary>
        /// Delete task from DataGridView.
        /// </summary>
        public void DeleteTask()
        {
            tab.Rows.RemoveAt(taskid);
        }
        /// <summary>
        /// Edit given task in DataGridView.
        /// </summary>
        public void EditTask()
        {
            tab.Rows[taskid].Cells[0].Value = Name;
            tab.Rows[taskid].Cells[1].Value = Date;
            tab.Rows[taskid].Cells[2].Value = IfToday;
        }
        /// <summary>
        /// Check if given task objects are the same.
        /// </summary>
        /// <param name="other">Second DataGridViewTask object to check.</param>
        /// <returns>Returns true if tasks are the same, false if are different.</returns>
        public bool Equals(DataGridViewTask other)
        {
            bool same;

            if (Name == other.Name || Date == other.Date || IfToday == other.IfToday) same = true;
            else same = false;

            return same;
        }
    }
}
