﻿using Microsoft.AspNetCore.Identity;
using mootableProject.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mootableProject.Shared.Entities.Concrete
{
    public class RoleClaim : IdentityRoleClaim<int>, IEntity
    {
        public string getEntityName()
        {
            return "Rol yetkisi";
        }
    }
}
