using Binder.Storages;
using Binder.Tasks;

namespace Binder.UI
{
    /// <summary>
    /// Interface for Windows Form preparation.
    /// </summary>
    public interface IFormManager
    {
        /// <summary>
        /// ITask object to control data in inherited classes.
        /// </summary>
        ITask Task
        {
            get;
            set;
        }

        /// <summary>
        /// IStorage object to control storage area in inherited classes.
        /// </summary>
        IStorage Strgm
        {
            get;
            set;
        }

        /// <summary>
        /// Method for form loading logic.
        /// </summary>
        bool LoadForm();

        /// <summary>
        /// Method for form closing logic.
        /// </summary>
        bool CloseForm();
    }
}
