using MootableSpace.Entities.Dtos;

namespace MootableSpace.Web.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<MootDto> DtoList { get; set; }
    }
}
