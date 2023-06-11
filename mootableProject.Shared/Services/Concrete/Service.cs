using mootableProject.Shared.Data.Abstract;
using mootableProject.Shared.Data.UnitOfWork;
using mootableProject.Shared.Entities.Abstract;
using mootableProject.Shared.Messages;
using mootableProject.Shared.Results.Abstract;
using mootableProject.Shared.Results.ComplexTypes;
using mootableProject.Shared.Results.Concrete;
using mootableProject.Shared.Services.Abstract;
using mootableProject.Shared.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace mootableProject.Shared.Services.Concrete
{
    public class Service<T> : IService<T> where T : class, IEntity, new()
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityRepository<T> _repository;
        public Service(IUnitOfWork unitOfWork, IEntityRepository<T> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = genericRepository;
        }
        public async Task<IResult> AddAsync(T entity)
        {
            if (entity != null)
            {
                await _repository.AddAsync(entity);
                await _unitOfWork.CommitAsync();
                return new Result(ResultStatus.Success, new Messages<T>(MessageStatus.Add, true).Text);
            }
            return new Result(ResultStatus.Error, new Messages<T>(MessageStatus.Add, false).Text);

        }

        public async Task<IResult> AddRangeAsync(IEnumerable<T> entities)
        {
            _repository.AddRange(entities);
            await _unitOfWork.CommitAsync();
            return new Result(ResultStatus.Success, new Messages<T>(MessageStatus.Add, true).Text);
        }

        public async Task<IDataResult<bool>> AnyAsync(Expression<Func<T, bool>> expression)
        {
            var result = await _repository.AnyAsync(expression);
            return new DataResult<bool>(ResultStatus.Success, result);
        }

        public IDataResult<IQueryable<T>> FetchAll()
        {
            var result = _repository.GetAll();
            return new DataResult<IQueryable<T>>(ResultStatus.Success, result);
        }

        public async Task<IDataResult<T>> GetById(int id)
        {
            var result = await _repository.GetById(id);
            if (result != null)
            {
                return new DataResult<T>(ResultStatus.Success, new Messages<T>(MessageStatus.Get, true).Text, result);
            }
            return new DataResult<T>(ResultStatus.Error, new Messages<T>(MessageStatus.Get, false).Text, null);
        }

        //public IResult Remove(T entity)
        //{
        //}

        //public IResult RemoveRange(IEnumerable<T> entities)
        //{
        //    throw new NotImplementedException();
        //}

        public IResult Update(T entity)
        {
            if (entity != null)
            {
                _repository.Update(entity);
                _unitOfWork.Commit();
                return new Result(ResultStatus.Success, new Messages<T>(MessageStatus.Update, true).Text);
            }
            return new Result(ResultStatus.Error, new Messages<T>(MessageStatus.Update, false).Text);
        }

        public IDataResult<IQueryable<T>> Where(Expression<Func<T, bool>> expression)
        {
            var result = _repository.Where(expression);
            return new DataResult<IQueryable<T>>(ResultStatus.Success, result);
        }
    }
}
