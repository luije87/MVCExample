using System;
using System.Collections.Generic;
using System.Linq;
using MVCExample.DAL;
using MVCExampleUnitTest.App_Data;

namespace MVCExampleUnitTest.FakeDB
{
    internal class FakeSchoolContext : ISchoolContext
    {
        public List<object> Added = new List<object>();
        public List<object> Removed = new List<object>();
        public bool Saved;
        public Dictionary<Type, object> Sets = new Dictionary<Type, object>();
        public List<object> Updated = new List<object>();

        public void Dispose()
        {
            
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return Sets[typeof (T)] as IQueryable<T>;
        }

        public void Add<T>(T entity) where T : class
        {
            var queryable = Sets[typeof (T)] as IQueryable<T>;
            queryable.ToList().Add(entity);
        }

        public void Remove<T>(T entity) where T : class => Removed.Remove(entity);
        public void Update<T>(T entity) where T : class => Updated.Add(entity);
        
        public T Find<T>(int? id) where T : class
        {
            return null;
        }

        public void SaveChanges() => Saved = true;

        public void AddSet<T>(IQueryable<T> objects) => Sets.Add(typeof (T), objects);
    }
}