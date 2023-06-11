using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mootableProject.Shared.Entities.Abstract
{
    public abstract class EntityBase<T>
    {
        public virtual T Id { get; set; }
        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false;
        public virtual int ModifiedById { get; set; } 
    }
}
