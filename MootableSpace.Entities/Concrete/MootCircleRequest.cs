using mootableProject.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.Entities.Concrete
{
    public class MootCircleRequest : EntityBase<int>, IEntity
    {
        public int UserId { get; set; }// Circle isteği gönderilen user.
        public int SenderId { get; set; }// Circle isteği gönderen user.
        public int RequestStatus { get; set; }// Beklemede, reddedildi, kabul edildi.

        public string getEntityName()
        {
            return "Moot çevre isteği";
        }
    }
}
