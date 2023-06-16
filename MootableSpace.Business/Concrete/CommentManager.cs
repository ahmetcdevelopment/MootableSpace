using Microsoft.AspNetCore.Identity;
using mootableProject.Shared.Data.Abstract;
using mootableProject.Shared.Entities.Concrete;
using mootableProject.Shared.Messages;
using mootableProject.Shared.Results.Abstract;
using mootableProject.Shared.Results.ComplexTypes;
using mootableProject.Shared.Results.Concrete;
using mootableProject.Shared.Utilities.Messages;
using MootableSpace.Business.Abstract;
using MootableSpace.DataAccess.Abstract;
using MootableSpace.Entities.Concrete;
using MootableSpace.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userService;

        public CommentManager(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userService = userManager;
        }

        public IDataResult<IQueryable<CommentDto>> GetAllByParentId(int parentId)
        {
            var query = from c in _unitOfWork.Comments.GetAll().Where(c => !c.IsDeleted && c.ParentId == parentId)
                        join u in _userService.Users.ToList() on c.UserId equals u.Id
                        join m in _unitOfWork.Moots.GetAll().Where(m => !m.IsDeleted) on c.MootId equals m.Id
                        select new CommentDto
                        {
                            Id = c.Id,
                            MootId = m.Id,
                            ParentId = parentId,
                            AgreeCount = c.AgreeCount,
                            Text = c.Text,
                            ViewCount = c.ViewCount,
                            UserFirstName = u.FirstName,
                            UserLastName = u.LastName,
                        };
            return query != null && query.ToList().Count <= -1 ?
                new DataResult<IQueryable<CommentDto>>(ResultStatus.Warning, null) :
                new DataResult<IQueryable<CommentDto>>(ResultStatus.Success, query);
        }

        public IDataResult<IQueryable<CommentDto>> GetAllCommentTree(int mootId, params int[] parentId)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Save(Comment comment)
        {
            var entityOldId = comment.Id;
            string msg = "";
            if (entityOldId != 0)
            {
                await _unitOfWork.Comments.UpdateAsync(comment);
                msg = new Messages<Comment>(MessageStatus.Update, true).Text;
            }
            else
            {
                await _unitOfWork.Comments.AddAsync(comment);
                msg = new Messages<Comment>(MessageStatus.Add, true).Text;
            }
            await _unitOfWork.CommitAsync();
            return new Result(ResultStatus.Success, msg);
        }

        public async Task<IDataResult<Comment>> SelectById(int id)
        {
            var entity = await _unitOfWork.Comments.GetAsync(c => c.Id == id);
            return entity != null && entity.Id <= 0 ?
                new DataResult<Comment>(ResultStatus.Warning, new Messages<Comment>(MessageStatus.Get, false).Text, null) :
                new DataResult<Comment>(ResultStatus.Success, new Messages<Comment>(MessageStatus.Get, true).Text, entity);
        }
    }
}
