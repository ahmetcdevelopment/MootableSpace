using Microsoft.EntityFrameworkCore;
using mootableProject.Shared.Data.Concrete.EntityFramework;
using MootableSpace.DataAccess.Abstract;
using MootableSpace.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.DataAccess.Concrete.EntityFramework
{
    public class EfCommentDal : EfEntityRepositoryBase<Comment>, ICommentDal
    {
        public EfCommentDal(DbContext context) : base(context)
        {
        }
    }
}
