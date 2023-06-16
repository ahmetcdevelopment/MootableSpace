using Microsoft.AspNetCore.Mvc.Rendering;
using mootableProject.Shared.Data.Abstract;
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
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IQueryable<CategoryDto> FetchAllDto()
        {
            var query = from c in _unitOfWork.Categories.GetAll()
                        where c.IsDeleted == false
                        select new CategoryDto
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Description = c.Description,
                        };
            return query;
        }

        public SelectList GetAllBySelectListItems()
        {
            List<SelectListItem> _list = new List<SelectListItem>();
            var categories = _unitOfWork.Categories.GetAll();
            foreach (var c in categories)
            {
                _list.Add(new SelectListItem { Value = Convert.ToString(c.Id), Text = c.Name, Selected = false });
            }
            return new SelectList(_list, "Value", "Text");
        }
    }
}
