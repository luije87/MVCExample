using System;
using System.Linq;

namespace MVCExample.DAL
{
    public interface ISchoolContext : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
        void Add<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        T Find<T>(int? id) where T : class;
        void SaveChanges();
    }
}