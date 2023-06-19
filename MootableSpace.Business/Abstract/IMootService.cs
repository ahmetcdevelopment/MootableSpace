using mootableProject.Shared.Results.Abstract;
using MootableSpace.Entities.Concrete;
using MootableSpace.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.Business.Abstract
{
    public interface IMootService
    {
        public IList<MootDto> FetchAllDtos();
        public IList<MootDto> FetchAllDtosByUserId(int userId);
        public Task<IResult> Save(Moot moot);
        public Task<IDataResult<Moot>> SelectById(int id);
    }
}
