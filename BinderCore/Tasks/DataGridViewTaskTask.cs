using System;
using System.Windows.Forms;

namespace Binder.Tasks
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
                if (value.GetType() != typeof(DataGridView)) throw new ArgumentException("Value have to be of type DataGridView.");
                else if (value == null) throw new NullReferenceException("Value can't be null.");

                var tmp = (DataGridView)value;
                if (tmp.Columns.Count < 3) throw new ArgumentException("DataGridView object have to control at least three columns.");

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
                if (value < 0) throw new ArgumentOutOfRangeException("Value can't be lower than zero.");
                else if(tab.Rows.Count < value) throw new IndexOutOfRangeException("Value have to point to task in destination.");

                taskid = value;
            }
        }

        /// <summary>
        /// Add task to DataGridView.
        /// </summary>
        public void AddTask()
        {
            var dgv = (DataGridView)Destination;
            var row = new DataGridViewRow();
            row.CreateCells(dgv);
            row.SetValues(Name, Date, IfToday);
            dgv.Rows.Add(row);
            dgv.Refresh();
        }

        /// <summary>
        /// Delete task from DataGridView.
        /// </summary>
        public void DeleteTask()
        {
            var dgv = (DataGridView)Destination;
            dgv.Rows.RemoveAt(TaskId);
            dgv.Refresh();
        }

        /// <summary>
        /// Edit given task in DataGridView.
        /// </summary>
        public void EditTask()
        {
            var dgv = (DataGridView)Destination;
            dgv.Rows[TaskId].Cells[0].Value = Name;
            dgv.Rows[TaskId].Cells[1].Value = Date;
            dgv.Rows[TaskId].Cells[2].Value = IfToday;
            dgv.Refresh();
        }

        /// <summary>
        /// Check if given task objects are the same.
        /// </summary>
        /// <param name="other">Second DataGridViewTask object to check.</param>
        /// <returns>Returns true if tasks are the same, false if are different.</returns>
        public bool Equals(DataGridViewTask other)
        {
            bool same;

            if (Name == other.Name && Date == other.Date && IfToday == other.IfToday && Destination == other.Destination && TaskId == other.TaskId) same = true;
            else same = false;

            return same;
        }
    }
}
