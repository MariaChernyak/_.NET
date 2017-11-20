
using System.Collections.Generic;

namespace DL.Interfaces
{
    public interface IStorage<T>
    {
        IEnumerable<T> ReadAll();
        void Save(T data, bool isAppend);
    }
}
