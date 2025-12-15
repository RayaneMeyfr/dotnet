using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListeContact.repository
{
    internal interface IRepository<T, Tid> where T : new()
    {
        T? Add(T entity);
        T? GetById(Tid id);
        T? Get(Func<T, bool> predicate);
        List<T> GetAll();
        List<T> GetAll(Func<T, bool> predicate);
        T? Update(Tid id, T entity);
        bool Delete(Tid id);
    }
}
