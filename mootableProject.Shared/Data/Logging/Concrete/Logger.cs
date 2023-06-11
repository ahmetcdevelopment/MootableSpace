using mootableProject.Shared.Data.Abstract;
using mootableProject.Shared.Data.Logging.Abstract;
using mootableProject.Shared.Data.UnitOfWork;
using mootableProject.Shared.Entities.Abstract;
using mootableProject.Shared.Entities.Concrete;
using mootableProject.Shared.Messages;
using mootableProject.Shared.Results.Abstract;
using mootableProject.Shared.Results.ComplexTypes;
using mootableProject.Shared.Results.Concrete;
using mootableProject.Shared.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mootableProject.Shared.Data.Logging.Concrete
{
    public class Logger : ILogger
    {
        private readonly IEntityRepository<Log> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Logger(IEntityRepository<Log> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public IResult Log(IEntity entity, int userId)
        {
            var log = new Log();
            if (entity != null)
            {
                log.Entity = entity;
                log.LogStatus = ResultStatus.Success;
                log.ModifiedDate = DateTime.Now;
                log.IsDeleted = false;
                log.ModifiedById = userId;
                log.Message = new Messages<Log>(MessageStatus.Add, true).Text;
                _repository.AddAsync(log);
                _unitOfWork.Commit();
                return new Result(ResultStatus.Success, new Messages<Log>(MessageStatus.Add, true).Text);
            }
            return new Result(ResultStatus.Error, new Messages<Log>(MessageStatus.Add, false).Text);
        }

        public async Task<IResult> LogAsync(IEntity entity, int userId)
        {
            var log = new Log();
            if (entity != null)
            {
                log.Entity = entity;
                log.LogStatus = ResultStatus.Success;
                log.ModifiedDate = DateTime.Now;
                log.IsDeleted = false;
                log.ModifiedById = userId;
                log.Message = new Messages<Log>(MessageStatus.Add, true).Text;
                await _repository.AddAsync(log);
                await _unitOfWork.CommitAsync();
                return new Result(ResultStatus.Success, new Messages<Log>(MessageStatus.Add, true).Text);
            }
            return new Result(ResultStatus.Error, new Messages<Log>(MessageStatus.Add, false).Text);
        }
    }
}
