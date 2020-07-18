using System;
using System.Windows.Forms;

namespace Binder
{
    public class Task : ITask, IEquatable<Task>
    {
        private string name;
        private DateTime date;
        private CheckState ifToday;

        public string Name
        {
            get { return name; }
            set
            {
                if (value == null || value == "") throw new ArgumentException("Value can't be null or empty.");

                name = value;
            }
        }
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value == DateTime.MinValue) throw new ArgumentException("Value can't be minimal of DateTime.");

                date = value;
            }
        }
        public CheckState IfToday
        {
            get { return ifToday; }
            set
            {
                if (value == CheckState.Indeterminate) throw new ArgumentException("Value of today task can't be indeterminate.");

                ifToday = value;
            }
        }

        public void AddTask(DataGridView tab)
        {
            var row = new DataGridViewRow();
            row.CreateCells(tab);
            row.SetValues(Name, Date, IfToday);
            tab.Rows.Add(row);
        }

        public void DeleteTask(DataGridView tab, int taskid)
        {
            tab.Rows.RemoveAt(taskid);
        }

        public void EditTask(DataGridView tab, int taskid)
        {
            tab.Rows[taskid].Cells[0].Value = Name;
            tab.Rows[taskid].Cells[1].Value = Date;
            tab.Rows[taskid].Cells[2].Value = IfToday;
        }

        public bool Equals(Task other)
        {
            bool same;

            if (Name == other.Name || Date == other.Date || IfToday == other.IfToday) same = true;
            else same = false;

            return same;
        }
    }
}
