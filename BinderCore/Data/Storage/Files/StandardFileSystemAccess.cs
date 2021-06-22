using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Binder.Data.Storage.Files
{
    /// <summary>
    /// Class for access file system. It's only abstraction layer on <see cref="System.IO"/> library.
    /// </summary>
    /// <remarks>No need in unit test-covering of this class. It's only abstraction for dependency separation.</remarks>
    [ExcludeFromCodeCoverage]
    public class StandardFileSystemAccess : IFileSystemAccess
    {
        /// <inheritdoc/>
        public void Delete(string path)
        {
            File.Delete(path);
        }

        /// <inheritdoc/>
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        /// <inheritdoc/>
        public StreamReader GetFileStreamReader(string path)
        {
            return new StreamReader(path);
        }

        /// <inheritdoc/>
        public StreamWriter GetFileStreamWriter(string path)
        {
            return new StreamWriter(path);
        }
    }
}
