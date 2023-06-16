using MootableSpace.Entities.Dtos;

namespace MootableSpace.Web.Models
{
    public class MootViewModel
    {
        public IList<MootDto> DtoList { get; set; }
        public MootEditViewModel? EditModel { get; set; }
    }
}
