using System.IO;

namespace Binder.Data.Storage.Files
{
    /// <summary>
    /// Interface for abstraction layers to file system libraries.
    /// </summary>
    public interface IFileSystemAccess
    {
        /// <summary>
        /// Deletes file under given full path.
        /// </summary>
        /// <param name="path"><see cref="string"/> object with path, file and extencion.</param>
        void Delete(string path);

        /// <summary>
        /// Checks if given full path exists.
        /// </summary>
        /// <param name="path"><see cref="string"/> object with path, file and extencion.</param>
        /// <returns><see cref="true"/> if path exists, <see cref="false"/> if not.</returns>
        bool Exists(string path);

        /// <summary>
        /// Factory method for creating <see cref="StreamWriter"/> objects.
        /// </summary>
        /// <param name="path"><see cref="string"/> object with path for stream.</param>
        /// <returns><see cref="StreamWriter"/> object set on given path.</returns>
        StreamWriter GetFileStreamWriter(string path);

        /// <summary>
        /// Factory method for creating <see cref="StreamReader"/> objects.
        /// </summary>
        /// <param name="path"><see cref="string"/> object with path for stream.</param>
        /// <returns><see cref="StreamReader"/> object set on given path.</returns>
        StreamReader GetFileStreamReader(string path);
    }
}