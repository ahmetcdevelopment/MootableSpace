using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.DataAccess.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        ICategoryDal Categories { get; }
        IMootDal Moots { get; }
        ICommentDal Comments { get; }
        Task<int> CommitAsync();
    }
}
