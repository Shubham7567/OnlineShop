using OnlineShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.BLL.Repository.IRepository
{
    public interface IRepository<T> where T:class
    {
        T Get(int id);

        IEnumerable<T> GetAll(
                Expression<Func<T,bool>> filter = null,
                Func<IQueryable<T>,IOrderedQueryable<T>> orderBy = null,
                string includeProperties = null
            );

        T GetFirstOrDefault(
                Expression<Func<T, bool>> filter = null,
                string includeProperties = null
            );

        Response Add(T entity);

        Response Remove(int id);

        Response Remove(T entity);

        Response RemoveRange(IEnumerable<T> entity);
    }
}
