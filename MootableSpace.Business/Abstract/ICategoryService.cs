using Microsoft.AspNetCore.Mvc.Rendering;
using MootableSpace.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.Business.Abstract
{
    public interface ICategoryService
    {
        public IQueryable<CategoryDto> FetchAllDto();
        public SelectList GetAllBySelectListItems();
    }
}
