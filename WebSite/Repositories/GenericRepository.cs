using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebSite.Models.Entity;


namespace WebSite.Repositories
{
    public class GenericRepository<T> where T : class,new()
    {
        DbCVEntities dbCVEntities = new DbCVEntities();
        public List<T> List()
        {
            return dbCVEntities.Set<T>().ToList();
        }
        public void TAdd(T P)
        {
            dbCVEntities.Set<T>().Add(P);
            dbCVEntities.SaveChanges();
        }
        public void TUpdate(T P)
        {
            dbCVEntities.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return dbCVEntities.Set<T>().FirstOrDefault(where);
        }
        public void TDelete(T P)
        {
            dbCVEntities.Set<T>().Remove(P);
            dbCVEntities.SaveChanges();

        }
    }
}