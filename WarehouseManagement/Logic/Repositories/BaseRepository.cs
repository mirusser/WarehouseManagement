﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WarehouseManagement.Models.Context;
using WarehouseManagement.Repositories.Logic.Interfaces;

namespace WarehouseManagement.Logic.Repositories
{
    public class BaseRepository<T, TEntity> : IBaseRepository<T>, IDisposable
       where T : class
       where TEntity : ApplicationDbContext, new()
    {
        #region Properties
        protected TEntity Entities { get; private set; }
        protected DbSet<T> Set => Entities.Set<T>();
        public IQueryable<T> Items => Set.AsQueryable();
        #endregion

        #region Constructors
        public BaseRepository()
        {
            Entities = new TEntity();
        }

        public BaseRepository(TEntity entities)
        {
            Entities = entities;
        }
        #endregion

        #region Methods
        public virtual IQueryable<T> GetAll()
        {
            return Items;
        }

        public virtual IQueryable<T> Query(Expression<Func<T, bool>> query)
        {
            return Items.Where(query);
        }

        public virtual T GetById(int id)
        {
            return Items.AsEnumerable().SingleOrDefault(i =>
                i.GetType().GetProperty("Id") != null && (int)i.GetType().GetProperty("Id").GetValue(i, null) == id);
        }

        public virtual void Add(T entity)
        {
            Entities.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            Entities.Entry<T>(entity).State = EntityState.Modified;

        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }

        public virtual void Delete(T entity)
        {
            Entities.Set<T>().Remove(entity);
        }

        public virtual void Save()
        {
            try
            {
                Entities.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public void RefreshDbContext()
        {
            Entities = new TEntity();
        }

        public virtual void Dispose()
        {
            Entities?.Dispose();
        }
        #endregion

    }
}