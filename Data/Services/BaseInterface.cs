using System;
using System.Collections.Generic;

namespace Data.Services
{
    public interface BaseInterface<T> where T : class
    {
        IList<T> GetAll();
        T GetById(int id);
        T Add(T item);
        T Update(T item, int id);
        void Delete(int id);
        bool Exists(int id);
    }
}
