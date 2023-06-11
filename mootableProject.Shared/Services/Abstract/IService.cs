using mootableProject.Shared.Entities.Abstract;
using mootableProject.Shared.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace mootableProject.Shared.Services.Abstract
{
    public interface IService<T> where T : class, IEntity, new()
    {
        Task<IResult> AddAsync(T entity);
        Task<IResult> AddRangeAsync(IEnumerable<T> entities);
        IDataResult<IQueryable<T>> FetchAll();
        IDataResult<IQueryable<T>> Where(Expression<Func<T, bool>> expression);
        Task<IDataResult<bool>> AnyAsync(Expression<Func<T, bool>> expression);
        Task<IDataResult<T>> GetById(int id);
        //IResult Remove(T entity);
        //IResult RemoveRange(IEnumerable<T> entities);
        IResult Update(T entity);
    }
}
