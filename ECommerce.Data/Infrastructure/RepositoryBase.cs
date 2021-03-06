﻿using ECommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Infrastructure
{
    //public abstract class RepositoryBase<T> : IRepository<T> where T : class
    //{
    //    private ecommerceContext dataContext;
    //    private IDbSet<T> dbset;
    //    IDatabaseFactory databaseFactory;
    //    protected RepositoryBase(IDatabaseFactory dbFactory)
    //    {
    //        this.databaseFactory = dbFactory;
    //        dbset = DataContext.Set<T>();
    //    }
    //    protected ecommerceContext DataContext
    //    {
    //        get
    //        {
    //            return dataContext = databaseFactory.DataContext;
    //        }
    //    }

    //    public virtual void Add(T entity)
    //    {
    //        dbset.Add(entity);
    //    }
    //    public virtual void Update(T entity) 
    //    {
    //        dbset.ToList().Remove(entity);
    //            dbset.Attach(entity);
    //            DataContext.Entry(entity).State = EntityState.Detached;
           
    //                if (!dbset.Local.Any(e => e.Equals(entity)))
    //        dbset.Local.ToList().Remove(entity);
    //        dbset.Attach(entity);
                    

    //        dbset.Attach(entity.);


    //        if (!DataContext.Set<T>().Local.Contains(entity))
    //           dbset.Attach(entity);
    //        else
    //          DataContext.Set<T>().Local.Contains(entity);
    //        dataContext.Entry(entity).State = EntityState.Modified;

           
           
    //    }
    //    public virtual void Delete(T entity)
    //    {
    //        dbset.Remove(entity);
    //    }

    //    public virtual void Delete(Expression<Func<T, bool>> where)
    //    {
    //        IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable(); foreach (T obj in objects) dbset.Remove(obj);
    //    }

    //    public virtual T GetById(long id)
    //    {

    //        return dbset.Find(id);
    //    }

    //    public virtual T GetById(int id)
    //    {
    //        return dbset.Find(id);
    //    }
    //    public virtual T GetById(string id)
    //    {
    //        return dbset.Find(id);
    //    }
    //    public virtual IEnumerable<T> GetAll()
    //    {
    //        return dbset.ToList();
    //    }

    //    public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
    //    {
    //        return dbset.Where(where).ToList();
    //    }

    //    public T Get(Expression<Func<T, bool>> where)
    //    {
    //        return dbset.Where(where).FirstOrDefault<T>();
    //    }
    //}

    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private ecommerceContext dataContext;

        protected ecommerceContext DataContext
        {
            get
            {
                return dataContext = databaseFactory.DataContext;
            }
        }

        private IDbSet<T> dbset;
        IDatabaseFactory databaseFactory;

        protected RepositoryBase(IDatabaseFactory dbFactory)
        {
            this.databaseFactory = dbFactory;
            dbset = DataContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }
        public virtual void Update(T entity)
        {
            ////var entry = dataContext.Entry(entity);
            ////if (entry.State == EntityState.Detached)
            ////{

            ////    dataContext.Set<T>().Attach(entity);
            ////    entry.State = EntityState.Modified;
            ////}

            ////dataContext.SaveChanges();
            //var entry = dataContext.Entry(entity);
            //entry.GetDatabaseValuesAsync();



            //dbset.Attach(entity);
            //dataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects) dbset.Remove(obj);
        }
        public virtual T GetById(long id)
        {
            return dbset.Find(id);
        }
        public virtual T GetById(int id)
        {
            using (var context = new ecommerceContext())
            {
                return dbset.Find(id);

            }
            
        }
        public virtual T GetById(string id)
        {
            return dbset.Find(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }
    }
}


