using mootableProject.Shared.Entities.Abstract;
using mootableProject.Shared.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mootableProject.Shared.Entities.Concrete
{
    public class Log : EntityBase<int>, IEntity
    {
        public IEntity Entity { get; set; }
        public ResultStatus LogStatus { get; set; }
        public string Message { get; set; }
        public string getEntityName()
        {
            return "Log";
        }
    }
}
