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
    public class EfCategoryDal : EfEntityRepositoryBase<Category>, ICategoryDal
    {
        public EfCategoryDal(DbContext context) : base(context)
        {
        }
    }
}
