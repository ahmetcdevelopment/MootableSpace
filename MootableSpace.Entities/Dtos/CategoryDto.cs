using mootableProject.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.Entities.Dtos
{
    public class CategoryDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }//kategorinin adı
        public string Description { get; set; }//kategorinin açıklaması
    }
}
