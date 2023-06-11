using Microsoft.AspNetCore.Mvc.Rendering;
using mootableProject.Shared.Data.Abstract;
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
    public class CategoryManager : ICategoryService
    {
        private readonly IEntityRepository<Category> _categoryRepository;

        public CategoryManager(IEntityRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IQueryable<CategoryDto> FetchAllDto()
        {
            var query = from c in _categoryRepository.GetAll()
                        where c.IsDeleted == false
                        select new CategoryDto
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Description = c.Description,
                        };
            return query;
        }

        public IList<SelectListItem> GetAllBySelectListItems()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (var c in FetchAllDto().ToList())
            {
                SelectListItem option = new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name,
                    Selected = false
                };
                selectList.Add(option);
            }
            return selectList;
        }
    }
}
