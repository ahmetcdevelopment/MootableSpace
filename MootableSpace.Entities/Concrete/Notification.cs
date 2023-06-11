using mootableProject.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MootableSpace.Entities.Concrete
{
    public class Notification : EntityBase<int>, IEntity
    {
        public int UserId { get; set; }//Bildirimin hangi kullanıcıya geldiği.
        public int MootId { get; set; } // Bildirim hangi moot/mootable'ye ait.
        public string Text { get; set; }// Bildirim metni

        public string getEntityName()
        {
            return "Bildirim";
        }
    }
}
