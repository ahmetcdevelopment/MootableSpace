using mootableProject.Shared.Entities.Abstract;
using mootableProject.Shared.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mootableProject.Shared.Data.Logging.Abstract
{
    public interface ILogger
    {
        IResult Log(IEntity entity, int userId);
        Task<IResult> LogAsync(IEntity entity, int userId);
    }
}
