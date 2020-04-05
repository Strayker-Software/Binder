using System;
using System.IO;

namespace Binder
{
    public class StorageManager : IStorage
    {
        private string storagePath;

        public string StoragePath
        {
            get { return storagePath; }
            set
            {
                if (value == null || value == "") throw new ArgumentException("Value can't be null or empty.");
                else if (!File.Exists(value)) throw new FileNotFoundException("Given file doesn't exist.");

                storagePath = value;
            }
        }

        public string LoadFromStorage()
        {
            var reader = new StreamReader(StoragePath);
            var data = reader.ReadToEnd();
            reader.Close();
            return data;
        }

        public void SaveToStorage(string Data)
        {
            var writer = new StreamWriter(StoragePath);
            writer.Write(Data);
            writer.Close();
        }
    }
}
