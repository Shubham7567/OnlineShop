using OnlineShop.BLL.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using OnlineShop.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using OnlineShop.Models.ViewModels;

namespace OnlineShop.BLL.Repository
{
    public class Repository<T> : IRepository<T> where T: class
    {
        private readonly ApplicationContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public Response Add(T entity)
        {
            Response response = new Response();
            try
            {
                dbSet.Add(entity);
                response.IsSuccess = true;
            }
            catch(Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public Response Remove(int id)
        {
            Response response = new Response();
            try
            {
                T entity = dbSet.Find(id);
                response = Remove(entity);
                
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.IsSuccess = false;
            }
            return response;
            
        }

        public Response Remove(T entity)
        {
            Response response = new Response();
            try
            {
                dbSet.Remove(entity);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }

        public Response RemoveRange(IEnumerable<T> entity)
        {
            Response response = new Response();
            try
            {
                dbSet.RemoveRange(entity);
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
