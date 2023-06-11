using mootableProject.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.Entities.Concrete
{
    public class Category : EntityBase<int>, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }//kategorinin açıklaması
        public string getEntityName()
        {
            return "Kategori";
        }
    }
}
