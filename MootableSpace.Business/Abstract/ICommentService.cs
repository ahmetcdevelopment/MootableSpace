using mootableProject.Shared.Results.Abstract;
using MootableSpace.Entities.Concrete;
using MootableSpace.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.Business.Abstract
{
    public interface ICommentService
    {
        public Task<IResult> Save(Comment comment);
        public Task<IDataResult<Comment>> SelectById(int id);
        public IDataResult<IQueryable<CommentDto>> GetAllByParentId(int parentId);
        public IDataResult<IQueryable<CommentDto>> GetAllCommentTree(int mootId, params int[] parentId);
    }
}
