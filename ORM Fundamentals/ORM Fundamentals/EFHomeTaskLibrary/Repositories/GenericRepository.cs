using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Data;

namespace EFHomeTaskLibrary
{
   public class GenericRepository<T> : IRepository<T> where T : class
   {
      protected EFDbContext DbContext { get; set; }
      protected DbSet<T> DbSet { get; set; }

      public GenericRepository(EFDbContext context)
      {
         DbContext = context;
         DbSet = DbContext.Set<T>();
      }
      public void Create(T entity)
      {
         DbContext.Add(entity);
      }

      public void Delete(int id)
      {
         var entity = DbSet.Find(id);
         if (entity != null)
            DbContext.Remove(entity);
      }

      public T? Read(int id)
      {
         return DbSet.Find(id);
      }

      public List<T> Read()
      {
         return DbSet.ToList();
      }

      public void Update(T entity)
      {
         DbSet.Attach(entity);
         DbContext.Entry(entity).State = EntityState.Modified;
      }
   }
}
