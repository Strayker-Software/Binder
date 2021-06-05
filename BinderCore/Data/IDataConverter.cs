using System.Collections.Generic;
using Binder.Task;

namespace Binder.Data
{
    /// <summary>
    /// Interface for data converting classes.
    /// </summary>
    public interface IDataConverter
    {
        /// <summary>
        /// Separator character, for string data to convert.
        /// </summary>
        char Separator
        {
            get;
            set;
        }

        /// <summary>
        /// Converts given data in string object to provided ITask object.
        /// </summary>
        /// <param name="dest">ITask object to fill with data.</param>
        /// <param name="data">String object with data to be converted.</param>
        /// <returns>ITask object filled with data from argument. Null if error.</returns>
        ITask ToObject(ITask dest, string data);

        /// <summary>
        /// Converts given data in IList-compatible list of string objects to provided ITask object.
        /// </summary>
        /// <param name="dest">Type of data to convert to.</param>
        /// <param name="data">IList object with string objects in it.</param>
        /// <returns>IList object filled with ITask objects from argument, filled in with data. Null if error.</returns>
        IList<ITask> ToObject(ITask dest, IList<string> data);

        /// <summary>
        /// Converts given data in ITask-compatible object to string.
        /// </summary>
        /// <param name="data">Data in ITask-compatible object.</param>
        /// <returns>String object with converted data. Null if error.</returns>
        string ToObject(ITask data);

        /// <summary>
        /// Converts given data in ITask-compatible objects' list to strings' list.
        /// </summary>
        /// <param name="data">Data in ITask-compatible objects' list, IList-compatible.</param>
        /// <returns>IList-compatible default list with converted data strings in it. Null if error.</returns>
        IList<string> ToObject(IList<ITask> data);

        /// <summary>
        /// Converts given data in string object to ICategory-compatible object.
        /// </summary>
        /// <param name="dest">ICategory-compatible object to fill with data.</param>
        /// <param name="data">String object with data.</param>
        /// <returns>ICategory-compatible object filled with converted data. Null if error.</returns>
        ICategory ToObject(ICategory dest, string data);

        /// <summary>
        /// Converts given data in IList-compatible list of strings to IList-compatible list of ICategory-compatible objects.
        /// </summary>
        /// <param name="dest">ICategory-compatible object to fill with data.</param>
        /// <param name="data">IList-compatible objects' list of string. Null if error.</param>
        /// <returns></returns>
        IList<ICategory> ToObject(ICategory dest, IList<string> data);

        /// <summary>
        /// Converts ICategory-compatible object to string object.
        /// </summary>
        /// <param name="data">ICategory-compatible object with data.</param>
        /// <returns>String object with data in it. Null if error.</returns>
        string ToObject(ICategory data);

        /// <summary>
        /// Converts given data in IList-compatible list of ICategory-compatible objects to IList-compatible list of string objects.
        /// </summary>
        /// <param name="data">IList-compatible list of ICategory-compatible objects with data.</param>
        /// <returns>IList-compatible list of string objects with data. Null if error.</returns>
        IList<string> ToObject(IList<ICategory> data);
    }
}
