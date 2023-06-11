using Microsoft.AspNetCore.Identity;
using mootableProject.Shared.Data.Abstract;
using mootableProject.Shared.Data.UnitOfWork;
using mootableProject.Shared.Entities.Concrete;
using mootableProject.Shared.Messages;
using mootableProject.Shared.Results.Abstract;
using mootableProject.Shared.Results.ComplexTypes;
using mootableProject.Shared.Results.Concrete;
using mootableProject.Shared.Utilities.Messages;
using MootableSpace.Business.Abstract;
using MootableSpace.Entities.Concrete;
using MootableSpace.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.Business.Concrete
{
    public class MootManager : IMootService
    {
        private readonly IEntityRepository<Moot> _mootRepository;
        private readonly IEntityRepository<Category> _categoryRepository;
        private readonly UserManager<User> _userService;
        private readonly IUnitOfWork _unitOfWork;
        public MootManager(IEntityRepository<Moot> mootRepository, IEntityRepository<Category> categoryRepository,
            UserManager<User> userService, IUnitOfWork unitOfWork)
        {
            _mootRepository = mootRepository;
            _categoryRepository = categoryRepository;
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public IQueryable<MootDto> FetchAllDtos()
        {
            var query = from m in _mootRepository.GetAll().Where(m => !m.IsDeleted)
                        join c in _categoryRepository.GetAll().Where(c => !c.IsDeleted)
                        on m.CategoryId equals c.Id
                        join u in _userService.Users.ToList()
                        on m.UserId equals u.Id
                        select new MootDto
                        {
                            Id = m.Id,
                            CategoryName = c.Name,
                            AgreeCount = m.Id,
                            CommentCount = m.CommentCount,
                            ShareDate = m.ShareDate,
                            Picture = m.Picture,
                            ShareStatus = m.ShareStatus,
                            Text = m.Text,
                            ViewCount = m.ViewCount,
                            UserName = u.UserName
                        };
            return query;
        }

        public async Task<IResult> Save(Moot moot)
        {
            var entityOldId = moot.Id;
            string msg = "";
            if (entityOldId != 0)
            {
                await _mootRepository.UpdateAsync(moot);
                msg = new Messages<Moot>(MessageStatus.Update, true).Text;
            }
            else
            {
                await _mootRepository.AddAsync(moot);
                msg = new Messages<Moot>(MessageStatus.Add, true).Text; 
            }
            await _unitOfWork.CommitAsync();
            return new Result(ResultStatus.Success, msg);
        }

        public async Task<IDataResult<Moot>> SelectById(int id)
        {
            var entity= await _mootRepository.GetAsync(m=>m.Id== id);
            return entity != null && entity.Id <= 0 ?
                new DataResult<Moot>(ResultStatus.Warning, new Messages<Moot>(MessageStatus.Get, false).Text, null) :
                new DataResult<Moot>(ResultStatus.Success, new Messages<Moot>(MessageStatus.Get, true).Text, entity);
        }
    }
}
