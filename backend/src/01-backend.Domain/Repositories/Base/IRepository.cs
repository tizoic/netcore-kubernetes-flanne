using System;
using System.Collections.Generic;

namespace backend.Domain.Repositories.Base
{
    public interface IRepository <T> where T:class
    {
        T Add (T entity);
        void Delete (Guid id);
        T Update (T entity);
        IEnumerable<T> GetAll();
    }
}