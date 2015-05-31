using System;
using System.Collections.Generic;

namespace Data.Services
{
    public interface BaseInterface<T> where T : class
    {
        IList<T> GetAll();
        T GetById(Guid id);
        T Add(T item);
        T Update(T item, Guid id);
        void Delete(Guid id);
        bool Exists(Guid id);
    }
}
