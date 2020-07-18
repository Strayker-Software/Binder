using System;
using System.Windows.Forms;

namespace Binder
{
    public interface ITask
    {
        string Name
        {
            get;
            set;
        }
        DateTime Date
        {
            get;
            set;
        }
        CheckState IfToday
        {
            get;
            set;
        }
        void AddTask(DataGridView tab);
        void DeleteTask(DataGridView tab, int taskid);
        void EditTask(DataGridView tab, int taskid);
    }
}
