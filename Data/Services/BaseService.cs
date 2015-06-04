using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Services
{
    public class BaseService<T> : BaseInterface<T> where T : class
    {
        protected FDPAppContext context = new FDPAppContext();

        public IList<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T Add(T item)
        {
            context.Set<T>().Add(item);
            context.SaveChanges();
            return item;
        }

        public T Update(T item, int id)
        {
            T existingItem = GetById(id);
            if (existingItem != null)
            {
                context.Entry(existingItem).State = EntityState.Modified; 
                context.SaveChanges();
            }
            return existingItem;
        }

        public void Delete(int id)
        {
            T toDeleteitem = GetById(id);
            context.Set<T>().Remove(toDeleteitem);
            context.SaveChanges();
        }

        public bool Exists(int id)
        {
            T item = GetById(id);
            if (item == null)
            {
                return false;
            }
            return true;
        }
    }
}
