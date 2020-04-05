using System;
using System.Collections.Generic;

namespace Binder
{
    public interface IStorage
    {
        string StoragePath
        {
            get;
            set;
        }
        void SaveToStorage(string Data);
        string LoadFromStorage();
    }
}
