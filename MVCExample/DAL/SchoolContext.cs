using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using MVCExample.Models;

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

    public class SchoolContext : DbContext, ISchoolContext
    {
        public SchoolContext() : base("SchoolContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        IQueryable<T> ISchoolContext.Query<T>()
        {
            return Set<T>();
        }

        void ISchoolContext.Add<T>(T entity)
        {
            Set<T>().Add(entity);
        }

        void ISchoolContext.Remove<T>(T entity)
        {
            Set<T>().Remove(entity);
        }

        void ISchoolContext.Update<T>(T entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        T ISchoolContext.Find<T>(int? id)
        {
            return Set<T>().Find(id);
        }

        void ISchoolContext.SaveChanges()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}