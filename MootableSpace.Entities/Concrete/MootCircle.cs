using mootableProject.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.Entities.Concrete
{
    public class MootCircle : EntityBase<int>, IEntity
    {
        public int UserId { get; set; }
        public int UserId2 { get; set; }
        /// <summary>
        /// Eğer bir kullanıcı diğerini engellerse IsShow değerini false yapacağız.
        /// </summary>
        public bool IsShow { get; set; }

        public string getEntityName()
        {
            return "Moot çevresi";
        }
    }
}
