using Microsoft.AspNetCore.Identity;
using mootableProject.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mootableProject.Shared.Entities.Concrete
{
    public class User : IdentityUser<int>, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public int Age { get; set; }
        public int Gender { get; set; }
        //public float Height { get; set; }
        //public float Weight { get; set; }
        //public string? Picture { get; set; }

        public string getEntityName()
        {
            return "Kullanıcı";
        }
    }
}
