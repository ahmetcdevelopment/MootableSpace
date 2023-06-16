using MootableSpace.DataAccess.Abstract;
using MootableSpace.DataAccess.Concrete.EntityFramework;
using MootableSpace.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.DataAccess.Concrete
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly mootableSpaceContext _context;
        private EfCategoryDal _categoryDal;
        private EfMootDal _mootDal;
        private EfCommentDal _commentDal;
        public UnitOfWork(mootableSpaceContext context)
        {
            _context = context;
        }

        public ICategoryDal Categories => _categoryDal ?? new EfCategoryDal(_context);

        public IMootDal Moots => _mootDal ?? new EfMootDal(_context);

        public ICommentDal Comments => _commentDal ?? new EfCommentDal(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
