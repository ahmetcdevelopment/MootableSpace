using mootableProject.Shared.Entities.Concrete;

namespace MootableSpace.Web.Models
{
    public class UserWithRolesViewModel
    {
        public User User { get; set; }
        public IList<string> Roles { get; set; }
    }
}
